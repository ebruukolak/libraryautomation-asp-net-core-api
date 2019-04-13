using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
    public interface IUserManager
    {
      user GetByID(int ID);
      IEnumerable<user> GetUsers();
      long Add(user u);
      bool Update(user u);
      bool Delete(user u);
      user Authanticate(string username, string password);
      long AddRole(int userID, string roleName);
      role GetUserRole(int userID);
      void DeleteUserRole(int userID);
      user GetByUsername(string username);
   }
}
