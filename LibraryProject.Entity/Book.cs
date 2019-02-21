using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class Book
    {
      public int ID { get; set; }
      public int TypeID { get; set; }
      public string Name { get; set; }
      public string Writer { get; set; }
      public int ShelfNumber { get; set; }
      public DateTime IssueDate { get; set; }
    }
}
