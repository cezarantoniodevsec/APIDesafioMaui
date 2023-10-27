using System;
using WebApi.Entities;
using WebApi.Models.Product;
using AutoMapper;

namespace ProductsAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductRequest, Product>();

            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
