using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVault.Data.Repositories;
using SoundVault.Model.Entities;

namespace SoundVault.API.Controllers
{
    public class AlbumsController : BaseApiController
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _albumRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _albumRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            if (album is null)
                return BadRequest();

            if (album.Title.Trim() == string.Empty)
                ModelState.AddModelError("Title", "Title is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _albumRepository.Add(album);

            return Created("created", created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] Album album)
        {
            if (album is null)
                return BadRequest();

            if (album.Title.Trim() == string.Empty)
                ModelState.AddModelError("Title", "Title is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _albumRepository.Update(album);

            return Created("created", created);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            await _albumRepository.Delete(id);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCover(Album album)
        {

            if (album is null || string.IsNullOrEmpty(album.Cover))
                return BadRequest("La portada no puede estar vacía.");

            var result = await _albumRepository.Update(album);

            if (!result)
                return NotFound($"Álbum con ID {album.Id} no encontrado.");

            return NoContent();
        }
    }
}
