using LibraryProject.DAL.Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LibraryProject.DAL.Dapper
{
   public class Constants
   {
      public static IDapperContext dapperContext => new DapperContext(ConfigurationManager.ConnectionStrings[""].ConnectionString);
   }
}
