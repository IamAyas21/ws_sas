using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class CashFlowDashboardModels
    {
        public string Month { get; set; }
        public string R { get; set; }
        public string D { get; set; }
    }

    public class CashFlowHeaderModels
    {
        public string Group { get; set; }
        public string Group2 { get; set; }
        public string ACC { get; set; }
       
        public string Sum { get; set; }
        public int SortId { get; set; }
        public List<CashFlowDetailModels> Data { get; set; }
    }

    public class CashFlowDetailModels
    {
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Value { get; set; }
    }
    public class ParamCashFlow
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class ParamCashFlowChart
    {
        public string userId { get; set; }
        public string year { get; set; }
    }
}