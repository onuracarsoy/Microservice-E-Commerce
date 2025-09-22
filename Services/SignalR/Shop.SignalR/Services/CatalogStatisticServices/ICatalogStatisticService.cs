namespace Shop.SignalR.Services.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> TotalProductCount();
        Task<long> TotalCategoryCount();
    }
}
