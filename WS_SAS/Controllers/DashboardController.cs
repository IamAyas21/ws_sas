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
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        [HttpPost]
        [Route("ChartCashFlow")]
        public ResponseDashboardCashFlow ChartCashFlow(ParamCashFlowChart model)
        {
            List<CashFlowDashboardModels> listReport = new List<CashFlowDashboardModels>();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec RPT_CASH_FLOW_SP '{0}','{1}'", model.userId, model.year));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CashFlowDashboardModels row = new CashFlowDashboardModels();
                    row.Month = dt.Rows[i]["MONTH"].ToString().Equals("")?"0": dt.Rows[i]["MONTH"].ToString();
                    row.R = dt.Rows[i]["R"].ToString().Equals("") ? "0" : dt.Rows[i]["R"].ToString();
                    row.D = dt.Rows[i]["D"].ToString().Equals("") ? "0" : dt.Rows[i]["D"].ToString();

                    listReport.Add(row);
                }

                return new ResponseDashboardCashFlow
                {
                    status = "success",
                    message = "Report Chart Cash Flow",
                    Data = listReport
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listReport));
                return new ResponseDashboardCashFlow
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }
    }
}
