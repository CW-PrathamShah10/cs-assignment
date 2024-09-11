namespace cswebapi.DTO
{
    public class StockSearchRequestDTO
    {
        public int? MinBudget { get; set; }
        public int? MaxBudget { get; set; }
        public List<int> FuelTypes { get; set; } // E.g. [1, 2, 3..6]
    }
}