using API.Dto;
using API.Errors;
using AutoMapper;
using Core.Interfaces;
using Core.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper mapper;
        private readonly ClaimsPrincipal claimsPrincipal;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService,ClaimsPrincipal claimsPrincipal, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            this.mapper = mapper;
            claimsPrincipal = claimsPrincipal;
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var user = await _userManager.FindByEmailAsync(email);
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Displlayname = user.DisplayName

            };
        }


        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }


        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
           
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            var ret =  await _userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);


            return mapper.Map<Address, AddressDto>(ret.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto address)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            var ret = await _userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
            ret.Address = mapper.Map<AddressDto, Address>(address);
            var result = await _userManager.UpdateAsync(ret);
            if(result.Succeeded)
            {
                return Ok(mapper.Map<Address, AddressDto>(ret.Address));
                
            }
            return BadRequest("cant update");
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401) );
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Displlayname = user.DisplayName

            };
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }
            return new UserDto
            {
                Displlayname = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        //private  async Task<AppUser> FIndUserByClaimsPrincipleWithAddress(this UserManager<AppUser> user, ClaimsPrincipal claimsPrincipal)
        //{
        //    var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

        //    return await user.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        //}

        //private async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> userManager, ClaimsPrincipal claimsPrincipal)
        //{
        //    return await userManager.Users.SingleOrDefaultAsync(x => x.Email == claimsPrincipal.FindFirstValue(ClaimTypes.Email));
        //}

    }
}
