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
    [RoutePrefix("api/TrialBalance")]
    public class TrialBalanceController : ApiController
    {
        [HttpPost]
        [Route("List")]
        public ResponseTrialBalance List(ParamTrialBalance model)
        {
            DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_TRIAL_BALANCE_SP '{1}','{1}','{2}'", model.userId, model.startDate, model.endDate));
            TrialBalanceTotalModel trialBalanceTotal = new TrialBalanceTotalModel();
            List<TrialBalanceDataModel> listTrialBalance = new List<TrialBalanceDataModel>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["NO"].ToString() == "F1")
                    {
                        trialBalanceTotal.InitialDebet = dt.Rows[i]["aDebet"].ToString();
                        trialBalanceTotal.InitialCredit = dt.Rows[i]["aCredit"].ToString();
                        trialBalanceTotal.MutationDebet = dt.Rows[i]["DEBET"].ToString();
                        trialBalanceTotal.MutationCredit = dt.Rows[i]["CREDIT"].ToString();
                        trialBalanceTotal.EndingDebet = dt.Rows[i]["akDEBET"].ToString();
                        trialBalanceTotal.EndingCredit = dt.Rows[i]["akCREDIT"].ToString();
                    }
                    else
                    {
                        TrialBalanceDataModel row = new TrialBalanceDataModel();
                        row.Id = dt.Rows[i]["ID"].ToString();
                        row.No = dt.Rows[i]["NO"].ToString();
                        row.Name = dt.Rows[i]["NAME"].ToString();
                        row.InitialDebet = dt.Rows[i]["aDebet"].ToString();
                        row.InitialCredit = dt.Rows[i]["aCredit"].ToString();
                        row.MutationDebet = dt.Rows[i]["DEBET"].ToString();
                        row.MutationCredit = dt.Rows[i]["CREDIT"].ToString();
                        row.EndingDebet = dt.Rows[i]["akDEBET"].ToString();
                        row.EndingCredit = dt.Rows[i]["akCREDIT"].ToString();

                        listTrialBalance.Add(row);
                    }
                }

                return new ResponseTrialBalance
                {
                    status = "success",
                    message = "List Trial Balance",
                    Total = trialBalanceTotal,
                    Data = listTrialBalance
                };
            }
            catch (Exception e)
            {
                return new ResponseTrialBalance
                {
                    status = "success",
                    message = e.Message,
                    Total = trialBalanceTotal,
                    Data = listTrialBalance
                };
            }
        }
    }
}
