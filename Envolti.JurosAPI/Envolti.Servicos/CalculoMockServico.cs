using Envolti.Interfaces;
using Envolti.Servicos._Util;
using System;
using System.Globalization;

namespace Envolti.Servicos
{
    public class CalculoMockServico : ICalculoMockServico
    {
        public string CalculaValorTotalComJurosCompostos(decimal valorInicial, int tempo)
        {
            try
            {
                decimal juros = 1 + 0.01m;
                decimal jurosCalculado = Util.CalculaPotencia(juros, tempo);

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
    }
}
