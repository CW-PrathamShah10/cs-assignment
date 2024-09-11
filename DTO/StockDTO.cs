using  cswebapi.Entities;
namespace cswebapi.DTO
{
    public class StockDTO
    {
        public string CarName { get; set; }
        public string FormattedPrice { get; set; }
        public bool IsValueForMoney { get; set; }


        public string Make { get; set; }
        public string Model { get; set; }
        public int MakeYear { get; set; }
        public int Kilometers { get; set; }
        public FuelType Fuel { get; set; }
    }
}
