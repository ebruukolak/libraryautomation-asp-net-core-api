using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

using System.Text;

namespace LibraryProject.DAL.Repository.Dapper
{
   public class Constants
   {
      public static string LibraryConnection;
      public IDapperContext dapperContext => new DapperContext(LibraryConnection);
   }
  
}
