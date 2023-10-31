using Microsoft.AspNetCore.Mvc;
using RebarProject3.DataAccess;
using RebarProject3.Models;

namespace Rebar_project3.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly DataAccess _dataAccess;

        public OrdersController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllShakes()
        {
            try
            {
                var orders = await _dataAccess.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
