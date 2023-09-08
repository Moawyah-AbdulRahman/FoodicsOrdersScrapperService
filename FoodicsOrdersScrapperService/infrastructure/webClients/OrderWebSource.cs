using System.Net.Http.Json;
using FoodicsOrdersScrapperService.domain.entities;
using FoodicsOrdersScrapperService.domain.persistance;
using Polly;
using Polly.Retry;

namespace FoodicsOrdersScrapperService.infrastructure.webClients;

public class OrderWebSource : IOrderWebSource
{
    private readonly int MAX_RETRIES; 
    private readonly string ORDERS_PATH;

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AsyncRetryPolicy<ApiOrdersResponse> _retryPolicy;
    public OrderWebSource(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        MAX_RETRIES = int.Parse(configuration["EndpointInfo:MaxRetries"] ?? "10");
        ORDERS_PATH = configuration["EndpointInfo:OrdersPath"] ?? "";

        _httpClientFactory = httpClientFactory;
        _retryPolicy = Policy<ApiOrdersResponse>
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(MAX_RETRIES, t => TimeSpan.FromMilliseconds(500 * Math.Pow(2, t)) );
    }

    public async Task<(List<Order> orders, bool hasMore)> GetPage(int referenceAfter, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("foodics");
        var response = await _retryPolicy.ExecuteAsync(async () => 
            await client.GetFromJsonAsync<ApiOrdersResponse>(
                $"{ORDERS_PATH}{referenceAfter}", cancellationToken
                ) ?? new()
            );
        return (response.Data, response.Links.Next is not null);
    }
}

