using System;
using System.IO;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AlbumCollection.Infrastructure {
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute {
        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            HttpActionContext actionCtx = actionExecutedContext.ActionContext;
            HttpControllerContext controllerCtx = actionCtx.ControllerContext;

            string logMsg = string.Format("{0} - Web API exception occured. Controller = {1}, Action = {2}, Exception Message = {3}{4}",
                DateTime.Now, controllerCtx.ControllerDescriptor.ControllerName, actionCtx.ActionDescriptor.ActionName,
                actionExecutedContext.Exception.ToString(), Environment.NewLine);

            File.AppendAllText(Resource1.LogPath, logMsg);
        }
    }
}