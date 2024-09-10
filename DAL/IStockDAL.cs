using cswebapi.Entities;

namespace cswebapi.DAL
{
    public interface IStockDAL
    {
        IEnumerable<Stock> GetStocks(Filters filters);
    }
}
