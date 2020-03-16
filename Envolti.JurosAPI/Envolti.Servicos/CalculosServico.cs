using Envolti.Interfaces;
using Envolti.Servicos._Util;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;

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
            var name = Dns.GetHostName(); // get container id
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

            var taxaJuros = httpServico.ConsultaTaxaJuros();
            var juros = 1 + taxaJuros;

            decimal jurosCalculado = Util.CalculaPotencia(juros, meses);

            decimal valorCalculado = valorInicial * jurosCalculado;

            decimal valorFinal = Math.Truncate(100 * valorCalculado) / 100;

            return valorFinal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
