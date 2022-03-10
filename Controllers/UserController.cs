using Microsoft.AspNetCore.Mvc;
using NetMicroserviceTemplate.Data;

namespace NetMicroserviceTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase{
  private readonly UserDbContext _userDbContext;

  public UserController(UserDbContext userDbContext){
      _userDbContext = userDbContext;
  }

[HttpGet]
public async Task<IActionResult> GetUserByIdAsync(int id)
{
	var user = await _userDbContext.User.FindAsync(id);
	return Ok(user);
}
}