using Microsoft.EntityFrameworkCore;
using Shop.Application;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IProductRepository product) 
            : base((DbContext)dbContext)
        {
            ProductRepository = product;
        }

    }
}
