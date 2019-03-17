using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.DAL.Repository.Dapper
{
   public interface IConnectionConfig
   {
      string GetConnection();
   }

   public class ConnectionConfig
    {
      public string ConnectionString { get; set; }
      public ConnectionConfig(string ConnectionString)
      {
         this.ConnectionString = ConnectionString;
      }


      public string GetConnection()
      {
         return ConnectionString;
      }
   }
}
