using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class Class1
    {
        public string ClassId { get; set; }
        public string TitleId { get; set; }
        public string TitleEg { get; set; }
        public string Amount { get; set; }
    }

    public class Class2
    {
        public string ClassId { get; set; }
        public string TitleId { get; set; }
        public string TitleEg { get; set; }
        public string Amount { get; set; }
    }

    public class Class3
    {
        public string TitleId { get; set; }
        public string TitleEg { get; set; }
        public string Amount { get; set; }
        public List<Class2> Data { get; set; }
    }

    public class ParamProfitLoss
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }

    public class ParamProfitLossClass
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string classId { get; set; }
    }
}