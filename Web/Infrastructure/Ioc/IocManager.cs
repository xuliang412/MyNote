using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Web.Infrastructure
{
    public class IocManager
    {
        private static IWindsorContainer _container;

        static IocManager()
        {
            _container = new WindsorContainer();
        }

        public static void RegisterIocContainer(params string[] assemblys)
        {
            assemblys?.ToList().ForEach(assembly =>
            {
                _container.Install(FromAssembly.Named(assembly));
            });
        }

        public static T Rosolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}