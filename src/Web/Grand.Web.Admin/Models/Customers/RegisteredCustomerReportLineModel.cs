﻿using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.Customers
{
    public class RegisteredCustomerReportLineModel : BaseModel
    {
        [GrandResourceDisplayName("Admin.Reports.Customers.RegisteredCustomers.Fields.Period")]
        public string Period { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Customers.RegisteredCustomers.Fields.Customers")]
        public int Customers { get; set; }
    }
}