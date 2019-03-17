using System.Collections.Generic;

namespace LibraryProject.DAL.Repository
{
    public interface IRepositoryAccess<TEntity> where TEntity:class
    {
      TEntity Get(object ID);
      IEnumerable<TEntity> GetAll();
      long Insert(TEntity entity);
      bool Update(TEntity entity);
      bool Delete(TEntity entity);
    }
}
