using LibraryProject.DAL.Abstract;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

      public long Add(user u, string password, string key)
      {
         var user = GetByUsername(u.username);
         if (user != null)
            throw new Exception(user.username + " already exist.Please,try to enter new username");
         var encryptedPassword = CreatePassword(password, key);
         if (!string.IsNullOrEmpty(encryptedPassword))
         {
            u.password = encryptedPassword;
            return userDAL.Insert(u);
         }
         else
         {
            throw new Exception("There is something error.");
         }

      }

      public bool Update(user u, string password,string key)
      {
         if (!string.IsNullOrEmpty(password))
         {
            u.password = CreatePassword(password,key);
         }
         return userDAL.Update(u);
      }

      public bool Delete(user u)
      {
         return userDAL.Delete(u);
      }

      public user Authanticate(string username, string password, string key)
      {
         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return null;
         var user = GetByUsername(username);
         if (user == null)
            return null;
         var decryptedPassword = DecryptedPassword(user.password, key);
         if (decryptedPassword.Equals(password))
            return user;

         return null;
      }
      public long AddRole(int userID, string roleName)
      {
         return userDAL.AddRole(userID, roleName);
      }
      public role GetUserRole(int userID)
      {
         return userDAL.GetUserRole(userID);
      }

      public void DeleteUserRole(int userID)
      {
         var role = GetUserRole(userID);
         userDAL.DeleteUserRole(role);
      }
      public user GetByUsername(string username)
      {
         return userDAL.GetByUsername(username);
      }

      #region Private Methods
      private string CreatePassword(string password, string key)
      {
         if (string.IsNullOrWhiteSpace(password))
            throw new Exception("Password can't be null");
         using (var md5 = new MD5CryptoServiceProvider())
         {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
               tdes.Key = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
               tdes.Mode = CipherMode.ECB;
               tdes.Padding = PaddingMode.PKCS7;
               using (var encryptor = tdes.CreateEncryptor())
               {
                  byte[] passBytes = UTF8Encoding.UTF8.GetBytes(password);
                  byte[] encryptedPassword = encryptor.TransformFinalBlock(passBytes, 0, passBytes.Length);
                  return Convert.ToBase64String(encryptedPassword, 0, encryptedPassword.Length);
               }
            }
         }
      }

      private string DecryptedPassword(string password, string key)
      {
         if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentNullException(password);
         using (var md5 = new MD5CryptoServiceProvider())
         {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
               tdes.Key = md5.ComputeHash(new UTF8Encoding().GetBytes(key));
               tdes.Mode = CipherMode.ECB;
               tdes.Padding = PaddingMode.PKCS7;
               using (var decryptor = tdes.CreateDecryptor())
               {
                  byte[] passBytes = Convert.FromBase64String(password);
                  byte[] decryptedPassword = decryptor.TransformFinalBlock(passBytes, 0, passBytes.Length);
                  return UTF8Encoding.UTF8.GetString(decryptedPassword);
               }
            }
         }
      }

      #endregion

   }
}
