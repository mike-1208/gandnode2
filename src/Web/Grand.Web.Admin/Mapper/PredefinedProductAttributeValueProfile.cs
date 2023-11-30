﻿using AutoMapper;
using Grand.Domain.Catalog;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Catalog;
using Grand.Web.Common.Extensions;

namespace Grand.Web.Admin.Mapper
{
    public class PredefinedProductAttributeValueProfile : Profile, IAutoMapperProfile
    {
        public PredefinedProductAttributeValueProfile()
        {
            CreateMap<PredefinedProductAttributeValue, PredefinedProductAttributeValueModel>()
                .ForMember(dest => dest.Locales, mo => mo.Ignore())
                .ForMember(dest => dest.PriceAdjustmentStr, mo => mo.MapFrom(x => x.PriceAdjustment.ToString("N2")))
                .ForMember(dest => dest.WeightAdjustmentStr, mo => mo.MapFrom(x => x.WeightAdjustment.ToString("N2")));

            CreateMap<PredefinedProductAttributeValueModel, PredefinedProductAttributeValue>()
                .ForMember(dest => dest.Id, mo => mo.Ignore())
                .ForMember(dest => dest.Locales, mo => mo.MapFrom(x => x.Locales.ToTranslationProperty()));
        }

        public int Order => 0;
    }
}