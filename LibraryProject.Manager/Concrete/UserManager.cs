using LibraryProject.DAL.Abstract;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
   public class UserManager : IUserManager
   {
      IUserDAL userDAL;

      public UserManager(IUserDAL userDAL)
      {
         this.userDAL = userDAL;
      }

      public user GetByID(int ID)
      {
         return userDAL.Get(ID);
      }
      public IEnumerable<user> GetUsers()
      {
         return userDAL.GetAll();
      }

      public long Add(user u)
      {
         return userDAL.Insert(u);
      }

      public bool Update(user u)
      {
         return userDAL.Update(u);
      }

      public bool Delete(user u)
      {
         return userDAL.Delete(u);
      }

      public user Authanticate(string username ,string password)
      {
         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return null;
         var user = userDAL.GetAll().Where(x=>x.username==username).FirstOrDefault();
         if (user == null)
            return null;

         if (!CheckPassword(password))
            return null;

         return user;

      }

      private bool CheckPassword(string password)
      {
         //TODO
         throw new NotImplementedException();
      }
   }
}
