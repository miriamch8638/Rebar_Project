using Microsoft.AspNetCore.Mvc;
using RebarProject3.DataAccess;
using RebarProject3.Models;

namespace RebarProject3.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : Controller
    {
        private AccountDataAccess accountAccess = new AccountDataAccess();
        [HttpGet]
        public async Task<IActionResult> GetAllReprts()
        {
            try
            {
                var reports = await accountAccess.GetDailyReport();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(string password)
        {
            try
            {
                await accountAccess.AddDailyReport(password);
                return Ok("report added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
