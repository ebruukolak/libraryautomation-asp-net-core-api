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

      public book GetByID(int ID)
      {
         return bookDAL.Get(ID);
      }
      public IEnumerable<book> GetBooks()
      {
         return bookDAL.GetAll();
      }
      public long Add(book b)
      {
         return bookDAL.Insert(b);
      }
      public bool Update(book b)
      {
         return bookDAL.Update(b);
      }
      public bool Delete(book b)
      {
         return bookDAL.Delete(b);
      }

      public book GetByName(string name)
      {
         return bookDAL.GetByName(name);
      }
   }
}
