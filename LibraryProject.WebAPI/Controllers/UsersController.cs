using AutoMapper;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using LibraryProject.WebAPI.Helpers;
using LibraryProject.WebAPI.ModelDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
   public class UsersController : Controller
   {
      IUserManager userManager;
      private IMapper mapper;
      private readonly PasswordKeys key;

      public UsersController(IUserManager userManager, IMapper mapper, IOptions<PasswordKeys> key)
      {
         this.userManager = userManager;
         this.mapper = mapper;
         this.key = key.Value;
      }

      [HttpGet]
      [Route("GetUserList")]
      public IActionResult GetUserList()
      {
         var users = userManager.GetUsers();
         if (users.Count() > 0)
            return Ok(users);

         return BadRequest();
      }

      [HttpGet("{ID}")]
      public IActionResult GetUser(int ID)
      {
         if (ID > 0)
            return Ok(userManager.GetByID(ID));

         return BadRequest();
      }

      [HttpPost("AddUser")]
      public ActionResult AddUser(UserDTO u)
      {
         if (ModelState.IsValid)
         {            
            var user = mapper.Map<user>(u);
            var ID = userManager.Add(user,u.password,key.KeyForPassword);
            if (ID > 0)
               userManager.AddRole(user.id, "Admin");
            return StatusCode(201);
         }
         return BadRequest();
      }

      [HttpPut]
      [Route("UpdateUser")]
      public IActionResult UpdateUser(UserDTO u)
      {
         if (ModelState.IsValid)
         {
            var user = mapper.Map<user>(u);
            var modifiedUser = userManager.GetByUsername(user.username);
            if (modifiedUser != null)
            {
               userManager.Update(modifiedUser,u.password,key.KeyForPassword);
               return StatusCode(202);
            }
            else
               return NotFound();

         }
         return BadRequest();
      }

      [HttpDelete]
      [Route("DeleteUser")]
      public IActionResult DeleteUser(UserDTO u)
      {
         if (ModelState.IsValid)
         {
            var user = mapper.Map<user>(u);
            var deletedUser = userManager.GetByUsername(user.username);
            if (deletedUser != null)
            {
               var id = deletedUser.id;
               var result = userManager.Delete(deletedUser);
               if (result)
                  userManager.DeleteUserRole(id);
               return StatusCode(200);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
   }
}
