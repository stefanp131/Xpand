using System.Threading.Tasks;
using Xpand.DATA.Entities;

namespace Xpand.API.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}