using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundVault.Data.Repositories;
using SoundVault.Model.Entities;

namespace SoundVault.API.Controllers
{
    public class GendersController : BaseApiController
    {
        private readonly IGenderRepository _genderRepository;
        public GendersController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genderRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _genderRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] Gender gender)
        {
            if (gender == null)
                return BadRequest();

            if(gender.Name.Trim() == string.Empty)
                ModelState.AddModelError("Name", "Name is required");   

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _genderRepository.Add(gender);

            return Created("created", created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] Gender gender)
        {
            if (gender == null)
                return BadRequest();

            if (gender.Name.Trim() == string.Empty)
                ModelState.AddModelError("Name", "Name is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _genderRepository.Update(gender);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _genderRepository.Delete(id);
            return NoContent();
        }
    }
}
