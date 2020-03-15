using Envolti.Interfaces;
using Envolti.Servicos._Util;
using System;
using System.Globalization;

namespace Envolti.Servicos
{
    public class CalculosServico : ICalculosServico
    {
        private readonly IHttpServico httpServico;

        public CalculosServico(IHttpServico httpServico)
        {
            this.httpServico = httpServico;
        }

        public string CalculaValorTotalComJurosCompostos(decimal valorInicial, int meses)
        {
            var taxaJuros = httpServico.ConsultaTaxaJuros();

            var juros = 1 + taxaJuros;

            decimal jurosCalculado = Util.CalculaPotencia(juros, meses);

            decimal valorCalculado = valorInicial * jurosCalculado;

            decimal valorFinal = Math.Truncate(100 * valorCalculado) / 100;

            return valorFinal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
