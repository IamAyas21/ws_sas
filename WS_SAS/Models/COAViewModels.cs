using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class COAViewModels
    {
        public string Name { get; set; }
        public string Acc { get; set; }
        public List<COAViewModels> Data { get; set; }
    }

    public class ParamCOA
    {
        public string userId { get; set; }
    }
}