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
   public class UserDAL : RepositoryAccess<user>, IUserDAL
   {
      //TODO modified
      IDapperTools dapperTools;
      public UserDAL()
      {
         dapperTools = new DapperTools(Constants.LibraryConnection);
      }
      public long AddRole(int ID, string roleName)
      {
         role r = new role
         {
            userid = ID,
            rolename = roleName
         };
         return dapperTools.Insert(r);
      }

      public role GetUserRole(int userID)
      {
         return dapperTools.Query<role>(@"Select * From roles where userid=@userID", new { userID }).First();
      }
      public void DeleteUserRole(role r)
      {
         dapperTools.Execute("delete from roles where id=@ID", new { @ID = r.id });
      }
      public user GetByUsername(string username)
      {
         return dapperTools.Query<user>(@"Select * from users where username=@username", new { username }).First();
      }

   }
}
