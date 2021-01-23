using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseTrialBalance
    {
        public string status { get; set; }
        public string message { get; set; }
        public TrialBalanceTotalModel Total { get; set; }
        public List<TrialBalanceDataModel> Data { get; set; }
    }
}