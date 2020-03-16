using System;

namespace Envolti.Dominio.Entidades
{
    public class Juros
    {
        public Juros(decimal valorInicial, int meses, decimal taxaJuros)
        {
            if (valorInicial < 0.01m)
            {
                throw new ArgumentException("Valor inicial inválido.");
            }

            if (taxaJuros < 0.01m)
            {
                throw new ArgumentException("Taxa de juros inválida.");
            }

            if (meses < 1 || meses > 100)
            {
                throw new ArgumentException("Meses não deve ser menor que 1 ou maior que 100.");
            }

            ValorInicial = valorInicial;
            Meses = meses;
            TaxaJuros = taxaJuros;
        }

        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }
        public decimal TaxaJuros { get; set; }
    }
}
