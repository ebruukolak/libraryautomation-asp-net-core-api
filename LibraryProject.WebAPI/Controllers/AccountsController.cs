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
      private readonly PasswordKeys key;
      private readonly AppSettings appSettings;
      public AccountsController(IUserManager userManager,IOptions<PasswordKeys> key, IOptions<AppSettings> appSettings)
      {
         this.userManager = userManager;
         this.key = key.Value;
         this.appSettings = appSettings.Value;
      }
      [HttpPost]
      public IActionResult Login(LoginDTO userDTO)
      {
         var user = userManager.Authanticate(userDTO.username, userDTO.password,key.KeyForPassword);
         if (user == null)
            return NotFound("Username or password is incorrect");
         var userRole = userManager.GetUserRole(user.id);
         var token= TokenHelper.GenerateToken(user,userRole.rolename,appSettings.Secret);

         return Ok(new LoginDTO
         {
            username=user.username,
            password=user.password,
            token = token
         });
      }

      
   }
}
