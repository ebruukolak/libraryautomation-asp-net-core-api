using LibraryProject.DAL.Abstract;
using LibraryProject.DAL.Repository;
using LibraryProject.DAL.Repository.Dapper;
using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject.DAL.Concrete
{
   public class BookDAL : RepositoryAccess<book>, IBookDAL
   {
      IDapperTools dapperTools;
      public BookDAL()
      {
         dapperTools = new DapperTools(Constants.LibraryConnection);
      }
      public book GetByName(string name)
      {
         return dapperTools.Query<book>(@"Select * from books where name=@name", new { name }).First();
      }
   }
}
