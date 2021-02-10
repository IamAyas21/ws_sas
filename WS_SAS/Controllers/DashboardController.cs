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
                    int valueR = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["R"].ToString().Equals("") ? "0" : dt.Rows[i]["R"].ToString()) / 1000000);
                    int valueD = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["D"].ToString().Equals("") ? "0" : dt.Rows[i]["D"].ToString()) / 1000000);

                    row.Month = dt.Rows[i]["MONTH"].ToString().Equals("")?"0": dt.Rows[i]["MONTH"].ToString();
                    row.R = valueR.ToString();
                    row.D = valueD.ToString();

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

        [HttpPost]
        [Route("ChartProfitLoss")]
        public ResponseChartProfitLoss ChartProfitLoss(ParamProfitLossChart model)
        {
            List<ChartProfitLos> listReport = new List<ChartProfitLos>();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec RPT_PROFIT_LOSS_SP '{0}','{1}'", model.userId, model.year));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChartProfitLos row = new ChartProfitLos();
                    int valueCost = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["Cost"].ToString().Equals("") ? "0" : dt.Rows[i]["Cost"].ToString()) / 1000000);
                    int valueIncome = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["Income"].ToString().Equals("") ? "0" : dt.Rows[i]["Income"].ToString()) / 1000000);
                    int valueTotal = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["Total"].ToString().Equals("") ? "0" : dt.Rows[i]["Total"].ToString()) / 1000000);

                    row.Month = dt.Rows[i]["MONTH"].ToString().Equals("") ? "0" : dt.Rows[i]["MONTH"].ToString();
                    row.Cost = valueCost.ToString();
                    row.Income = valueIncome.ToString();
                    row.Total = valueTotal.ToString();

                    listReport.Add(row);
                }

                return new ResponseChartProfitLoss
                {
                    status = "success",
                    message = "Report Chart Profit Loss",
                    Data = listReport
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listReport));
                return new ResponseChartProfitLoss
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }

        [HttpPost]
        [Route("ChartBankBalance")]
        public ResponseBankBalance ChartBankBalance(ParamBankBalanceChart model)
        {
            List<BankBalanceViewModels> listReport = new List<BankBalanceViewModels>();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec RPT_BANK_BALANCE_SP '{0}','{1}'", model.userId, model.year));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BankBalanceViewModels row = new BankBalanceViewModels();
                    
                    int valueTotal = Convert.ToInt32(Convert.ToDecimal(dt.Rows[i]["Total"].ToString().Equals("") ? "0" : dt.Rows[i]["Total"].ToString()) / 1000000);

                    row.Month = dt.Rows[i]["MONTH"].ToString().Equals("") ? "0" : dt.Rows[i]["MONTH"].ToString();
                    row.Total = valueTotal.ToString();

                    listReport.Add(row);
                }

                return new ResponseBankBalance
                {
                    status = "success",
                    message = "Report Chart Bank Balance",
                    Data = listReport
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listReport));
                return new ResponseBankBalance
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }
    }
}
