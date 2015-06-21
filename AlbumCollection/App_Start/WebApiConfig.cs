using System.Web.Http;
using AlbumCollection.Infrastructure;
using Microsoft.Practices.Unity;

namespace AlbumCollection {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();

            config.DependencyResolver = new UnityApiDependencyResolver(AppContainer);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static IUnityContainer AppContainer { get; set; }
    }
}