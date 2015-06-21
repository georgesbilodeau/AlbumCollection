using System.Web.Mvc;

namespace AlbumCollection.Controllers {
    [RoutePrefix("Albums")]
    public class AlbumsController : Controller {
        [Route("~/")]       // GET /
        [Route]             // GET /Albums
        [Route("Index")]    // GET /Albums/Index
        public ViewResult Index() {
            return View();
        }
    }
}