using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebAPI.Controllers
{
   [Route("api/[controller]")]
   public class StudentBooksController : Controller
   {
      IStudentsBookManager studentsBookManager;
      public StudentBooksController(IStudentsBookManager manager)
      {
         studentsBookManager = manager;
      }
      [HttpPost("AddStudentBook")]
      public IActionResult AddStudentBook(studentBook sb)
      {
         if(ModelState.IsValid)
         {
            studentsBookManager.Add(sb);
            return StatusCode(201);
         }
         return BadRequest();
      }
      [HttpPut("UpdateStudentBook")]
      public IActionResult UpdateStudentBook(studentBook sb)
      {
         if (ModelState.IsValid)
         {
            var studentBook = studentsBookManager.GetByID(sb.id);
            if (studentBook != null)
            {
               studentsBookManager.Update(studentBook);
               return StatusCode(202);
            }
            else
               return NotFound();

         }
         return BadRequest();
      }
      [HttpDelete("DeleteStudentBook")]
      public IActionResult DeleteStudentBook(studentBook sb)
      {
         if (ModelState.IsValid)
         {
            var studentBook = studentsBookManager.GetByID(sb.id);
            if (studentBook != null)
            {
               studentsBookManager.Delete(studentBook);
               return StatusCode(200);
            }
            else
               return NotFound();

         }
         return BadRequest();
      }
   }
}