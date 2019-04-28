using AutoMapper;
using LibraryProject.Entity;
using LibraryProject.WebAPI.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.WebAPI.Helpers
{
   public class AutoMapper : Profile
   {
      public AutoMapper()
      {
         CreateMap<user, UserDTO>().ReverseMap().ForMember(x => x.password, opt => opt.Ignore());
         CreateMap<book, BookDTO>().ForMember(x => x.categoryname, opt => opt.Ignore());
         CreateMap<BookDTO, book>();
      }
   }
}
