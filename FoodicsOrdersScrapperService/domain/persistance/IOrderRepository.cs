using FoodicsOrdersScrapperService.domain.entities;

namespace FoodicsOrdersScrapperService.domain.persistance;

public interface IOrderRepository
{
    Task Store(List<Order> orders, CancellationToken cancellationToken);
    Task<int?> GetLastReference();
}