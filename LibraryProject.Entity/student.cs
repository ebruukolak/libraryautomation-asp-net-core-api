using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;
using System.Text;
using Newtonsoft.Json;

namespace LibraryProject.Entity
{
   //[System.ComponentModel.DataAnnotations.Schema.Table("students")]
   public class student
    {
      [Dapper.Contrib.Extensions.Key]
      public int id { get; set; }
      public string name { get; set; }
      public string surname { get; set; }
      public string email { get; set; }
      public DateTime createDate { get; set; }

    }
}
