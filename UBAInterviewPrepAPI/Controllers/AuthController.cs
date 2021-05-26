using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.ConfigModels;
using UBAInterviewPrepAPI.Models.Auth;
using UBAInterviewPrepAPI.Models.IdentityAuthDtos;

namespace UBAInterviewPrepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;


        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())


            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken
                (
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            var user = _mapper.Map<User>(userSignUpDto);
            var userCreatedResult = await _userManager.CreateAsync(user, userSignUpDto.Password);
            if (userCreatedResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            //if we got this far, there is an issue with user creation
            return Problem(userCreatedResult.Errors.First().Description, null, 500);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginDto.Email);
            if(user is null)
            {
                return NotFound("User not found");
            }
            //user exists
            var userLoginResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (userLoginResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(GenerateJwt(user, roles));
            }

            return BadRequest("Email or password is incorrect");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleCreatedResult = await _roleManager.CreateAsync(newRole);
            if (roleCreatedResult.Succeeded)
            {
                return Ok();
            }

            return Problem(roleCreatedResult.Errors.First().Description, null, 500);
        }

        //Add a User to a Role
        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == userEmail);
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }
    }
}
