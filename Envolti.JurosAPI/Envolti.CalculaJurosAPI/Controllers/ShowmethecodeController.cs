using Microsoft.AspNetCore.Mvc;
using System;

namespace Envolti.CalculaJurosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string url = "https://github.com/lucaseduardodasilva/SoftPlayer";
                return Ok(url);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
