using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.DTO;
using OnlineShopping.Models;
using OnlineShopping.Repository.Interfaces;
using OnlineShopping.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUserDTO)
        {

            var userResult = await _unitOfWork.UserAuth.Login(loginUserDTO.PhoneNumber, loginUserDTO.Password);
            if (userResult == null)
                return Unauthorized();
         
            var claims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name, userResult.UserName),
                new Claim(ClaimTypes.Email , userResult.Email),
                new Claim(ClaimTypes.NameIdentifier, userResult.ID.ToString()),
                new Claim(ClaimTypes.MobilePhone, userResult.PhoneNumber)
            };
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes((_configuration["AppSettings:Token"].ToString())));
            var signer = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDecrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signer
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDecrptor);


            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {
          
            if (!await _unitOfWork.UserAuth.UserExist(registerUserDTO.Phone))
            {
                return BadRequest("The user already exist");
            }

            var userResult = await _unitOfWork.UserAuth.Registration(new AppUser()
            {
                Email = registerUserDTO.Email,
                PhoneNumber = registerUserDTO.Phone,
                IsDeleted = false,
                UserName = registerUserDTO.UserName
            }, registerUserDTO.Password);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userResult.UserName),
                new Claim(ClaimTypes.Email , userResult.Email),
                new Claim(ClaimTypes.NameIdentifier, userResult.ID.ToString()),
                new Claim(ClaimTypes.MobilePhone, userResult.PhoneNumber)
            };
            var key = new SymmetricSecurityKey(Encoding.Unicode.GetBytes((_configuration["AppSettings:Token"].ToString())));
            var signer = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDecrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signer
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDecrptor);


            return Ok(new { token = tokenHandler.WriteToken(token) });


           
        }
    }
}
