using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseCOA
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<COAViewModels> Data { get; set; }
    }
}