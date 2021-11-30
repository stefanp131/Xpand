using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Xpand.API.Models;
using Xpand.DATA.IRepositories;

namespace Xpand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetsRepository planetsRepository;
        private readonly IMapper mapper;

        public PlanetsController(IPlanetsRepository planetsRepository, IMapper mapper)
        {
            this.planetsRepository = planetsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlanets() 
        {
            var planets = await this.planetsRepository.GetPlanets();

            if (planets.Any()) {
                return Ok(planets);
            }

            return NoContent();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlanet([FromRoute] int id, [FromBody] PlanetDto planetDto) 
        {
            var planet = await this.planetsRepository.GetPlanetById(id);

            this.mapper.Map(planetDto, planet);

            this.planetsRepository.Update(planet);

            if (await this.planetsRepository.Complete()) return Ok(planet);

            return BadRequest("Failed to update planet");
        }
        
    }
}