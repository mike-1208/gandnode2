﻿using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.Orders
{
    public partial class BestsellersReportLineModel : BaseModel
    {
        public string ProductId { get; set; }
        [GrandResourceDisplayName("Admin.Reports.Bestsellers.Fields.Name")]
        public string ProductName { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Bestsellers.Fields.TotalAmount")]
        public string TotalAmount { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Bestsellers.Fields.TotalQuantity")]
        public double TotalQuantity { get; set; }
    }
}