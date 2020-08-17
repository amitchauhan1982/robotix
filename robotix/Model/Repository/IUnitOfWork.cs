using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotix.Model.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        AppDbContext Context { get; }
        void Commit();
    }
}
