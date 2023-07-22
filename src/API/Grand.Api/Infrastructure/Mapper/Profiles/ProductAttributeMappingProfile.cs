﻿using AutoMapper;
using Grand.Api.DTOs.Catalog;
using Grand.Domain.Catalog;
using Grand.Infrastructure.Mapper;

namespace Grand.Api.Infrastructure.Mapper.Profiles
{
    public class ProductAttributeMappingProfile : Profile, IAutoMapperProfile
    {
        public ProductAttributeMappingProfile()
        {
            CreateMap<ProductAttributeMappingDto, ProductAttributeMapping>();
            CreateMap<ProductAttributeMapping, ProductAttributeMappingDto>();

            CreateMap<ProductAttributeValueDto, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeValueDto>();
        }

        public int Order => 1;
    }
}
