using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class book
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public int typeId { get; set; }
      public string name { get; set; }
      public string writer { get; set; }
      public int shelfNumber { get; set; }
      public DateTime issueDate { get; set; }
    }
}
