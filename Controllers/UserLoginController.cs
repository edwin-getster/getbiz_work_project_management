using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly WorkProjectManagementAppDB_DbContext _DBContext;

        public UserLoginController(IConfiguration configuration, WorkProjectManagementAppDB_DbContext DBContext)
        {
            _configuration = configuration;
            _DBContext = DBContext;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] user_registeration login)  //login = this is variable all (Userdetail = table values) store in user variable
        {

            if (login.mobile_number != null && login.password != null)
            {
                var user = await GetUser(login.mobile_number, login.password);
                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id",user.id.ToString()),
                        new Claim("Mobile_No", user.mobile_number),
                        new Claim("Password", user.password),
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signIn);

                    user.authkey = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);                                                                           //[login] = this is variable all Userdetail table values store this variable
                    _DBContext.Update(user);
                    await _DBContext.SaveChangesAsync();

                    // return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    return new JsonResult(new
                    {
                        result = "success",

                        User_Id = user.user_id,
                        Text = user.text,
                        Mobile_No = user.mobile_number,
                        Password = user.password,
                        Photo_Id = user.photo_id,
                        User_Type = user.user_type,


                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    }); ;
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<user_registeration> GetUser(string Mobile_No, string Password)
        {
            return await _DBContext.user_registeration.FirstOrDefaultAsync(u => u.mobile_number == Mobile_No && u.password == Password);
        }


    }
}