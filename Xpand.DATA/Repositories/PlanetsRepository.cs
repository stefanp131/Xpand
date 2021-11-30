using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xpand.DATA.DataContext;
using Xpand.DATA.Entities;
using Xpand.DATA.IRepositories;

namespace Xpand.DATA.Repositories
{
    public class PlanetsRepository : IPlanetsRepository
    {
        private readonly XpandContext xpandContext;

        public PlanetsRepository(XpandContext xpandContext)
        {
            this.xpandContext = xpandContext;
        }

        public async Task<List<Planet>> GetPlanets()
        {
            return await xpandContext.Planets.ToListAsync();
        }

        public void Update(Planet planet)
        {
            this.xpandContext.Entry(planet).State = EntityState.Modified;
        }

        public async Task<Planet> GetPlanetById(int id)
        {
            return await this.xpandContext.Planets.FindAsync(id);
        }

        public async Task<bool> Complete()
        {
            return await this.xpandContext.SaveChangesAsync() > 0;
        }
    }
}