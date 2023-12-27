using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        public virtual void Dispose() => _dbContext?.Dispose();

        public async ValueTask DisposeAsync() =>await _dbContext.DisposeAsync();

        public virtual void Save() => _dbContext?.SaveChanges();

        public virtual async Task SaveAsync() => await _dbContext?.SaveChangesAsync();


    }
}
