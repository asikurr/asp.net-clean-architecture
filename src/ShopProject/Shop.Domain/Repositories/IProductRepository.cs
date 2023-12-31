using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
        Task<(IList<Product> records, int total, int totalDisplay)>
             GetTableDataAsync(string searchText, uint priceFrom, uint priceTo, string sortby, int pageIndex, int pageSize);

    }
}
