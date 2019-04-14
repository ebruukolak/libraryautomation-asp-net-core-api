using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class category
    {
      [Dapper.Contrib.Extensions.Key]
      public int ID { get; set; }
      public string Name { get; set; }
    }
}
