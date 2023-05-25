﻿using Grand.Domain.Directory;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Directory;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class CurrencyMappingExtensions
    {
        public static CurrencyModel ToModel(this Currency entity)
        {
            return entity.MapTo<Currency, CurrencyModel>();
        }

        public static Currency ToEntity(this CurrencyModel model)
        {
            return model.MapTo<CurrencyModel, Currency>();
        }

        public static Currency ToEntity(this CurrencyModel model, Currency destination)
        {
            return model.MapTo(destination);
        }
    }
}