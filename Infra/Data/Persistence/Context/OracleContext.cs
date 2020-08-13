using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class OracleContext : BaseContext
    {
        private const string Engine = "oracle";
        
        public OracleContext()
        {
            ObterDadosConexao(Engine);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle($"User Id={username};Password={password};Data source={server}");
        }
    }
}