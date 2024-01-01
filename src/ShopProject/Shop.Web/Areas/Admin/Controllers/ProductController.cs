using Autofac;
using FirstDemo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Areas.Admin.Models;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ILifetimeScope _scope;

        public ProductController(ILogger<ProductController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
           var model = _scope.Resolve<ProductCreateModel>();
           return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.CreateProductAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> GetProducts(ProductListModel model)
        {
            var dataTablesUtility = new DataTablesAjaxRequestUtility(Request);
            model.Resolve(_scope);
            var data = await model.GetProductPagesAsync(dataTablesUtility);
            return Json(data);
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            await model.GetProductByIdAsync(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            model.Resolve(_scope);
            if (ModelState.IsValid)
            {
                await model.ProductUpdateAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _scope.Resolve<ProductListModel>();
            if (ModelState.IsValid)
            {
               await model.DeleteProductAsync(id);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
