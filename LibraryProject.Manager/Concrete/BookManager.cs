using LibraryProject.DAL.Abstract;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
   public class BookManager : IBookManager
   {
      IBookDAL bookDAL;
      public BookManager(IBookDAL _bookDAL)
      {
         bookDAL = _bookDAL;
      }

      public Book GetByID(int ID)
      {
         return bookDAL.Get(ID);
      }
      public IEnumerable<Book> GetBooks()
      {
         return bookDAL.GetAll();
      }
      public long Add(Book book)
      {
         return bookDAL.Insert(book);
      }
      public bool Update(Book book)
      {
         return bookDAL.Update(book);
      }
      public bool Delete(Book book)
      {
         return bookDAL.Delete(book);
      }

     
   }
}
