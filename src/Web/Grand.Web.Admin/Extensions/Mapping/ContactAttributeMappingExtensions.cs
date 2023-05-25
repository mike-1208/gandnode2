﻿using Grand.Domain.Messages;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Messages;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class ContactAttributeMappingExtensions
    {
        //attributes
        public static ContactAttributeModel ToModel(this ContactAttribute entity)
        {
            return entity.MapTo<ContactAttribute, ContactAttributeModel>();
        }

        public static ContactAttribute ToEntity(this ContactAttributeModel model)
        {
            return model.MapTo<ContactAttributeModel, ContactAttribute>();
        }

        public static ContactAttribute ToEntity(this ContactAttributeModel model, ContactAttribute destination)
        {
            return model.MapTo(destination);
        }
        //contact attribute value
        public static ContactAttributeValueModel ToModel(this ContactAttributeValue entity)
        {
            return entity.MapTo<ContactAttributeValue, ContactAttributeValueModel>();
        }

        public static ContactAttributeValue ToEntity(this ContactAttributeValueModel model)
        {
            return model.MapTo<ContactAttributeValueModel, ContactAttributeValue>();
        }

        public static ContactAttributeValue ToEntity(this ContactAttributeValueModel model, ContactAttributeValue destination)
        {
            return model.MapTo(destination);
        }
    }
}