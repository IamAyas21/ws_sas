using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseBankBalance
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<BankBalanceViewModels> Data { get; set; }
    }
}