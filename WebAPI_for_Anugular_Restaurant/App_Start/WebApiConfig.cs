using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer;
using Microsoft.Practices.Unity;
using WebAPI_for_Anugular_Restaurant.App_Start;

namespace WebAPI_for_Anugular_Restaurant
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //for using unity and dependency injection
            var container = new UnityContainer();
            container.RegisterType<IServiceLayer, ServiceLayer>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}/{id}",
            new { id = RouteParameter.Optional });
        }
    }
}
