using FoodicsOrdersScrapperService.domain.entities;

namespace FoodicsOrdersScrapperService.infrastructure.webClients;

internal class ApiOrdersResponse
{
    public List<Order> Data { get; set; } = new();
    public LinksObject Links { get; set; }

    public class LinksObject
    {
        public string? Next { get; set; }
    }
}
