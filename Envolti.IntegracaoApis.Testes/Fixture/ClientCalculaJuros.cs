using Envolti.CalculaJurosAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Envolti.Integracao.Testes.Fixture
{
    public class ClientCalculaJuros
    {
        public HttpClient Cliente { get; set; }
        private TestServer _server;

        public ClientCalculaJuros()
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
