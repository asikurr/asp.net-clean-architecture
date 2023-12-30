using Autofac;
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
    }
}
