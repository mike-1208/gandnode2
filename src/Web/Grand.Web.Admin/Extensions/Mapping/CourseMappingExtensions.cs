﻿using Grand.Domain.Courses;
using Grand.Infrastructure.Mapper;
using Grand.Web.Admin.Models.Courses;

namespace Grand.Web.Admin.Extensions.Mapping
{
    public static class CourseMappingExtensions
    {
        public static CourseModel ToModel(this Course entity)
        {
            return entity.MapTo<Course, CourseModel>();
        }

        public static Course ToEntity(this CourseModel model)
        {
            return model.MapTo<CourseModel, Course>();
        }

        public static Course ToEntity(this CourseModel model, Course destination)
        {
            return model.MapTo(destination);
        }
    }
}