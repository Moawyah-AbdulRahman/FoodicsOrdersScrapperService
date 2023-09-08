using FoodicsOrdersScrapperService.domain.services;

namespace FoodicsOrdersScrapperService.application;

public class OrdersScrapingWorker : BackgroundService
{
    private readonly int DELAY_IN_SECONDS;

    private readonly IOrderScrappingService _scrapper;


    public OrdersScrapingWorker(IOrderScrappingService scrapper, IConfiguration configuration)
    {
        DELAY_IN_SECONDS = int.Parse( configuration["ScrappingIntervalInSeconds"] ?? "60" );
        _scrapper = scrapper;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var lastSavedAt = await _scrapper.GetLastReference();

        while (!cancellationToken.IsCancellationRequested)
        {
            lastSavedAt = await _scrapper.Scrap(lastSavedAt, cancellationToken);
            await Task.Delay(1000 * DELAY_IN_SECONDS, cancellationToken);
        }

    }
}