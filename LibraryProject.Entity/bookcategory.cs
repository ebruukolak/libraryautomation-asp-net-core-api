using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class bookcategory
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public int bookid { get; set; }
      public int categoryid { get; set; }
    }
}
