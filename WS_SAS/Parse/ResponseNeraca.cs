using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_SAS.Models;

namespace WS_SAS.Parse
{
    public class ResponseNeracaClass1
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<NeracaClass1> Data { get; set; }
    }

    public class ResponseNeracaClass3
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<NeracaClass3> Data { get; set; }
    }
}