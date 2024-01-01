using Autofac;
using Shop.Web.Areas.Admin.Models;

namespace Shop.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCreateModel>().AsSelf();
            builder.RegisterType<ProductUpdateModel>().AsSelf();
            builder.RegisterType<ProductListModel>().AsSelf();
            base.Load(builder);
        }
    }
}
