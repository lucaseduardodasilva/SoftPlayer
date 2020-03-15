using Envolti.IoC;
using Envolti.JurosAPI.options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Envolti.JurosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            InjetorDependencia.Register(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(envolti =>
            {
                envolti.SwaggerDoc("v1.0.0",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Envolti Juros API",
                        Version = "v1.0.0"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var opcoesSwagger = new OpcoesSwagger();
            Configuration.GetSection(nameof(OpcoesSwagger)).Bind(opcoesSwagger);

            app.UseSwagger(option =>
            {
                option.RouteTemplate = opcoesSwagger.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(opcoesSwagger.UiEndpoint, opcoesSwagger.Description);
            });

            app.UseMvc();
        }
    }
}
