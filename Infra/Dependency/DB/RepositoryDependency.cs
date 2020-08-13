using Domain.Model.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace DB
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IMarcacaoRepository, MarcacaoRepository>();
        }
    }
}