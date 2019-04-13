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
      private readonly AppSettings appSettings;
      public AccountsController(IUserManager userManager, IOptions<AppSettings> appSettings)
      {
         this.userManager = userManager;
         this.appSettings = appSettings.Value;
      }
      [HttpGet]
      public IActionResult Login([FromBody]UserDTO userDTO)
      {
         var user = userManager.Authanticate(userDTO.username, userDTO.password);
         if (user == null)
            return NotFound("Username or password is incorrect");

         TokenHelper tokenHelper = new TokenHelper();
         var token= tokenHelper.GenerateToken(user);

         return Ok(new UserDTO
         {
            username=user.username,
            password=user.password,
            token = token
         });
      }

      
   }
}
