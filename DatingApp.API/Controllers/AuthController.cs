using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo )
        {
            _repo = repo;
        }

        [HttpPost("register")]
        //use [FromBody] if not using API controller
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //Validate Request if not using API controller
            //if(!ModelState.IsValid)
            //return BadRequest(ModelState);
            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
            return BadRequest("Username already Exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}