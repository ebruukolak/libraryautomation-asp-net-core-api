using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
    public class UsersController:Controller
    {
      IUserManager userManager;

      public UsersController(IUserManager userManager)
      {
         this.userManager = userManager;
      }

      [HttpGet]
      [Route("GetUserList")]
      public IActionResult GetUserList()
      {
         var users = userManager.GetUsers();
         if (users.Count()> 0)
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
      public ActionResult AddUser(user u)
      {
         if (ModelState.IsValid)
         {
            userManager.Add(u);
            return StatusCode(201);
         }
         return BadRequest();
      }

      [HttpPut]
      [Route("UpdateUser")]
      public IActionResult UpdateUser(user u)
      {
         if (ModelState.IsValid)
         {
            var user = userManager.GetByID(u.id);
            if (user != null)
            {
               userManager.Update(user);
               return StatusCode(202);
            }
            else
               return NotFound();

         }
         return BadRequest();
      }

      [HttpDelete]
      [Route("DeleteUser")]
      public IActionResult DeleteUser(user u)
      {
         if (ModelState.IsValid)
         {
            var user = userManager.GetByID(u.id);
            if (user != null)
            {
               userManager.Delete(user);
               return StatusCode(200);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
   }
}
