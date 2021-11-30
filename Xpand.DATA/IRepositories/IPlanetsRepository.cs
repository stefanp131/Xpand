using System.Collections.Generic;
using System.Threading.Tasks;
using Xpand.DATA.Entities;

namespace Xpand.DATA.IRepositories
{
    public interface IPlanetsRepository
    {
        void Update(Planet planet);
        Task<List<Planet>> GetPlanets();
        Task<Planet> GetPlanetById(int id);
        Task<bool> Complete();
    }
}