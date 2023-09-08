using FoodicsOrdersScrapperService.domain.entities;
using FoodicsOrdersScrapperService.domain.persistance;
using Microsoft.Extensions.DependencyInjection;

namespace FoodicsOrdersScrapperService.infrastructure.persistance;

public class OrderRepository : IOrderRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public OrderRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Store(List<Order> orders, CancellationToken cancellationToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<FoodicsDbContext>();
        await dbContext.Orders.AddRangeAsync(orders, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int?> GetLastReference()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<FoodicsDbContext>();

        return dbContext.Orders.Select(o => (int?)o.reference).Max();
    }
}