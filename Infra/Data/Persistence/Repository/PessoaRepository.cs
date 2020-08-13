using System.Collections.Generic;
using System.Linq;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa, string>, IPessoaRepository
    {
        public PessoaRepository(BaseContext context) : base(context)
        {
        }

        public void Save(Pessoa obj)
        {
            base.Insert(obj);
        }

        public void Remove(string id) => base.Delete(id);

        public void Remove(Pessoa obj) => base.Delete(obj);

        public Pessoa GetById(string id) => base.Select(id);

        public IList<Pessoa> GetAll() => base.Select();

        /// <summary>
        /// Buscamos os nomes pelo nome parcial, para permitir o autocomplete da busca.
        /// </summary>
        /// <param name="idParcial"></param>
        /// <returns></returns>
        public IList<Pessoa> GetAllLike(string idParcial)
        {
            return _context.Pessoas
                .Include(p => p.Marcacoes)
                .Where(p => EF.Functions.Like(p.Id, $"%{idParcial}%"))
                .ToList();
        }
    }
}