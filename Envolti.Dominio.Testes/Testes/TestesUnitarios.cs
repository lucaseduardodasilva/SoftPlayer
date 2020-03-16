using Bogus;
using Envolti.Dominio.Entidades;
using Envolti.Dominio.Testes._Builders;
using Envolti.Dominio.Testes._Util;
using Envolti.Dominio.Testes.Testes;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Envolti.Dominio.Testes.Entidades
{
    public class TestesUnitarios : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly decimal _valorInicial;
        private readonly int _meses;
        private readonly int meses;
        private readonly decimal _taxaJuros;

        public TestesUnitarios
        (ITestOutputHelper output)
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

        [Fact]
        public void DeveCalcularValorTotal()
        {
            var valores = new
            {
                ValorInicial = _valorInicial,
                Meses = meses,
                TaxaJuros = _taxaJuros
            };

            Calculo.CalculaValorTotalComJurosCompostos(valores.ValorInicial, valores.Meses);
        }
    }

   

}
