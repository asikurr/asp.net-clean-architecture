using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
