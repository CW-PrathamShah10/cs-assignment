using cswebapi.Entities;

namespace cswebapi.DAL
{
    public class StockDAL : IStockDAL
    {
        public IEnumerable<Stock> GetStocks(Filters filters)
        {
            // Dummy data for now. In reality, you'll fetch from a database.
            return new List<Stock>
            {
                new Stock { Make = "Toyota", Model = "Corolla", MakeYear = 2020, Price = 1500000, Kilometers = 8000 },
                new Stock { Make = "Honda", Model = "Civic", MakeYear = 2019, Price = 2000000, Kilometers = 5000 }
            };
        }
    }
}
