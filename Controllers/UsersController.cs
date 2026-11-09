using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // Demo storage: data is reset whenever the application restarts.
    private static readonly List<User> Users =
    [
        new User { Id = 1, Name = "John", Email = "john@example.com", Age = 25 },
        new User { Id = 2, Name = "Alice", Email = "alice@example.com", Age = 30 }
    ];

    private static int _nextId = 3;

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers() => Ok(Users);

    [HttpGet("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return user is null ? NotFound("User not found") : Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        user.Id = _nextId++;
        Users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null) return NotFound("User not found");

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        user.Age = updatedUser.Age;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null) return NotFound("User not found");

        Users.Remove(user);
        return NoContent();
    }
}
