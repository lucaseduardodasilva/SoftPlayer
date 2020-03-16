using Envolti.Servicos._Util;
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
                return Ok(Urls.GitDesafioUrl);
            }
            catch (Exception)
            {
                throw new ApplicationException("Erro ao consultar a url de repositório do Github.");
            }
        }
    }
}
