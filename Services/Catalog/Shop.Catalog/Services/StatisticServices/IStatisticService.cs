namespace Shop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> TotalProductCount();
        Task<long> TotalCategoryCount();
    }
}
