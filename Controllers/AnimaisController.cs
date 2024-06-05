using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly IAnimaisRepositorio _animaisRepositorio;

        public AnimaisController(IAnimaisRepositorio animaisRepositorio)
        {
            _animaisRepositorio = animaisRepositorio;
        }

        [HttpGet("GetAllAnimais")]
        public async Task<ActionResult<List<AnimaisModel>>> GetAllAnimais()
        {
            List<AnimaisModel> animais = await _animaisRepositorio.GetAll();
            return Ok(animais);
        }

        [HttpGet("GetAnimalId/{id}")]
        public async Task<ActionResult<AnimaisModel>> GetAnimalId(int id)
        {
            AnimaisModel animal = await _animaisRepositorio.GetById(id);
            return Ok(animal);
        }

        [HttpPost("CreateAnimal")]
        public async Task<ActionResult<AnimaisModel>> InsertAnimal([FromBody] AnimaisModel animalModel)
        {
            AnimaisModel animal = await _animaisRepositorio.InsertAnimal(animalModel);
            return Ok(animal);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<AnimaisModel>> UpdateAnimal(int id, [FromBody] AnimaisModel animalModel)
        {
            animalModel.AnimaisId = id;
            AnimaisModel animal = await _animaisRepositorio.UpdateAnimal(animalModel, id);
            return Ok(animal);
        }

        [HttpDelete("DeleteAnimal/{id:int}")]
        public async Task<ActionResult<AnimaisModel>> DeleteAnimal(int id)
        {
            bool deleted = await _animaisRepositorio.DeleteAnimal(id);
            return Ok(deleted);
        }
    }
}
