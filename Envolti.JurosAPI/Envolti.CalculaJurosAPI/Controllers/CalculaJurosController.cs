using Envolti.Excecoes.CalculoExceptions;
using Envolti.Excecoes.Enums;
using Envolti.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Envolti.CalculaJurosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculosServico calculosServico;

        public CalculaJurosController(ICalculosServico calculosServico)
        {
            this.calculosServico = calculosServico;
        }

        [HttpPost]
        public IActionResult Post(decimal valorInicial, int meses)
        {
            try
            {
                if (valorInicial > 0 && meses > 0 && meses < 101)
                {
                    return Ok(calculosServico.CalculaValorTotalComJurosCompostos
                            (valorInicial, meses));
                }

                return BadRequest(
                    new CalculoException(EnvoltiExceptionEnum.VALORES_INVALIDOS.Codigo,
                                        EnvoltiExceptionEnum.VALORES_INVALIDOS.Valor)
                                        );
            }
            catch (CalculoException ex)
            {
                return BadRequest(new CalculoException(ex.Codigo, ex.Mensagem));
            }
        }
    }
}
