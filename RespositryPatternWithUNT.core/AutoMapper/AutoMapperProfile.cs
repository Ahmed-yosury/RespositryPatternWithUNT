using AutoMapper;
using RespositryPatternWithUNT.core.Dtos;
using RespositryPatternWithUNT.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositryPatternWithUNT.core.AutoMapper
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Book, BookDtos>()
            //    .ForMember(dest=>dest.Title,opT=>opT.MapFrom(src=>src.Title))
            //    .ForMember(dest=>dest.AuthorId,opt=>opt.MapFrom(src=>src.AuthorId))
            //    .ForMember(dest=>dest.AuthorName,opt=>opt.MapFrom(src=>src.Author.Name));
            CreateMap<Jop, JopDots>()
               .ForMember(dest => dest.Name, otop => otop.MapFrom(src => src.Name))
               .ForMember(dest => dest.Id, otop => otop.MapFrom(src => src.Id))
               .ReverseMap();

       
        }
    }
}
