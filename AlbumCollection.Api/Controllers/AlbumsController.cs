﻿using System.Threading.Tasks;
using System.Web.Http;
using AlbumCollection.Domain;
using AlbumCollection.Services.Repo;

namespace AlbumCollection.Api.Controllers {
    [RoutePrefix("api/Albums")]
    public class AlbumsController : ApiController {
        private IAlbumRepo albumRepo;

        public AlbumsController(IAlbumRepo albumRepo) {
            this.albumRepo = albumRepo;
        }

        [Route("{id:int?}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id = "") {
            id = "e6bc2763-c64f-44bd-9c5a-73322de6518e";
            
            Album album = await this.albumRepo.LoadAsync(id);
            return Ok(album);
        }
    }
}