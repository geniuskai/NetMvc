using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Buddhism.Service.IServices.Security;
using StackExchange.Profiling;
using StackExchange.Profiling.MVCHelpers;

namespace Buddhism.Mvc.Environment
{
    public class DefaultHost : IHost
    {
        private HttpApplication _application;

        public DefaultHost(HttpApplication application)
        {
            this._application = application;


            _application.BeginRequest += (object sender, EventArgs e) =>
            {
                if (application.Request["miniprofiler"] == "true")
                    MiniProfiler.Start();
                MiniProfilerEF.InitializeEF42();
            };
            _application.EndRequest += (object sender, EventArgs e) =>
            {
                MiniProfiler.Stop();
            };
            //处理登陆用户，保存角色等操作
            _application.AuthorizeRequest += (object sender, EventArgs e) =>
            {
                var user = HttpContext.Current.User;
                if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
                {
                    var userroleRepository = DependencyResolver.Current.GetService<IUserService>();
                    //var roleArray = userroleRepository.UserRoleIds(user.Identity.Name);
                    HttpContext.Current.User = new GenericPrincipal(
                        user.Identity,
                        null
                    );
                };
            };
        }

        public void Initialize(Action<ContainerBuilder> registrations = null)
        {
            InitMiniProfile();

            //var builder = RegisterService();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
            //if (registrations != null) registrations(builder);
            //var container = builder.Build();

            //// DependencyResolver
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private object RegisterService()
        {
            throw new NotImplementedException();
        }

        public void ReloadExtensions()
        {
            throw new NotImplementedException();
        }

        public void BeginRequest()
        {
            throw new NotImplementedException();
        }

        public void EndRequest()
        {
            throw new NotImplementedException();
        }

        private void InitMiniProfile()
        {
            //Setup profiler for Controllers via a Global ActionFilter
            GlobalFilters.Filters.Add(new ProfilingActionFilter());


            // initialize automatic view profiling
            var copy = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();
            foreach (var item in copy)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            }
        }
        //private void Regists(ContainerBuilder builder)
        //{
        ////    builder.RegisterType<EmptyRoleService>().As<IRoleService>();
        //}

    }
}
