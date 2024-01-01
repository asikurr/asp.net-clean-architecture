using Shop.Domain.Entities;
using Shop.Domain.Features.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.ProductFeature
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly IApplicationUnitOfWork _unitofWork;
        public ProductManagementService(IApplicationUnitOfWork unitofWork) 
        { 
            _unitofWork = unitofWork;
        }

        public async Task CreateProductAsync(string productTitle, string description, uint price)
        {
            Product product = new Product()
            {
                ProductTitle = productTitle,
                Description = description,
                Price = price
            };
           await _unitofWork.ProductRepository.AddAsync(product);
            await _unitofWork.SaveAsync();
        }

        public async Task<(IList<Product> products, int total, int totalDisplay)> 
            GetProductPagesAsync(int pageIndex, int pageSize, string searchText, uint priceFrom, uint priceTo, string sortby)
        {
           return await _unitofWork.ProductRepository.GetTableDataAsync(searchText, priceFrom, priceTo,sortby, pageIndex, pageSize);
        }


        public async Task<Product> GetProductAsync(Guid id)
        {
            return await _unitofWork.ProductRepository.GetByIdAsync(id);
            
        }

        public async Task UpdateProductAsync(Guid id, string title, string description, uint price)
        {
            var data = await GetProductAsync(id);
            if (data is not null)
            {
                data.ProductTitle = title;
                data.Description = description;
                data.Price = price;
            }
            await _unitofWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _unitofWork.ProductRepository.RemoveAsync(id);
            await _unitofWork.SaveAsync();
        }
    }
}
