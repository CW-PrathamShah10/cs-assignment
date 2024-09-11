using cswebapi.DTO;

namespace cswebapi.BAL
{
    public interface IStockBAL
    {
        Task<IEnumerable<StockDTO>> GetStocks(StockSearchRequestDTO request);
        public Task<int> InsertRecordAsync();

    }
}
