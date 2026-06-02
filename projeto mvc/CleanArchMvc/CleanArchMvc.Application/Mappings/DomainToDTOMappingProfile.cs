using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
