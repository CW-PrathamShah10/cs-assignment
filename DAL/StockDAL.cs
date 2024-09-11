using cswebapi.Entities;
using cswebapi.DTO;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Text;  // Add this to use StringBuilder
using AutoMapper;


namespace cswebapi.DAL
{
    public class StockDAL : IStockDAL
    {

        private readonly IConfiguration _configuration;
 private readonly IMapper _mapper;
        public StockDAL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        private IDbConnection Connection
        {
            get
            {
                var connectionString = _configuration.GetConnectionString("MySqlConnection");
                return new MySqlConnection(connectionString);
            }
        }


        public async Task<int> InsertRecordAsync()
        {
            // The method InsertRecordAsync returns an int, which represents 
            // the number of rows affected by the SQL INSERT operation.
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO cars(Make, Model, MakeYear, Price, Kilometers) VALUES ('Suzuki', 'Swift', 2008, 75000, 65000)";
                dbConnection.Open();
                return await dbConnection.ExecuteAsync(query);
            }
        }
        public async Task<IEnumerable<Stock>> GetStocks(Filters filters)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = new StringBuilder(@"SELECT * FROM cars WHERE 1=1"); // Base query with dummy condition for appending ANDs
                var parameters = new DynamicParameters();

                // Apply budget filters if provided
                if (filters.MinBudget > 0)
                {
                    query.Append(" AND Price >= @MinBudget");
                    parameters.Add("MinBudget", filters.MinBudget);
                }
                if (filters.MaxBudget > 0)
                {
                    query.Append(" AND Price <= @MaxBudget");
                    parameters.Add("MaxBudget", filters.MaxBudget);
                }

                // Apply fuel type filters if provided
                if (filters.FuelTypes != null && filters.FuelTypes.Count > 0)
                {
                    query.Append(" AND FuelType IN @FuelTypes");
                    parameters.Add("FuelTypes", filters.FuelTypes.Select(ft => (int)ft).ToArray()); // Convert enums to int for query
                }

                dbConnection.Open();
                var stocks = await dbConnection.QueryAsync<Stock>(query.ToString(), parameters);

                return stocks;
            }
        }

    }
}
