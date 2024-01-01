using Autofac;
using Shop.Domain.Entities;
using Shop.Domain.Features.ProductFeature;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        private IProductManagementService _productService;
        private ILifetimeScope _scope;
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ProductTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public uint Price { get; set; }
        public ProductUpdateModel() { }

        public ProductUpdateModel(IProductManagementService productManagement)
        {
            _productService = productManagement;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productService = _scope.Resolve<IProductManagementService>();
        }
        public async Task GetProductByIdAsync(Guid id)
        {
            var data =  await _productService.GetProductAsync(id);
            if (data is not null)
            {
                Id = data.Id;
                ProductTitle = data.ProductTitle;
                Description = data.Description; 
                Price = data.Price;
            }
        }

        public async Task ProductUpdateAsync()
        {
            if (!string.IsNullOrWhiteSpace(ProductTitle))
            {
                await _productService.UpdateProductAsync(Id, ProductTitle, Description, Price);
            }
        }
    }
}
