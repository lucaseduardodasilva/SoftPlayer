using Envolti.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                return Ok(consultaTaxaJurosServico.ConsultaTaxaJuros());
            }
            catch (Exception)
            {
                throw new ApplicationException("Erro ao consultar taxa de juros.");
            }
        }
    }
}
