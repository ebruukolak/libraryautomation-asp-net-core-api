using LibraryProject.DAL.Abstract;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
   public class StudentsBookManager : IStudentsBookManager
   {
      IStudentsBookDAL _studentsBookDAL;
      public StudentsBookManager(IStudentsBookDAL studentsBookDAL)
      {
         _studentsBookDAL = studentsBookDAL;
      }
      public IEnumerable<studentBook> GetStudents()
      {
         throw new NotImplementedException();
      }
      public studentBook GetByID(int ID)
      {
         throw new NotImplementedException();
      }   
    
      public long Add(studentBook sb)
      {
        return _studentsBookDAL.Insert(sb);
      }
      public bool Update(studentBook sb)
      {
         return _studentsBookDAL.Update(sb);
      }

      public bool Delete(studentBook sb)
      {
         return _studentsBookDAL.Delete(sb);
      }

      

   }
}
