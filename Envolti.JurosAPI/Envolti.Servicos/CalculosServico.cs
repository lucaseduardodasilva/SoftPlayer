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

        public string CalculaValorTotalComJurosCompostos(decimal valorInicial, int meses)
        {
            decimal jurosCalculado = CalculaJuros(meses);
            decimal valorCalculado = valorInicial * jurosCalculado;

            decimal valorFinal = Math.Truncate(100 * valorCalculado) / 100;
            string Total = valorFinal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));

            return Total;
        }

        public decimal CalculaJuros(int meses)
        {
            decimal taxaJuros = httpServico.ConsultaTaxaJuros();
            decimal juros = 1 + taxaJuros;
            decimal jurosCalculado = Util.CalculaPotencia(juros, meses);
            return jurosCalculado;
        }

        //var name = Dns.GetHostName(); // get container id
        //var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
    }
}
