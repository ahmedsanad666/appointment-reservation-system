using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace webapi.Controllers
{
    [Route("Arid/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private  readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _Configuration;
        private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
        public readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<ApiUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
            _userManager = userManager;
           _Configuration = configuration;
            _context   = context;
        }





        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] ApiUser apiUser)
        {
            var users = await _userManager.Users.ToListAsync();
            bool isFirstUser = users.Count == 0;
            string roleName = isFirstUser ? "Admin" : "User";
            var user = new ApiUser
            {   
              
                Email = apiUser.Email,
                UserName = apiUser.UserName,

                
            };
            IdentityRole role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }

            var result = await _userManager.CreateAsync(user, apiUser.Password);
            if (result.Succeeded)
            {

                //await _userManager.AddToRoleAsync(user, apiUser.Role);
                //await _userManager.AddToRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, roleName);
            }

          if(result.Errors.Any())
            {
                foreach( var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok(result);
        }



        [HttpPost]
        [Route("LogIn")]
        public async Task<ActionResult<AuthResponse>> LogIn([FromBody] ApiUser apiUser)
        {
    
          
                var user = await _userManager.FindByEmailAsync(apiUser.Email);
                var ValidPassword = await _userManager.CheckPasswordAsync(user, apiUser.Password);
                     var userId = user.Id;
                        

            if (ValidPassword)
            {



                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JwtSettings:Key"]));
             
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var roles = await _userManager.GetRolesAsync(apiUser);
                var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
                var userClaims = await _userManager.GetClaimsAsync(apiUser);
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub , apiUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                    new Claim("uid",userId)
                }.Union(userClaims).Union(roleClaims);

                var token = new JwtSecurityToken(
                    issuer: _Configuration["JwtSettings:Issuer"],
                    audience: _Configuration["JwtSettings:Audience"],
                    claims : claims,
                  expires: DateTime.Now.AddMinutes(Convert.ToInt32(_Configuration["JwtSettings:DurationInMinutes"])
                   ),
                  signingCredentials: credentials

                  );
               
             
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                int UseRole =0;
                if (isAdmin)
                {
                    UseRole = 1;
                }
                else
                {
                    UseRole = 0;

                }


                var userToken =  new JwtSecurityTokenHandler().WriteToken(token);
             var  AuthResponse = new  {
                 Token = userToken,
                UserId = userId,
                 Role = UseRole
             };

                return Ok(AuthResponse);

            }  else
            {

                return Unauthorized();
            }

         
            
           
           
        }

   
        









    }
}
