using System.Collections;
using System.Collections.Generic;
using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model.Interfaces
{
    public interface IPessoaRepository
    {
        void Save(Pessoa obj);

        void Remove(string id);
        
        void Remove(Pessoa obj);

        Pessoa GetById(string id);

        IList<Pessoa> GetAll();
        
        IList<Pessoa> GetAllLike(string idParcial);

        DbSet<Pessoa> Set();
    }
}