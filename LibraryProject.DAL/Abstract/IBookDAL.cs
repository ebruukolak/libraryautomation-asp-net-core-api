using LibraryProject.DAL.Repository;
using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.Abstract
{
   public interface IBookDAL : IRepositoryAccess<book>
   {
      book GetByName(string name);
   }
}
