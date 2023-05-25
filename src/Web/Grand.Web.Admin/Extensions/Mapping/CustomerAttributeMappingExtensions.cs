﻿using Grand.Domain.Customers;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Customers;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class CustomerAttributeMappingExtensions
    {
        //customer attributes
        public static CustomerAttributeModel ToModel(this CustomerAttribute entity)
        {
            return entity.MapTo<CustomerAttribute, CustomerAttributeModel>();
        }

        public static CustomerAttribute ToEntity(this CustomerAttributeModel model)
        {
            return model.MapTo<CustomerAttributeModel, CustomerAttribute>();
        }

        public static CustomerAttribute ToEntity(this CustomerAttributeModel model, CustomerAttribute destination)
        {
            return model.MapTo(destination);
        }
        //customer attributes value
        public static CustomerAttributeValueModel ToModel(this CustomerAttributeValue entity)
        {
            return entity.MapTo<CustomerAttributeValue, CustomerAttributeValueModel>();
        }

        public static CustomerAttributeValue ToEntity(this CustomerAttributeValueModel model)
        {
            return model.MapTo<CustomerAttributeValueModel, CustomerAttributeValue>();
        }

        public static CustomerAttributeValue ToEntity(this CustomerAttributeValueModel model, CustomerAttributeValue destination)
        {
            return model.MapTo(destination);
        }
    }
}