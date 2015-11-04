using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Evaluate.Api.Service.Controllers;
using Winter.Core.Auth;
using Winter.Core.DependencyInversion;
using Winter.Core.DependencyInversion.WebApi;

namespace Evaluate.Api.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _windsorContainer;

        private void BootstrapContainer()
        {
            var installers = new[]
            {
                FromAssembly.Containing<AuthInstaller>(),
                FromAssembly.This(),
                FromAssembly.Containing<DependencyInversionInstaller>()
            };
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(installers);
            _windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(_windsorContainer.Kernel, true));
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorResolver(_windsorContainer);
        }

        protected void Application_Start()
        {
            BootstrapContainer();
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, _windsorContainer));
        }
    }
}
