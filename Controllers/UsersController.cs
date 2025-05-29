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
            try { 
                var users = await userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await userService.CreateUserAsync(user);

                return result ? Ok("User criado!") : StatusCode(500, "Erro ao criar User...");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await userService.DeleteUserById(id);
                return result ? Ok("User deletado!") : StatusCode(500, "Erro ao deletar User");
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await userService.UpdateUser(user, id);
                return result ? Ok("User alterado!") : StatusCode(500, "Erro ao atualizar User");
            } 
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}