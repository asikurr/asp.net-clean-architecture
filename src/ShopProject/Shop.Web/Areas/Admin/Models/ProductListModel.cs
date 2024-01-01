using Autofac;
using FirstDemo.Infrastructure;
using Shop.Domain.Features.ProductFeature;
using System.Text.Encodings.Web;
using System.Web;

namespace Shop.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private IProductManagementService _productService;
        private ILifetimeScope _scope;
        public ProductSearch ProductSearch { get; set; }

        public ProductListModel() { }

        public ProductListModel(IProductManagementService productService)
        {
            _productService = productService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productService = _scope.Resolve<IProductManagementService>();
        }
        public async Task<object> GetProductPagesAsync(DataTablesAjaxRequestUtility dataUtility)
        {
            var data = await _productService.GetProductPagesAsync(
                     dataUtility.PageIndex,
                     dataUtility.PageSize,
                     ProductSearch.Title,
                     ProductSearch.FromPrice,
                     ProductSearch.ToPrice,
                     dataUtility.GetSortText(new string[] { "ProductTitle", "Description", "Price" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from product in data.products
                        select new string[]
                        {
                           HttpUtility.HtmlEncode(product.ProductTitle),
                           HttpUtility.HtmlEncode( product.Description),
                            product.Price.ToString(),
                            product.Id.ToString()
                        }
                )
            };
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productService.DeleteProductAsync(id);
        }
    }
}
