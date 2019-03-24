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
   public class StudentsController : Controller
   {
      IStudentManager studentManager;

      public StudentsController(IStudentManager manager)
      {
         studentManager = manager;
      }

      [HttpGet]
      [Route("GetStudentList")]
      public IActionResult GetStudentList()
      {
         var students = studentManager.GetStudents();
         if (students.Count() > 0)
            return Ok(students);

         return BadRequest();
      }

      [HttpGet("{ID}")]
      public IActionResult GetStudent(int ID)
      {
         if (ID > 0)
            return Ok(studentManager.GetByID(ID));

         return BadRequest();
      }

      [HttpPost("AddStudent")]

      public ActionResult AddStudent(student student)
      {
         if (ModelState.IsValid)
         {
            studentManager.Add(student);
            return StatusCode(201);
         }
         return BadRequest();
      }

      [HttpPut]
      [Route("UpdateStudent")]
      public IActionResult UpdateStudent(student s)
      {
         if (ModelState.IsValid)
         {
            var student = studentManager.GetByID(s.id);
            if (student != null)
            {
               studentManager.Update(student);
               return StatusCode(202);
            }
            else
               return NotFound();

         }
         return BadRequest();
      }

      [HttpDelete]
      [Route("DeleteStudent")]
      public IActionResult DeleteStudent(student s)
      {
         if (ModelState.IsValid)
         {
            var student = studentManager.GetByID(s.id);
            if (student != null)
            {
               studentManager.Delete(student);
               return StatusCode(200);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
   }
}