using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.Repository.Dapper
{
   public interface IDapperTools
   {
      T Get<T>(object ID) where T : class;
      IEnumerable<T> GetAll<T>() where T : class;
      long Insert<T>(T obj) where T : class;
      long Insert<T>(IEnumerable<T> list) where T : class;
      bool Update<T>(T obj) where T : class;
      bool Update<T>(IEnumerable<T> list) where T : class;
      bool Delete<T>(T obj) where T : class;
      bool Delete<T>(IEnumerable<T> list) where T : class;
      bool DeleteAll<T>() where T : class;
      int Execute(string sql, object param = null);
      object ExecuteScalar(string sql, object param = null);
   }
}
