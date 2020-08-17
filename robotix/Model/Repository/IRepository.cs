using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace robotix.Model.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Gets();
        T Get(int Id);
        void Add(T entity);
        void Delete(int Id);
        void Update(T model);
    }
}
