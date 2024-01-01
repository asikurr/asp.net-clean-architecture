using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Features.ProductFeature
{
    public interface IProductManagementService
    {
        Task CreateProductAsync(string productTitle, string description, uint price);
        Task <(IList<Product> products, int total, int totalDisplay)>
            GetProductPagesAsync(int pageIndex, int pageSize, string searchText, uint priceFrom, uint priceTo, string sortby);
        Task<Product> GetProductAsync(Guid id);
        Task UpdateProductAsync(Guid id, string title,  string description, uint price);
        Task DeleteProductAsync(Guid id);

    }
}
