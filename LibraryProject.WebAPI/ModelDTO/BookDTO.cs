using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.WebAPI.ModelDTO
{
   public class BookDTO
   {
      public string name { get; set; }
      public string writer { get; set; }
      public int shelfNumber { get; set; }
      public DateTime issueDate { get; set; }
      public string categoryname { get; set; }
   }
}
