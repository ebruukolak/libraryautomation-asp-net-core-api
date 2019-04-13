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
   public class BooksController : Controller
   {
      IBookManager bookManager;

      public BooksController(IBookManager manager)
      {
         bookManager = manager;
      }
      [HttpGet("{ID}")]
      public IActionResult GetBook(int ID)
      {
         if (ID > 0)
            return Ok(bookManager);
         return BadRequest();
      }
      [HttpGet]
      public IActionResult GetBooks()
      {
         var books = bookManager.GetBooks();
         if (books.Count() > 0)
            return Ok(books);
         return BadRequest();
      }

      [HttpPost("AddBook")]
      public IActionResult AddBook(book b)
      {
         if (ModelState.IsValid)
         {
            bookManager.Add(b);
            return StatusCode(201);
         }
         return BadRequest();
      }
      [HttpPut("UpdateBook")]
      public IActionResult UpdateBook(book b)
      {
         if (ModelState.IsValid)
         {
            var book = bookManager.GetByID(b.id);
            if (book != null)
            {
               bookManager.Update(b);
               return StatusCode(202);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
      [HttpDelete("DeleteBook")]
      public IActionResult DeleteBook(book b)
      {
         if (ModelState.IsValid)
         {
            var book = bookManager.GetByID(b.id);
            if (book != null)
            {
               bookManager.Delete(b);
               return StatusCode(200);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
   }
}