using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Buddhism.EntityFramework;
using Buddhism.EntityFramework.Infrastructure;
using Buddhism.EntityFramework.Initializer;
using Buddhism.Library.Controllers;
using Buddhism.Service.Services.Security;

namespace Buddhism.Library
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var builder = RegisterService();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();            
        }
        private ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();
            // controllers
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            // auto
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.GetInterfaces().Length > 0)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            return builder;
        }
    }
}