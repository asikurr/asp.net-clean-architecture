using Autofac;
using Shop.Web.Areas.Admin.Models;

namespace Shop.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCreateModel>().AsSelf();
            base.Load(builder);
        }
    }
}
