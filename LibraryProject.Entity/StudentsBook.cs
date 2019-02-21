using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Entity
{
    public class StudentsBook
    {
      public int ID { get; set; }
      public int BookID { get; set; }
      public int StudentID { get; set; }
      public DateTime TakenDate { get; set; }
      public DateTime GivenDate { get; set; }
    }
}
