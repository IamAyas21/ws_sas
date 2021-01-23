using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class TrialBalanceDataModel
    {
        public string Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string InitialDebet { get; set; }
        public string InitialCredit { get; set; }
        public string MutationDebet { get; set; }
        public string MutationCredit { get; set; }
        public string EndingDebet { get; set; }
        public string EndingCredit { get; set; }
    }

    public class TrialBalanceTotalModel
    {
        public string InitialDebet { get; set; }
        public string InitialCredit { get; set; }
        public string MutationDebet { get; set; }
        public string MutationCredit { get; set; }
        public string EndingDebet { get; set; }
        public string EndingCredit { get; set; }
    }

    public class ParamTrialBalance
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}