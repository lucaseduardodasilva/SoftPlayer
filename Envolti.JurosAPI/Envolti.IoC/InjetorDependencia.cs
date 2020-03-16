using Envolti.Interfaces;
using Envolti.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Envolti.IoC
{
    public static class InjetorDependencia
    {
        public static void Register(IServiceCollection services)
        {
            RegistraServicos(services);
        }

        private static void RegistraServicos(IServiceCollection services)
        {
            services.TryAddScoped<ICalculosServico, CalculosServico>();
            services.TryAddScoped<IConsultaTaxaJurosServico, ConsultaTaxaJurosServico>();
            services.TryAddScoped<ICalculoMockServico, CalculoMockServico>();
            services.TryAddScoped<IHttpServico, HttpServico>();
        }
    }
}
