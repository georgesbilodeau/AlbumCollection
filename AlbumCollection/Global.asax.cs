using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AlbumCollection.Infrastructure;
using Microsoft.Practices.Unity;

namespace AlbumCollection {
    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            AreaRegistration.RegisterAllAreas();

            // set up MVC
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IUnityContainer container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityMvcDependencyResolver(container));

            // set up Web API
            WebApiConfig.AppContainer = container;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ApiExceptionFilterAttribute());
        }
    }
}