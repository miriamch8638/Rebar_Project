using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

namespace Rebar_project2.Controllers
{
    [Route("api/shakes")]
    [ApiController]
    public class ShakeController : ControllerBase
    {
        private readonly ShakeDataAccess _shakeDataAccess;

        public ShakeController()
        {
            _shakeDataAccess = new ShakeDataAccess();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShakeModel>>> GetAllShakes()
        {
            try
            {
                var shakes = await _shakeDataAccess.GetAllShakes();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateShake([FromBody] ShakeModel shake)
        {
            try
            {
                await _shakeDataAccess.CreateShake(shake);
                return Ok("Shake created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateShake([FromBody] ShakeModel shake)
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

