using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WS_SAS.Logic;
using WS_SAS.Models;
using WS_SAS.Parse;

namespace WS_SAS.Controllers
{
    [RoutePrefix("api/Ledger")]
    public class LedgerController : ApiController
    {
        [HttpPost]
        [Route("List")]
        public ResponseLedger List(ParamLedger model)
        {
            LedgerDataModel DataLedger = new LedgerDataModel();
            DataLedger.StartDate = model.startDate.ToString("dd MMM yyyy");
            DataLedger.EndDate = model.endDate.ToString("dd MMM yyyy");

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_LEDGER_SP '{0}','{1}','{2}','{3}'", model.userId, model.startDate.ToString("yyyy-MM-dd"), model.endDate.ToString("yyyy-MM-dd"), model.accountNo.Replace("'", "")));

                List<LedgerAccountModel> ListAccount = new List<LedgerAccountModel>();
                LedgerAccountModel DataAccount = new LedgerAccountModel();
                List<LedgerDataAccountModel> Mutation = new List<LedgerDataAccountModel>();
                decimal Debet = 0;
                decimal Credit = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LedgerDataAccountModel Raw = new LedgerDataAccountModel();

                    if (dt.Rows[i]["JurnalDescription"].ToString().Contains("Saldo Awal"))
                    {
                        if (DataAccount.No != null)
                        {
                            DataAccount.DebetMutation = Debet.ToString("#,##;(#,##);-");
                            DataAccount.CreditMutation = Credit.ToString("#,##;(#,##);-");

                            DataAccount.EndingBalance = DataAccount.InitialBalance;
                            if (Mutation.Count != 0)
                            {
                                DataAccount.EndingBalance = Mutation[Mutation.Count - 1].Balance;
                            }

                            DataAccount.Mutations = Mutation;
                            Mutation = new List<LedgerDataAccountModel>();

                            Debet = 0;
                            Credit = 0;

                            ListAccount.Add(DataAccount);
                            DataAccount = new LedgerAccountModel();
                        }

                        DataAccount.InitialBalance = dt.Rows[i]["Balance"].ToString();
                        DataAccount.No = dt.Rows[i]["CoaNo"].ToString();
                        DataAccount.Name = dt.Rows[i]["CoaName"].ToString();
                    }

                    Raw.Ref = dt.Rows[i]["REF"].ToString();
                    Raw.Date = dt.Rows[i]["Date"].ToString();
                    Raw.Voucher = dt.Rows[i]["VoucherNo"].ToString();
                    Raw.Desc = dt.Rows[i]["JurnalDescription"].ToString();
                    Raw.Debet = dt.Rows[i]["Debet"].ToString();
                    Raw.Credit = dt.Rows[i]["Credit"].ToString();
                    Raw.Balance = dt.Rows[i]["Balance"].ToString();

                    if (dt.Rows[i]["Debet"].ToString() != string.Empty)
                    {
                        Debet += Convert.ToDecimal(dt.Rows[i]["Debet"].ToString().Replace(",", "").Replace("-", "0").Replace("(", "-").Replace(")", ""));
                    }

                    if (dt.Rows[i]["Credit"].ToString() != string.Empty)
                    {
                        Credit += Convert.ToDecimal(dt.Rows[i]["Credit"].ToString().Replace(",", "").Replace("-", "0").Replace("(", "-").Replace(")", ""));
                    }

                    Mutation.Add(Raw);
                }

                if (DataAccount.No != null)
                {
                    DataAccount.EndingBalance = DataAccount.InitialBalance;
                    if (Mutation.Count != 0)
                    {
                        DataAccount.EndingBalance = Mutation[Mutation.Count - 1].Balance;
                    }

                    DataAccount.Mutations = Mutation;
                    Mutation = new List<LedgerDataAccountModel>();

                    ListAccount.Add(DataAccount);
                    DataAccount = new LedgerAccountModel();
                }

                DataLedger.Accounts = ListAccount;

                return new ResponseLedger
                {
                    status = "success",
                    message = "List Ledger",
                    Data = DataLedger
                };
            }
            catch (Exception e)
            {
                return new ResponseLedger
                {
                    status = "error",
                    message = e.Message,
                    Data = DataLedger
                };
            }
        }
    }
}
