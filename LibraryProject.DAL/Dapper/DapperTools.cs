using Dapper;
using Dapper.Contrib.Extensions;
using LibraryProject.DAL.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL
{
    public class DapperTools:IDapperTools
    {
      private readonly IDapperContext _context;

      public DapperTools(string connectionString)
      {
         _context = new DapperContext(connectionString);
      }

      public DapperTools(IDapperContext context)
      {
        _context = context;
      }

      public T Get<T>(object ID) where T : class
      {
         return _context.Connection.Get<T>(ID);
      }

      public IEnumerable<T> GetAll<T>() where T : class
      {
         return _context.Connection.GetAll<T>();      
      }

      public long Insert<T>(T obj) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Insert(obj, transaction, 0);
            return result;
         });        
      }

      public long Insert<T>(IEnumerable<T> list) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Insert(list, transaction);
            return result;
         });
      }

      public bool Update<T>(T obj) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Update(obj, transaction);
            return result;
         });
      }

      public bool Update<T>(IEnumerable<T> list) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Update(list, transaction);
            return result;
         });
      }

      public bool Delete<T>(T obj) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Delete(obj, transaction);
            return result;
         });
      }

      public bool Delete<T>(IEnumerable<T> list) where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.Delete(list, transaction);
            return result;
         });
      }

      public bool DeleteAll<T>() where T : class
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.DeleteAll<T>();
            return result;
         });
      }

      public int Execute(string sql, object param = null)
      {
         return _context.Transaction(transaction =>   
            _context.Connection.Execute(sql, param, transaction)
         ); 
      }

      public object ExecuteScalar(string sql, object param = null)
      {
         return _context.Transaction(transaction =>
         {
            var result = _context.Connection.ExecuteScalar(sql, param, transaction);
            return result;
         });
      }  
      
   }
}
