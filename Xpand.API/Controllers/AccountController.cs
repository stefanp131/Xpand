using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xpand.API.Interfaces;
using Xpand.API.Models;
using Xpand.DATA.Entities;

namespace Xpand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, ITokenService tokenService)
        {
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserDto registerUserDto)
        {
            if (await UserExists(registerUserDto.UserName)) return BadRequest("Username is taken");

            var appUser = this.mapper.Map<AppUser>(registerUserDto);

            appUser.UserName = registerUserDto.UserName.ToLower();

            var result = await this.userManager.CreateAsync(appUser, registerUserDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                UserName = appUser.UserName,
                Token = await this.tokenService.CreateToken(appUser)
            };
        }

        [HttpPost("login")]    
        public async Task<ActionResult<UserDto>> Login(LoginUserDto loginUserDto)
        {
            var user = await this.userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginUserDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            var result = await this.signInManager
                .CheckPasswordSignInAsync(user, loginUserDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                UserName = user.UserName,
                Token = await tokenService.CreateToken(user)    
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await this.userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}