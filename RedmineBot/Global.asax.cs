using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;

namespace RedmineBot
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<MessagesController>().InstancePerRequest();

            builder.RegisterWebApiFilterProvider(config);
            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());            
        }
    }
}
