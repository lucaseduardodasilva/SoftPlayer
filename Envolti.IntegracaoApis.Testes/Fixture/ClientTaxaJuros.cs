using Envolti.JurosAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Envolti.IntegracaoApis.Testes.Fixture
{
    public class ClientTaxaJuros
    {
        public HttpClient Cliente { get; set; }
        private TestServer _server;

        public ClientTaxaJuros()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Cliente = _server.CreateClient();
        }
    }
}
