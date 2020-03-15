using Envolti.Integracao.Testes.Fixture;
using Envolti.IntegracaoApis.Testes.Fixture;
using Envolti.Servicos._Util;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Envolti.IntegracaoApis.Testes.Testes
{
    public class TestesIntegracaoApis
    {
        private readonly ClientTaxaJuros _clientTaxaJuros;
        private readonly ClientCalculaJuros _clientCalculaJuros;

        public TestesIntegracaoApis()
        {
            _clientTaxaJuros = new ClientTaxaJuros();
            _clientCalculaJuros = new ClientCalculaJuros();
        }

        [Fact]
        public async Task DeveRetornarStatusCodeOk()
        {
            var response = await _clientTaxaJuros.Cliente.GetAsync(Urls.TaxaJuros);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeveRetonarBadRequest()
        {
            var parametros = new Dictionary<string, string>
            {
                { "valorInicial", "100" },
                { "meses", "5" }
            };

            var conteudoCodificado = new FormUrlEncodedContent(parametros);

            var response = await _clientCalculaJuros.Cliente.PostAsync(Urls.CalculaJuros, conteudoCodificado);
            var value = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
