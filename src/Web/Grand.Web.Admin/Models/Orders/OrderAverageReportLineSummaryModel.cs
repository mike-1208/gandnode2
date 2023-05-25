using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.Orders
{
    public class OrderAverageReportLineSummaryModel : BaseModel
    {
        [GrandResourceDisplayName("Admin.Reports.Average.OrderStatus")]
        public string OrderStatus { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Average.SumTodayOrders")]
        public string SumTodayOrders { get; set; }
        
        [GrandResourceDisplayName("Admin.Reports.Average.SumThisWeekOrders")]
        public string SumThisWeekOrders { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Average.SumThisMonthOrders")]
        public string SumThisMonthOrders { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Average.SumThisYearOrders")]
        public string SumThisYearOrders { get; set; }

        [GrandResourceDisplayName("Admin.Reports.Average.SumAllTimeOrders")]
        public string SumAllTimeOrders { get; set; }
    }
}
