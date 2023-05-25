﻿using Grand.Domain.Customers;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Customers;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class CustomerTagMappingExtensions
    {
        public static CustomerTagModel ToModel(this CustomerTag entity)
        {
            return entity.MapTo<CustomerTag, CustomerTagModel>();
        }

        public static CustomerTag ToEntity(this CustomerTagModel model)
        {
            return model.MapTo<CustomerTagModel, CustomerTag>();
        }

        public static CustomerTag ToEntity(this CustomerTagModel model, CustomerTag destination)
        {
            return model.MapTo(destination);
        }
    }
}