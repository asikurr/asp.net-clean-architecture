using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> 
            GetTableDataAsync(string searchText, uint priceFrom, uint priceTo, string sortby, int pageIndex, int pageSize)
        {
            Expression<Func<Product, bool>> expression = null;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                expression = x => x.ProductTitle.Contains(searchText) && 
                (x.Price >= priceFrom && x.Price <= priceTo );
            }
            return await GetDynamicAsync(expression, sortby, null,pageIndex, pageSize, true);
        }
    }
}
