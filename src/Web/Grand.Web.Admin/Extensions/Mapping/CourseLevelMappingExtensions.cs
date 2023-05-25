﻿using Grand.Domain.Courses;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Courses;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class CourseLevelMappingExtensions
    {
        public static CourseLevelModel ToModel(this CourseLevel entity)
        {
            return entity.MapTo<CourseLevel, CourseLevelModel>();
        }

        public static CourseLevel ToEntity(this CourseLevelModel model)
        {
            return model.MapTo<CourseLevelModel, CourseLevel>();
        }

        public static CourseLevel ToEntity(this CourseLevelModel model, CourseLevel destination)
        {
            return model.MapTo(destination);
        }
    }
}