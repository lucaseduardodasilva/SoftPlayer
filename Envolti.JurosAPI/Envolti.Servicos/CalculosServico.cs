using Envolti.Interfaces;
using Envolti.Servicos._Util;
using System;
using System.Globalization;

namespace Envolti.Servicos
{
    public class CalculosServico : ICalculosServico
    {
        private readonly IHttpServico httpServico;
        private readonly IConsultaTaxaJurosServico consultaTaxaJurosServico;

        public CalculosServico
        (IHttpServico httpServico,
        IConsultaTaxaJurosServico consultaTaxaJurosServico)
        {
            this.httpServico = httpServico;
            this.consultaTaxaJurosServico = consultaTaxaJurosServico;
        }

        public string CalculaValorTotalComJurosCompostos(decimal valorInicial, int tempo)
        {
            try
            {
                decimal jurosCalculado = CalculaJuros(tempo);
                decimal valorCalculado = valorInicial * jurosCalculado;

                decimal valorFinal = Math.Truncate(100 * valorCalculado) / 100;
                string Total = valorFinal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));

                return Total;
            }
            catch (Exception)
            {
                throw new ApplicationException("Houve algum erro ao tentar calcular o valor total.");
            }
        }

        public decimal CalculaJuros(int tempo)
        {
            try
            {
                decimal taxaJuros = httpServico.ConsultaTaxaJuros();
                decimal juros = 1 + taxaJuros;
                decimal jurosCalculado = Util.CalculaPotencia(juros, tempo);
                return jurosCalculado;
            }
            catch (Exception)
            {
                throw new ApplicationException("Houve algum erro ao tentar calcular o juros.");
            }
        }
    }
}
