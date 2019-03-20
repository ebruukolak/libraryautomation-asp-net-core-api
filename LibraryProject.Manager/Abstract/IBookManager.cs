
using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
    public interface IBookManager
    {
      book GetByID(int ID);
      IEnumerable<book> GetBooks();
      long Add(book b);
      bool Update(book b);
      bool Delete(book b);
      
    }
}
