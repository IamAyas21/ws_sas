using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseClass1
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Class1> Data { get; set; }
    }

    public class ResponseClass3
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Class3> Data { get; set; }
    }

    public class ResponseChartProfitLoss
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<ChartProfitLos> Data { get; set; }
    }
}