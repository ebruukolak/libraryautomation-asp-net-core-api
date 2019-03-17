using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
   public interface IStudentManager
   {
      students GetByID(int ID);
      IEnumerable<students> GetStudents();
      long Add(students student);
      bool Update(students student);
      bool Delete(students student);
   }
}
