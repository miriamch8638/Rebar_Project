using Microsoft.AspNetCore.Mvc;
using RebarProject3.DataAccess;
using RebarProject3.Models;

namespace Rebar_project3.Controllers
{
    [Route("api/shakes")]
    [ApiController]
    public class ShakeController : ControllerBase
    {
        private readonly DataAccess _dataAccess;

        public ShakeController()
        {
            _dataAccess = new DataAccess();
        }
        //[Route("/getAllShakes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shake>>> GetAllShakes()
        {
            try
            {
                var shakes = await _dataAccess.GetAllShakes();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[Route("/createShake")]
        [HttpPost]
        public async Task<ActionResult> CreateShake([FromBody] Shake shake)
        {
            try
            {
                await _dataAccess.CreateShake(shake);
                return Ok("Shake created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[Route("/updateShake")]
        [HttpPut]
        public async Task<ActionResult> UpdateShake([FromBody] Shake shake)
        {
            try
            {
                return Ok("Shake updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[Route("/deleteShake")]
        [HttpDelete("{shakeId}")]
        public async Task<ActionResult> DeleteShake(string shakeId)
        {
            try
            {
                return Ok("Shake deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

