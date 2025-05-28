// UsersController.cs
using Microsoft.AspNetCore.Mvc;
using blackfy_API.Models;
using blackfy_API.Services; 

namespace blackfy_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var result = await userService.CreateUserAsync(user);

            return result ? Ok("User criado!") : StatusCode(500, "Erro ao criar User...");
        }
    }
}