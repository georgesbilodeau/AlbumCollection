using System.Web.Http;
using AlbumCollection.Infrastructure;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;

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

            // ignore self-referencing loops when serializing entity data to JSON (i.e., Album.Artist.Albums)
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public static IUnityContainer AppContainer { get; set; }
    }
}