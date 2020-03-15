using Envolti.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Envolti.JurosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly IConsultaTaxaJurosServico consultaTaxaJurosServico;

        public TaxaJurosController(IConsultaTaxaJurosServico consultaTaxaJurosServico)
        {
            this.consultaTaxaJurosServico = consultaTaxaJurosServico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(consultaTaxaJurosServico.ConsultaTaxaJuros());
        }
    }
}
