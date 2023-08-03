using AutoMapper;
using BookStore.Application.DTOs.Books;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Books, BooksDto>().ReverseMap();  
        }
    }
}
