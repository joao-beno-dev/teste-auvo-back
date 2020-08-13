using System.Collections;
using System.Collections.Generic;
using Domain.Model.Entities;

namespace Domain.Model.Interfaces
{
    public interface IMarcacaoRepository
    {
        void Save(Marcacao obj);

        void Remove(int id);
        
        void Remove(Marcacao obj);

        Marcacao GetById(int id);

        IList<Marcacao> GetAll();

        IList<Marcacao> GetAllByPessoa(string pessoaId);
    }
}