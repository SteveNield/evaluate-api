﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.Windsor;
using Newtonsoft.Json;
using Winter.Core.Auth;
using Winter.Core.DependencyInversion.WebApi;

namespace Evaluate.Api.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            MapRoutes(config);
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            config.MessageHandlers.Add(new JwtAuthHandler());

            RegisterControllerActivator(container);
        }

        private static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
        }

        private static void MapRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
