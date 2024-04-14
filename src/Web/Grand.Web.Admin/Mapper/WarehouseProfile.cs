﻿using AutoMapper;
using Grand.Domain.Shipping;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Shipping;

namespace Grand.Web.Admin.Mapper;

public class WarehouseProfile : Profile, IAutoMapperProfile
{
    public WarehouseProfile()
    {
        CreateMap<Warehouse, WarehouseModel>()
            .ForMember(dest => dest.Address, mo => mo.MapFrom(y => y.Address));

        CreateMap<WarehouseModel, Warehouse>()
            .ForMember(dest => dest.Id, mo => mo.Ignore());
    }

    public int Order => 0;
}