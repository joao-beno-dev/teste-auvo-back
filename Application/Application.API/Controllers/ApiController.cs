using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Repository;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMarcacaoRepository _marcacaoRepository;

        public ApiController(ILogger<ApiController> logger,
            IPessoaRepository pessoaRepository, IMarcacaoRepository marcacaoRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            _marcacaoRepository = marcacaoRepository;
        }

        /// <summary>
        /// Retorna todas as marcações, sem filtragem.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Marcacao> Get()
        {
            // TODO: Usar o _marcacaoRepository.GetAll()...
            var marcacoes = _pessoaRepository
                .Set()
                .Include(p => p.Marcacoes)
                .ToList()
                .Select(p => p.Marcacoes)
                .Aggregate((i, j) => i.Concat(j).ToList())
                .ToList();
            
            // Eliminando referencia ciclica...
            marcacoes.ForEach(m => m.Pessoa.Marcacoes = null);
            return marcacoes;
        }
        
        /// <summary>
        /// Recebe um nome parcial ou nome, e acha as pessoas que batem com a string, com suas respectivas marcações
        /// </summary>
        /// <param name="nomePessoa"></param>
        /// <returns></returns>
        [HttpGet("{nomePessoa}")]
        public IEnumerable<Pessoa> GetPessoas(string nomePessoa)
        {
            var pessoas = _pessoaRepository.GetAllLike(nomePessoa).ToList();
            pessoas.ForEach(p =>
            {
                var ms = p.Marcacoes.ToList();
                ms.ForEach(m => m.Pessoa = null);
                p.Marcacoes = ms;
            });

            return pessoas;
        }
        
        /// <summary>
        /// Recebe um nome a cria uma nova marcaçao
        /// </summary>
        /// <param name="nomePessoa"></param>
        /// <param name="obs"></param>
        /// <returns></returns>
        [HttpPost("{nomePessoa}/BaterPonto")]
        public object PostMarcacao(string nomePessoa, string obs)
        {
            try
            {
                var pessoa = _pessoaRepository.GetById(nomePessoa);

                var marcacao = new Marcacao
                {
                    Id = 0,
                    DataHora = DateTime.Now,
                    Descricao = obs,
                    Pessoa = pessoa
                };
                
                _marcacaoRepository.Save(marcacao);

                return new { Sucesso = "true" };
            }
            catch (Exception e)
            {
                throw new Exception("Pessoa não encontrada");
            }
        }
        
        /// <summary>
        /// Recebe um nome a cria uma nova pessoa
        /// </summary>
        /// <param name="nomePessoa"></param>
        /// <returns></returns>
        [HttpPost("NovaPessoa/{nomePessoa}")]
        public object AddPessoa(string nomePessoa)
        {
            try
            {
                var pessoa = new Pessoa
                {
                    Id = nomePessoa
                };
                
                _pessoaRepository.Save(pessoa);

                return new { Sucesso = "true" };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar pessoa");
            }
        }

        #region ManuseioDeErros
        
        /// <summary>
        /// Queremos retornar apenas erros em JSON...
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [Route("/error-local-development")]
        public JsonResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return new JsonResult(Problem(
                    detail: context.Error.StackTrace,
                    title: context.Error.Message));
        }

        [Route("/error")]
        public JsonResult Error() => new JsonResult(Problem());
        
        #endregion
    }
    
}