using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

using System.Text;

namespace LibraryProject.DAL.Repository.Dapper
{
   public class Constants
   {
     // public IConfiguration Configuration { get; }
      public static string LibraryConnection;
      //IConnectionConfig connection;
      //public Constants(IConfiguration config)
      //{
      //   Configuration = config;
      //}      

      //public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();

      //public string GetConnection()
      //{
      //   var connectionString = Configuration.GetSection("ConnectionStrings:LibraryConnection").Get<string>();
      //   return connectionString;
      //}
  
      public IDapperContext dapperContext => new DapperContext(LibraryConnection);
      
   }
   //public class ConnectionStrings
   //{
   //   public string LibraryConnection { get; set; }
   //}
}
