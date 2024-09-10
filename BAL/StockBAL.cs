using AutoMapper;
using cswebapi.DAL;
using cswebapi.DTOs;
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

        public IEnumerable<StockDTO> GetStocks(StockSearchRequestDTO request)
        {
            var filters = _mapper.Map<Filters>(request);
            var stocks = _stockDAL.GetStocks(filters);

            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }
    }
}
