using Bogus;
using Envolti.Dominio.Testes._Builders;
using Envolti.Dominio.Testes._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Envolti.Dominio.Testes.Entidades
{
    public class JurosTeste : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly decimal _valorInicial;
        private readonly int _meses;
        private readonly int meses;
        private readonly decimal _taxaJuros;

        public JurosTeste(ITestOutputHelper output)
        {
            _output = output;
            var dadoFake = new Faker();

            _valorInicial = (decimal)dadoFake.Random.Decimal();
            meses = 5;
            _meses = dadoFake.Random.Int(-200, 200);
            _taxaJuros = (decimal)dadoFake.Random.Decimal();

            _output.WriteLine($"Decimal aleatório gerado: {dadoFake.Random.Decimal()}");
            _output.WriteLine($"Int aleatório gerado: {dadoFake.Random.Int(-200, 200)}");
        }

        public void Dispose() { }

        [Fact]
        public void DeveAceitarValores()
        {
            var valorEsperado = new
            {
                ValorInicial = _valorInicial,
                Meses = meses,
                TaxaJuros = _taxaJuros
            };

            var juros =
                new Juros(valorEsperado.ValorInicial, valorEsperado.Meses, valorEsperado.TaxaJuros);

            valorEsperado.ToExpectedObject().ShouldMatch(juros);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveAceitarValorInicialMenorQue001(decimal valorInicialInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                JurosBuilder.Novo().ComValorInicial(valorInicialInvalido).Build())
                .ComMensagem("Valor inicial inválido.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveTaxaJurosSerMenorQue001(decimal taxaJurosInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                JurosBuilder.Novo().ComTaxaJuros(taxaJurosInvalida).Build())
                .ComMensagem("Taxa de juros inválida.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void NaoDeveAceitarMesesMenorQue1ouMaiorQue100(int mesesInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                JurosBuilder.Novo().ComMeses(mesesInvalido).Build())
                .ComMensagem("Meses não deve ser menor que 1 ou maior que 100.");
        }
    }

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
