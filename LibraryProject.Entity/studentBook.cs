using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class studentBook
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public int bookId { get; set; }
      public int studentId { get; set; }
      public DateTime takenDate { get; set; }
      public DateTime givenDate { get; set; }
    }
}
