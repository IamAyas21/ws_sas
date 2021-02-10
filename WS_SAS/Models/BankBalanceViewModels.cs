using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class BankBalanceViewModels
    {
        public string Month { get; set; }
        public string Total { get; set; }
    }

    public class ParamBankBalanceChart
    {
        public string userId { get; set; }
        public string year { get; set; }
    }
}