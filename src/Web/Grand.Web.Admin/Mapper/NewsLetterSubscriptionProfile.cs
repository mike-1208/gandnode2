﻿using AutoMapper;
using Grand.Domain.Messages;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Messages;

namespace Grand.Web.Admin.Mapper;

public class NewsLetterSubscriptionProfile : Profile, IAutoMapperProfile
{
    public NewsLetterSubscriptionProfile()
    {
        CreateMap<NewsLetterSubscription, NewsLetterSubscriptionModel>()
            .ForMember(dest => dest.StoreName, mo => mo.Ignore())
            .ForMember(dest => dest.CreatedOn, mo => mo.Ignore());

        CreateMap<NewsLetterSubscriptionModel, NewsLetterSubscription>()
            .ForMember(dest => dest.Id, mo => mo.Ignore())
            .ForMember(dest => dest.StoreId, mo => mo.Ignore())
            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            .ForMember(dest => dest.NewsLetterSubscriptionGuid, mo => mo.Ignore());
    }

    public int Order => 0;
}