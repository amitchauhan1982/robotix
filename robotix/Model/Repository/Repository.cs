using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace robotix.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
       private AppDbContext _context;
        private DbSet<T> dbEntity;
        public Repository(AppDbContext Context)
        {
          _context = Context;
            //dbEntity = (IDbSet<T>)_context.Context.Set<T>();
            dbEntity = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbEntity.Add(entity);
        } 

        public void Delete(int Id)
        {
            T model = dbEntity.Find(Id);
            dbEntity.Remove(model);
        }

        public T Get(int Id)
        {
            return dbEntity.Find(Id);
        }

        public IEnumerable<T> Gets()
        {
            return dbEntity.ToList();
        }

        public void Update(T model)
        {
            _context.Entry(model).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
            _context.Set<T>().Attach(model);
        }
    }
}
