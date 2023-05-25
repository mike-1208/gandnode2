﻿using Grand.Domain.Catalog;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Catalog;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class ProductAttributeMappingMappingExtensions
    {
        public static ProductModel.ProductAttributeMappingModel ToModel(this ProductAttributeMapping entity)
        {
            return entity.MapTo<ProductAttributeMapping, ProductModel.ProductAttributeMappingModel>();
        }

        public static ProductAttributeMapping ToEntity(this ProductModel.ProductAttributeMappingModel model)
        {
            return model.MapTo<ProductModel.ProductAttributeMappingModel, ProductAttributeMapping>();
        }

        public static ProductAttributeMapping ToEntity(this ProductModel.ProductAttributeMappingModel model, ProductAttributeMapping destination)
        {
            return model.MapTo(destination);
        }
    }
}