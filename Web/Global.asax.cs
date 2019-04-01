using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Infrastructure;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string[] assemblys = ConfigurationManager.AppSettings["IocAssemblys"]?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            IocManager.RegisterIocContainer(assemblys);
        }
    }
}
