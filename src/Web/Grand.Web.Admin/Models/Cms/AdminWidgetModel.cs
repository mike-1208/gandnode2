﻿using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.Cms
{
    public class AdminWidgetModel : BaseModel
    {
        public string WidgetZone { get; set; }
        public string ViewComponentName { get; set; }
        public object AdditionalData { get; set; }
    }
}