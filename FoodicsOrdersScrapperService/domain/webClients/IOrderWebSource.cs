using FoodicsOrdersScrapperService.domain.entities;

namespace FoodicsOrdersScrapperService.domain.persistance;

public interface IOrderWebSource
{
    Task<(List<Order> orders, bool hasMore)> GetPage(int referenceAfter, CancellationToken cancellationToken);
}