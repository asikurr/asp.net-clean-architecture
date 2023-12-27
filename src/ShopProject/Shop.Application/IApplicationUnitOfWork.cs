using Shop.Domain;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
