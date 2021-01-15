using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class REBViewModels
    {
        public string ModalSaham { get; set; }
        public string TambahSaham { get; set; }
        public string LastProfit { get; set; }
        public string JumlahAwal { get; set; }
        public string Balance { get; set; }
        public string Deviden { get; set; }
        public string JumlahAkhir { get; set; }
    }

    public class ParamREB
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}