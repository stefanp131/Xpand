using System.Collections.Generic;
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
            var entityPlanets = await this.planetsRepository.GetPlanets();

            if (!entityPlanets.Any()) {
                return NoContent();
            }

            var planets = this.mapper.Map<List<PlanetDto>>(entityPlanets);

            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlanetById(int id) 
        {
            var planet = await this.planetsRepository.GetPlanetById(id);

            if (planet != null) return  Ok(this.mapper.Map<PlanetDto>(planet));

            return NotFound();
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