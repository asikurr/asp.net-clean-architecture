using Autofac;
using Shop.Domain.Features.ProductFeature;

namespace Shop.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        private readonly IProductManagementService _productManagementService;
        private ILifetimeScope _scope;
        public string ProductTitle { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public ProductCreateModel() { }

        public ProductCreateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _scope.Resolve<IProductManagementService>();
        }
        public async Task CreateProductAsync()
        {
            await _productManagementService.CreateProductAsync(ProductTitle, Description, Price);
        }

    }
}
