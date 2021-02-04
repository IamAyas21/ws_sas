using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_SAS.Models
{
    public class LedgerDataModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<LedgerAccountModel> Accounts { get; set; }
    }

    public class LedgerAccountModel
    {
        public string No { get; set; }
        public string Name { get; set; }
        public string DebetMutation { get; set; }
        public string CreditMutation { get; set; }
        public string InitialBalance { get; set; }
        public string EndingBalance { get; set; }
        public List<LedgerDataAccountModel> Mutations { get; set; }
    }
    public class LedgerDataAccountModel
    {
        public string Ref { get; set; }
        public string Date { get; set; }
        public string Voucher { get; set; } 
        public string Desc { get; set; }
        public string Debet { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
    }

    public class ParamLedger
    {
        public string userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string accountNo { get; set; }
    }
}