using LibraryProject.DAL.Abstract;
using LibraryProject.DAL.Repository;
using LibraryProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.Concrete
{
    public class UserDAL:RepositoryAccess<user>,IUserDAL
    {
    }
}
