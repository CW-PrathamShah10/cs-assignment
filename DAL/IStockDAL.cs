using cswebapi.Entities;

namespace cswebapi.DAL
{
    public interface IStockDAL
    {
        Task<IEnumerable<Stock>> GetStocks(Filters filters);
        Task<int> InsertRecordAsync();
    }
}
