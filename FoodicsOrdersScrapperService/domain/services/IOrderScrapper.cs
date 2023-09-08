namespace FoodicsOrdersScrapperService.domain.services;

public interface IOrderScrappingService
{
    Task<int> Scrap(int referenceAfter, CancellationToken cancellationToken);
    Task<int> GetLastReference();
}