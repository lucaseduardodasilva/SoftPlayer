using System;
using System.Globalization;

namespace Envolti.Dominio.Testes.Testes
{
    public static class Calculo
    {
        public static string CalculaValorTotalComJurosCompostos(decimal valorInicial, int tempo)
        {
            try
            {
                decimal juros = 1 + 0.01m;
                decimal jurosCalculado = CalculaPotencia(juros, tempo);

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

        static decimal CalculaPotencia(decimal numero, int potencia)
        {
            decimal resultado = 1;

            if (potencia > 0)
            {
                for (int i = 1; i <= potencia; ++i)
                {
                    resultado *= numero;
                }
            }
            else if (potencia < 0)
            {
                for (int i = -1; i >= potencia; --i)
                {
                    resultado /= numero;
                }
            }

            return resultado;
        }
    }
}
