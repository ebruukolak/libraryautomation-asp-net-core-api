using LibraryProject.Core.DatabaseOperations;
using LibraryProject.DAL;
using LibraryProject.DAL.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Core
{
   public class RepositoryAccess<TEntity> : IRepositoryAccess<TEntity> where TEntity : class
   {
      IDapperTools dapper;
      public RepositoryAccess()
      {
         dapper = new DapperTools(Constants.dapperContext);
      }         

      public TEntity Get(object ID)
      {
         return dapper.Get<TEntity>(ID);
      }

      public IEnumerable<TEntity> GetAll()
      {
         return dapper.GetAll<TEntity>();
      }

      public long Insert(TEntity entity)
      {
         return dapper.Insert<TEntity>(entity);
      }

      public bool Update(TEntity entity)
      {
         return dapper.Update<TEntity>(entity);
      }
      public bool Delete(TEntity entity)
      {
         return dapper.Delete<TEntity>(entity);
      }
   }
}
