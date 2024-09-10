namespace Cswebapi.DTO
{
    public class StockSearchRequestDTO
    {
        public int? MinBudget { get; set; }
        public int? MaxBudget { get; set; }
        public List<string> FuelTypes { get; set; } // E.g. ["Petrol", "Diesel"]
    }
}