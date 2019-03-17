using LibraryProject.DAL.Repository.Dapper;
using System.Collections.Generic;

namespace LibraryProject.DAL.Repository
{
   public class RepositoryAccess<TEntity> : IRepositoryAccess<TEntity> where TEntity : class
   {
      IDapperTools dapper;
      
      
      public RepositoryAccess()
      {
         dapper = new DapperTools(Constants.LibraryConnection);
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
