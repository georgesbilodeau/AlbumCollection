using System.Web.Http;

namespace AlbumCollection.Api.Controllers {
    [RoutePrefix("api/Albums")]
    public class AlbumsController : ApiController {
        [Route("{id:int?}")]
        [HttpGet]
        public IHttpActionResult Get(int id = 0) {
            // if no id passed, get random album
            if (id == 0) {

            }

            return Ok();
        }
    }
}