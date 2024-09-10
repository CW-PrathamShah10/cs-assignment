using cswebapi.DTOs;

namespace cswebapi.BAL
{
    public interface IStockBAL
    {
        IEnumerable<StockDTO> GetStocks(StockSearchRequestDTO request);
    }
}
