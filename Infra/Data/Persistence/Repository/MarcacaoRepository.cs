using System.Collections.Generic;
using System.Linq;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class MarcacaoRepository : BaseRepository<Marcacao, int>, IMarcacaoRepository
    {
        public MarcacaoRepository(BaseContext context) : base(context)
        {
        }
        
        public void Save(Marcacao obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj);
        }

        public void Remove(int id) => base.Delete(id);

        public void Remove(Marcacao obj) => base.Delete(obj);

        public Marcacao GetById(int id) => base.Select(id);

        public IList<Marcacao> GetAll() => base.Select();

        // Buscamos as marcações da pessoa
        public IList<Marcacao> GetAllByPessoa(string pessoaId)
        {
            // TODO: Usar o contexto da pessoa e trazer a lista
            return _context.Marcacoes.Where(x => x.Pessoa.Id == pessoaId).ToList();
        }
    }
}