using FoodicsOrdersScrapperService.domain.entities;
using FoodicsOrdersScrapperService.domain.persistance;

namespace FoodicsOrdersScrapperService.domain.services;

public class OrderScrappingService : IOrderScrappingService
{
    private readonly IOrderRepository _orderStoringRepository;
    private readonly IOrderWebSource _orderWebSource;

    public OrderScrappingService(IOrderRepository orderStoringRepository, IOrderWebSource orderWebSource)
    {
        _orderStoringRepository = orderStoringRepository;
        _orderWebSource = orderWebSource;
    }

    public async Task<int> GetLastReference()
    {
        return await _orderStoringRepository.GetLastReference() ?? 0;
    }

    public async Task<int> Scrap(int referenceAfter, CancellationToken cancellationToken)
    {
        var hasMore = true;
        while (hasMore)
        {
            Console.WriteLine($"last saved reference: {referenceAfter}");
            List<Order> orders;
            (orders, hasMore) = await _orderWebSource.GetPage(referenceAfter, cancellationToken);

            if (orders.Any())
            {
                referenceAfter = orders.Last().reference;
            }

            await _orderStoringRepository.Store(orders, cancellationToken);
        }
        return referenceAfter;
    }
}
