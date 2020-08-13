using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        protected readonly BaseContext _context;

        // Usei o tipo supertipo do contexto para permitir o uso de DB váriados, como (Oracle e MSSQL, por ex.)...
        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        protected virtual void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        protected virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        protected virtual void Delete(TKeyType id)
        {
            _context.Set<TEntity>().Remove(Select(id));
            _context.SaveChanges();
        }

        protected virtual void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        protected virtual IList<TEntity> Select() =>
            _context.Set<TEntity>().ToList();

        protected virtual TEntity Select(TKeyType id) =>
            _context.Set<TEntity>().Find(id);

        public DbSet<TEntity> Set() => _context.Set<TEntity>();
    }
}