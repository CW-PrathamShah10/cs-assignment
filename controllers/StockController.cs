using Microsoft.AspNetCore.Mvc;
using cswebapi.BAL;
using cswebapi.DTOs;

namespace cswebapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockBAL _stockBAL;

        public StockController(IStockBAL stockBAL)
        {
            _stockBAL = stockBAL;
        }

        [HttpGet("search")]
        public IActionResult GetStocks([FromQuery] StockSearchRequestDTO request)
        {
            // [FromQuery]: This tells the framework to bind query string 
            // parameters from the URL to the `StockSearchRequestDTO`
            // object.
            if (!ModelState.IsValid) {
                // The main purposes of ModelState are:
                // Model Binding: It captures the result of binding 
                // incoming request data to your models or parameters.
                // Validation: It stores any validation errors that occur
                // during model binding, so you can check if the data 
                // was valid before processing it.
                return BadRequest(ModelState);
            }
            try
            {
                var stocks = _stockBAL.GetStocks(request);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
