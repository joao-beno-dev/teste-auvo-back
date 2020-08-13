using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MsSqlContext : BaseContext
    {
        private const string Engine = "mssql";

        public MsSqlContext()
        {
            this.ObterDadosConexao(Engine);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server={server},{port};Database={database};Uid={username};Pwd={password}");
        }
    }
}