using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class user
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public string username { get; set; }
      public string name { get; set; }
      public string surname { get; set; }
      public DateTime createdate { get; set; }
      public int usertype { get; set; }
      public string password { get; set; }
    } 
}
