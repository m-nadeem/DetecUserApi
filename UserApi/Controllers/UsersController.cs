// Controllers/UsersController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "John Doe", Email = "john@example.com", Address = "123 Main St" },
        new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Address = "456 Elm St" }
    };
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get() => Users;

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}