using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseLedger
    {
        public string status { get; set; }
        public string message { get; set; }
        public LedgerDataModel Data { get; set; }
    }
}