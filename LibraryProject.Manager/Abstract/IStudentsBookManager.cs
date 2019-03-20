using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Abstract
{
    public interface IStudentsBookManager
    {
      studentBook GetByID(int ID);
      IEnumerable<studentBook> GetStudents();
      long Add(studentBook sb);
      bool Update(studentBook sb);
      bool Delete(studentBook sb);
   }
}
