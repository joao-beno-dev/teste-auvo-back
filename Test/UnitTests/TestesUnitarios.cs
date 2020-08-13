using System.Linq;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository;
using Xunit;

namespace UnitTests
{
    /// <summary>
    /// Normalmente os testes seriam quebrados em vários arquivos, cada qual com a sua
    /// responsabilidade, mas como o tempo é curto, acabei por fazer tudo consolidado em
    /// um unico arquivo...
    /// </summary>
    public class TestesUnitarios
    {
        #region Vars

        // Variaveis usadas em mais de um teste
        private static int _qtdMarcacoesJoao = 10;
        private static string _nome = "Alberto";

        #endregion
        
        /// <summary>
        /// Checando se estamos rodando um teste...
        /// </summary>
        [Fact]
        public void TesteEstaRodando()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Verificamos se temos todas as pessoas do seed inicial...
        /// </summary>
        [Fact]
        public void VerificarSeedPessoas()
        {
            var repo = GetInMemoryPessoaRepository();
            
            Assert.Collection(repo.GetAll(), 
                pessoa => Assert.Equal("João", pessoa.Nome),
                pessoa => Assert.Equal("Pedro", pessoa.Nome),
                pessoa => Assert.Equal("Vanessa", pessoa.Nome),
                pessoa => Assert.Equal("Karla", pessoa.Nome),
                pessoa => Assert.Equal("Maxwell", pessoa.Nome),
                pessoa => Assert.Equal("Maxine", pessoa.Nome),
                pessoa => Assert.Equal("Maxmiliano", pessoa.Nome),
                pessoa => Assert.Equal("Mario", pessoa.Nome)
                );
        }

        /// <summary>
        /// Testamos se temos dez marcações, conforme seed...
        /// </summary>
        [Fact]
        public void ContaQuantidadeDeMarcacoes()
        {
            var repo = GetInMemoryMarcacaoRepository();
            
            Assert.Equal(_qtdMarcacoesJoao, repo.GetAll().Count);
        }

        /// <summary>
        /// Testamos se o João tem 10 marcações...
        /// </summary>
        [Fact]
        public void ContaQuantidadeDeMarcacoesDoJoao()
        {
            var repo = GetInMemoryPessoaRepository();
            
            Assert.Equal(_qtdMarcacoesJoao, repo.Set().Include(p => p.Marcacoes)
                .First(p => p.Id == "João").Marcacoes.Count);
        }

        /// <summary>
        /// Verificamos se conseguimos criar uma nova pessoa...
        /// </summary>
        [Fact]
        public void CriarPessoa()
        {
            var repo = GetInMemoryPessoaRepository();
            
            repo.Save(new Pessoa { Id = _nome});
            
            Assert.Contains(repo.GetAll(), pessoa => pessoa.Nome == _nome);
        }
        
        // TODO: Criar os testes de rotas, e testes avançados usando theory...

        #region Metodos Auxiliares

        private IPessoaRepository GetInMemoryPessoaRepository()
        {
            var builder = new DbContextOptionsBuilder<BaseContext>();
            builder.UseInMemoryDatabase("TestDB");
            
            BaseContext baseContext = new BaseContext(builder.Options);
            baseContext.Database.EnsureDeleted();
            baseContext.Database.EnsureCreated();
            
            return new PessoaRepository(baseContext);
        }
        
        private IMarcacaoRepository GetInMemoryMarcacaoRepository()
        {
            var builder = new DbContextOptionsBuilder<BaseContext>();
            builder.UseInMemoryDatabase("TestDB");
            
            BaseContext baseContext = new BaseContext(builder.Options);
            baseContext.Database.EnsureDeleted();
            baseContext.Database.EnsureCreated();
            
            return new MarcacaoRepository(baseContext);
        }

        #endregion
    }
}