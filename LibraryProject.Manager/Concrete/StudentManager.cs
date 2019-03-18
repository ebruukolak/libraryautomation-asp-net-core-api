using LibraryProject.DAL.Abstract;
using LibraryProject.Entity;
using LibraryProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Manager.Concrete
{
   public class StudentManager : IStudentManager
   {
      IStudentDAL studentDAL;
      public StudentManager(IStudentDAL _studentDAL)
      {
         studentDAL = _studentDAL;
      }

      public student GetByID(int ID)
      {
         return studentDAL.Get(ID);
      }
      public IEnumerable<student> GetStudents()
      {
         return studentDAL.GetAll();
      }     

      public long Add(student student)
      {
         return studentDAL.Insert(student);
      }

      public bool Update(student student)
      {
         return studentDAL.Update(student);
      }
      public bool Delete(student student)
      {
         return studentDAL.Delete(student);
      }
   }
}
