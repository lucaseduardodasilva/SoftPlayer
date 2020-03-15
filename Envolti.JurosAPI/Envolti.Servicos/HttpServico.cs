using Envolti.Interfaces;
using Envolti.Servicos._Util;
using System;
using System.Net.Http;

namespace Envolti.Servicos
{
    public class HttpServico : IHttpServico
    {
        private readonly HttpClient _cliente;

        public HttpServico(HttpClient cliente)
        {
            _cliente = cliente;
        }

        public decimal ConsultaTaxaJuros()
        {
            try
            {
                var httpResponse = _cliente.GetAsync(Urls.ConsultaJurosUrl);

                if (!httpResponse.Result.IsSuccessStatusCode)
                {
                    throw new Exception("Não foi possível consultar a taxa de juros.");
                }

                var taxaJuros = httpResponse.Result.Content.ReadAsStringAsync().Result;

                return decimal.Parse(taxaJuros);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
