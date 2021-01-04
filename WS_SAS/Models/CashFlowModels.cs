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

    public class CashFlowModels
    {
        public string Group { get; set; }
        public string Group2 { get; set; }
        public string ACC { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Value { get; set; }
        public string Sum { get; set; }
        public int SortId { get; set; }
    }
}