using Autofac;
using Shop.Application.Features.ProductFeature;
using Shop.Domain.Features.ProductFeature;

namespace Shop.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManagementService>().As<IProductManagementService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}