﻿using Grand.Domain.Localization;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Localization;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class LanguageMappingExtensions
    {
        public static LanguageModel ToModel(this Language entity)
        {
            return entity.MapTo<Language, LanguageModel>();
        }

        public static Language ToEntity(this LanguageModel model)
        {
            return model.MapTo<LanguageModel, Language>();
        }

        public static Language ToEntity(this LanguageModel model, Language destination)
        {
            return model.MapTo(destination);
        }
    }
}