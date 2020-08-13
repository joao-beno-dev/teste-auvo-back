using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Mapping;

namespace Persistence.Context
{
    /// <summary>
    /// Contexto base, usado para deixar a aplicação independente do Provedor de Banco de Dados.
    /// </summary>
    public class BaseContext : DbContext
    {
        // Propriedades usadas por todas as engines de conexão
        // TODO: Tornar as propriedades dinâmicas (Talvez um dicionário?)
        protected string server = "";
        protected string port = "";
        protected string database = "";
        protected string username = "";
        protected string password = "";

        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Marcacao> Marcacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(new PessoaMapping().Configure);
            modelBuilder.Entity<Marcacao>(new MarcacaoMapping().Configure);


            # region Seeds
            // TODO: Mover seeds para um método a parte
            modelBuilder.Entity(typeof(Pessoa))
                .Ignore(nameof(Pessoa.Nome)) // Ignoramos a propriedade "Nome" pois ela é apenas um apelido da coluna ID...
                .HasData(
                    new List<object>(new[]
                    {
                        new Pessoa { Id = "João" },
                        new Pessoa { Id = "Pedro" },
                        new Pessoa { Id = "Vanessa" },
                        new Pessoa { Id = "Karla" },
                        new Pessoa { Id = "Maxwell" },
                        new Pessoa { Id = "Maxine" },
                        new Pessoa { Id = "Maxmiliano" },
                        new Pessoa { Id = "Mario" },
                    }));

            modelBuilder.Entity<Marcacao>().HasData(
                new
                {
                    Id = 1,
                    DataHora = DateTime.Parse("2020-08-08 16:00:00.000"),
                    Descricao = "Inicio Dia 1",
                    PessoaId = "João"
                },
                new {
                    Id = 2,
                    DataHora = DateTime.Parse("2020-08-08 19:00:00.000"),
                    Descricao = "Fim Dia 1 (Inicio projeto e modelos)",
                    PessoaId = "João"
                },
                new
                {
                    Id = 3,
                    DataHora = DateTime.Parse("2020-08-09 20:00:00.000"),
                    Descricao = "Inicio Dia 2",
                    PessoaId = "João"
                },
                new {
                    Id = 4,
                    DataHora = DateTime.Parse("2020-08-09 22:00:00.000"),
                    Descricao = "Fim Dia 2 (modelos e persistencia)",
                    PessoaId = "João"
                },
                new
                {
                    Id = 5,
                    DataHora = DateTime.Parse("2020-08-10 19:00:00.000"),
                    Descricao = "Inicio Dia 3",
                    PessoaId = "João"
                },
                new {
                    Id = 6,
                    DataHora = DateTime.Parse("2020-08-10 22:00:00.000"),
                    Descricao = "Fim Dia 3 (Persistencia, migrations e dbs)",
                    PessoaId = "João"
                },
                new
                {
                    Id = 7,
                    DataHora = DateTime.Parse("2020-08-11 20:00:00.000"),
                    Descricao = "Inicio Dia 4",
                    PessoaId = "João"
                },
                new {
                    Id = 8,
                    DataHora = DateTime.Parse("2020-08-11 22:00:00.000"),
                    Descricao = "Fim Dia 4 (Seeds, Rotas e Testes)",
                    PessoaId = "João"
                },
                new
                {
                    Id = 9,
                    DataHora = DateTime.Parse("2020-08-12 12:00:00.000"),
                    Descricao = "Inicio Dia 5",
                    PessoaId = "João"
                },
                new {
                    Id = 10,
                    DataHora = DateTime.Parse("2020-08-08 15:00:00.000"),
                    Descricao = "Fim Dia 5 (Bug Fixes, Remoção testes e Pipeline CD não implementados, Commit)",
                    PessoaId = "João"
                }
                );
            
            #endregion
        }

        /// <summary>
        /// Função para simplificar a configuração, garantindo que a geração dos migrations usando o contexto do driver
        /// relevante.
        /// Não foi usado a injeção das configurações devido a restrições do Entity Framework.
        /// </summary>
        /// <param name="engine"></param>
        /// <exception cref="Exception"></exception>
        protected void ObterDadosConexao(string engine)
        {
            // Se não setamos o tipo do banco, retornamos uma exceção
            if (engine == "")
                throw new Exception("Database engine not specified!");

#if DEBUG
            var confs = File.ReadAllText("..\\..\\..\\Application\\Application.API\\appsettings.Development.json");
#else
            var confs = File.ReadAllText("..\\..\\..\\Application\\Application.API\\appsettings.json");
#endif

            // TODO: Buscar configurações no momento do deploy

            var json =
                JsonConvert
                    .DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(confs);

            // TODO: Tratar a busca das propriedades de conexão de forma a evitar erros de parsing e campos desnecessários.
            server = json["database"][engine]["server"];
            port = json["database"][engine]["port"];
            database = json["database"][engine]["db"];
            username = json["database"][engine]["username"];
            password = json["database"][engine]["password"];
        }
    }
}