using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Adicionar opção para tratar referencias ciclicas ao serializar JSON...
            // TODO: Tratar valores nulos ao serializar...
            services.AddControllers();
            
            //Vamos documentar a API usando o OpenAPI (Swagger)
            services.AddSwaggerGen();
            
            //Usando o MS SQL server
            services.AddMsSqlDependency(Configuration);
            //Usando o Oracle
            //service.AddOracleDependency(Configuration);
            
            //Injetando os repositórios
            services.AddRepositoryDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                //Documentação só é gerada quando a Build for de desenvolvimento
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Teste Auvo");
                    c.RoutePrefix = string.Empty; // Colocamos isso para que a rota base seja a nossa documentação...
                });
            }
            
            // Tratamento de erros
            // app.UseExceptionHandler(env.IsDevelopment() ? "/error-local-development" : "/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}