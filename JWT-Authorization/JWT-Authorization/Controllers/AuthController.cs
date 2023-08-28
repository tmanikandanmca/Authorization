using JWT_Authorization.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authorization.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

    private readonly IConfiguration _configuration;
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Login(UserDTO userDetails)
    {
        if (userDetails.Email == string.Empty) return BadRequest("Emplty in User Email");

        var res = MOQUsers.AllUsers().FirstOrDefault(x => x.Email == userDetails.Email);

        if (res?.Email=="") return BadRequest("Emplty in User Email");
        return Ok(GenerateToken());
    }


    private string GenerateToken()
    {
        var claim = new Claim[]{ };

        string Data= _configuration.GetSection("JwtSettings:Issuser").Value;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value!)),
            SecurityAlgorithms.HmacSha256
            );
         

        var token = new JwtSecurityToken(
           "localhost",
           "localhost",
           claim,
           null,
           DateTime.UtcNow.AddHours(2),
           signingCredentials

            );

 
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
