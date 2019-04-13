using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using LibraryProject.WebAPI.Helpers;
using LibraryProject.WebAPI.ModelDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LibraryProject.WebAPI.Controllers
{
   [Route("api/[controller]")]
   public class AccountsController : Controller
   {
      IUserManager userManager;
      public AccountsController(IUserManager userManager)
      {
         this.userManager = userManager;
      }
      [HttpGet]
      public IActionResult Login([FromBody]LoginDTO userDTO)
      {
         var user = userManager.Authanticate(userDTO.username, userDTO.password);
         if (user == null)
            return NotFound("Username or password is incorrect");
         var userRole = userManager.GetUserRole(user.id);
         TokenHelper tokenHelper = new TokenHelper();
         var token= tokenHelper.GenerateToken(user,userRole.rolename);

         return Ok(new LoginDTO
         {
            username=user.username,
            password=user.password,
            token = token
         });
      }

      
   }
}
