using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using LibraryProject.WebAPI.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.WebAPI.Controllers
{
   [Route("api/[controller]")]
   public class BooksController : Controller
   {
      IBookManager bookManager;
      private IMapper mapper;
      public BooksController(IBookManager manager, IMapper mapper)
      {
         bookManager = manager;
         this.mapper = mapper;
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
      public IActionResult AddBook(BookDTO b)
      {
         if (ModelState.IsValid)
         {
            var book = mapper.Map<book>(b);
            bookManager.Add(book);
            return StatusCode(201);
         }
         return BadRequest();
      }
      [HttpPut("UpdateBook")]
      public IActionResult UpdateBook(BookDTO b)
      {
         if (ModelState.IsValid)
         {
            var book = mapper.Map<book>(b);
            var modifiedBook = bookManager.GetByName(book.name);
            if (modifiedBook != null)
            {
               bookManager.Update(modifiedBook);
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
            var book = mapper.Map<book>(b);
            var deletedBook = bookManager.GetByName(book.name);         
            if (deletedBook != null)
            {
               bookManager.Delete(deletedBook);
               return StatusCode(200);
            }
            else
               return NotFound();
         }
         return BadRequest();
      }
   }
}