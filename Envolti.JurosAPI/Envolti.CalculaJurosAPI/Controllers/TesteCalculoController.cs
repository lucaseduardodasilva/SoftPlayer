using Envolti.Excecoes.CalculoExceptions;
using Envolti.Excecoes.Enums;
using Envolti.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Envolti.CalculaJurosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteCalculoController : ControllerBase
    {
        private readonly ICalculoMockServico calculoMockServico;

        public TesteCalculoController(ICalculoMockServico calculoMockServico)
        {
            this.calculoMockServico = calculoMockServico;
        }

        [HttpPost]
        public IActionResult Post([FromQuery]decimal valorInicial, [FromQuery]int meses)
        {
            try
            {
                if (valorInicial > 0 && meses > 0 && meses < 101)
                {
                    return Ok(calculoMockServico.CalculaValorTotalComJurosCompostos
                            (valorInicial, meses));
                }

                return BadRequest(
                    new EnvoltiException(EnvoltiExceptionEnum.VALORES_INVALIDOS.Codigo,
                                        EnvoltiExceptionEnum.VALORES_INVALIDOS.Valor)
                                        );
            }
            catch (EnvoltiException ex)
            {
                return BadRequest(new EnvoltiException(ex.Codigo, ex.Mensagem));
            }
        }
    }
}
