using Newtonsoft.Json;
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
    [RoutePrefix("api/CashFlow")]
    public class CashFlowController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public ResponseCashFlow List(string userId, DateTime startDate, DateTime endDate)
        {
            List<CashFlowModels> listCashFlowModels = new List<CashFlowModels>();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_CASH_FLOW_SP '{0}','{1}','{2}'", userId, Convert.ToDateTime(startDate).ToString("yyyy MMM dd"), Convert.ToDateTime(endDate).ToString("yyyy MMM dd")));

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CashFlowModels cashFlowModels = new CashFlowModels();
                        cashFlowModels.Group = dt.Rows[i]["GROUP"].ToString();
                        cashFlowModels.Group2 = dt.Rows[i]["GROUP2"].ToString();
                        cashFlowModels.ACC = dt.Rows[i]["ACC"].ToString();
                        cashFlowModels.Name = dt.Rows[i]["NAME"].ToString();
                        cashFlowModels.Name2 = dt.Rows[i]["NAME2"].ToString();
                        cashFlowModels.Value = dt.Rows[i]["VALUE"].ToString();
                        cashFlowModels.Sum = dt.Rows[i]["SUM"].ToString();
                        listCashFlowModels.Add(cashFlowModels);
                    }
                }

                return new ResponseCashFlow
                {
                    status = "success",
                    message = "List Cash Flow",
                    Data = listCashFlowModels
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listCashFlowModels));
                return new ResponseCashFlow
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }
    }
}
