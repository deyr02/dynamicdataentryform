using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            this._tokenService = tokenService;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return Unauthorized("Invalid email");

            //if (!user.EmailConfirmed) return Unauthorized("Email not confirmed");

            //var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded)
            {
                //await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);
                return await CreateUserDto(user);
            }
            return Unauthorized("Invlaid Password");
        }

        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email already taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                return BadRequest("User Name already taken");
            }
            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var userResult = await _userManager.CreateAsync(user, registerDto.Password);
            var roleResult = await _userManager.AddToRoleAsync(user, "Creator");
            if (userResult.Succeeded && roleResult.Succeeded)
            {
                return await CreateUserDto(user);
            }
            return BadRequest("Problem Retistering new user");
        }




        private async Task<UserDto> CreateUserDto(AppUser user)
        {
            var approle = await _userManager.GetRolesAsync(user);
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                ProfilePicture = user.ProfilePicture,
                Token = await _tokenService.CreateToken(user)
            };
        }


    }
}