using AutoMapper;
using cswebapi.DAL;
using cswebapi.DTO;
using cswebapi.Entities;

namespace cswebapi.BAL
{
    public class StockBAL : IStockBAL
    {
        private readonly IStockDAL _stockDAL;
        private readonly IMapper _mapper;

        public StockBAL(IStockDAL stockDAL, IMapper mapper)
        {
            _stockDAL = stockDAL;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDTO>> GetStocks(StockSearchRequestDTO request)
        {
            var filters = _mapper.Map<Filters>(request);
            // this above thing converts StockSearchRequestDTO -> Filters
            // using automapper profile(see mappings/mappingProfile.cs) 
            var stocks = await _stockDAL.GetStocks(filters);

            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public Task<int> InsertRecordAsync()
        {
            return _stockDAL.InsertRecordAsync();
        }
    }
}
