
using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
    public interface IBookManager
    {
      Book GetByID(int ID);
      IEnumerable<Book> GetBooks();
      long Add(Book book);
      bool Update(Book book);
      bool Delete(Book book);
      
    }
}
