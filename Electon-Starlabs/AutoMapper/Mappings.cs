using AutoMapper;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.AutoMapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductReviewViewModel>().ReverseMap();
        }
    }
}
