using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class userType
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public int userid { get; set; }
      public string typename { get; set; }
    }
}
