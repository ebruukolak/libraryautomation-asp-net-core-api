using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
   public interface IStudentManager
   {
      student GetByID(int ID);
      IEnumerable<student> GetStudents();
      long Add(student student);
      bool Update(student student);
      bool Delete(student student);
   }
}
