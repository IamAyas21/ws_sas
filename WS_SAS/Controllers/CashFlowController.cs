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
        [HttpPost]
        [Route("List")]
        public ResponseCashFlow List(ParamCashFlow model)
        {
            string group = string.Empty;
            List<CashFlowHeaderModels> listCashFlowHeaderModels = new List<CashFlowHeaderModels>();
            List<CashFlowDetailModels> listCashFlowDetailModels = new List<CashFlowDetailModels>();

            CashFlowHeaderModels cashFlowHeaderModels = new CashFlowHeaderModels();
            CashFlowDetailModels cashFlowDetailModels = new CashFlowDetailModels();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_CASH_FLOW_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy MMM dd"), Convert.ToDateTime(model.endDate).ToString("yyyy MMM dd")));

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(!string.IsNullOrEmpty(dt.Rows[i]["GROUP"].ToString()))
                         {
                            if (group != dt.Rows[i]["GROUP"].ToString())
                            {
                                group = dt.Rows[i]["GROUP"].ToString();
                                cashFlowHeaderModels = new CashFlowHeaderModels();
                                listCashFlowDetailModels = new List<CashFlowDetailModels>();

                                cashFlowHeaderModels.Group = dt.Rows[i]["GROUP"].ToString();
                                cashFlowHeaderModels.Group2 = dt.Rows[i]["GROUP2"].ToString();
                                cashFlowHeaderModels.ACC = dt.Rows[i]["ACC"].ToString();
                                cashFlowHeaderModels.Sum = dt.Rows[i]["SUM"].ToString();
                                cashFlowHeaderModels.Data = listCashFlowDetailModels;

                                listCashFlowHeaderModels.Add(cashFlowHeaderModels);
                            }

                            cashFlowDetailModels = new CashFlowDetailModels();
                            cashFlowDetailModels.Name = dt.Rows[i]["NAME"].ToString();
                            cashFlowDetailModels.Name2 = dt.Rows[i]["NAME2"].ToString();
                            cashFlowDetailModels.Value = dt.Rows[i]["VALUE"].ToString();

                            listCashFlowDetailModels.Add(cashFlowDetailModels);
                        }
                     
                    }
                }

                return new ResponseCashFlow
                {
                    status = "success",
                    message = "List Cash Flow",
                    Data = listCashFlowHeaderModels
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listCashFlowHeaderModels));
                return new ResponseCashFlow
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }

        [HttpPost]
        [Route("Total")]
        public ResponseCashFlowDetail Total(ParamCashFlow model)
        {
            List<CashFlowDetailModels> listCashFlowDetailModels = new List<CashFlowDetailModels>();
            CashFlowDetailModels cashFlowDetailModels = new CashFlowDetailModels();

            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_CASH_FLOW_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy MMM dd"), Convert.ToDateTime(model.endDate).ToString("yyyy MMM dd")));

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i]["GROUP"].ToString()))
                        {
                            cashFlowDetailModels = new CashFlowDetailModels();
                            cashFlowDetailModels.Name = dt.Rows[i]["NAME"].ToString();
                            cashFlowDetailModels.Name2 = dt.Rows[i]["NAME2"].ToString();
                            cashFlowDetailModels.Value = dt.Rows[i]["VALUE"].ToString();
                            listCashFlowDetailModels.Add(cashFlowDetailModels);
                        }
                    }
                }

                return new ResponseCashFlowDetail
                {
                    status = "success",
                    message = "List Cash Flow",
                    Data = listCashFlowDetailModels
                };
            }
            catch (Exception e)
            {
                Logic.Log.getInstance().CreateLogError(e, JsonConvert.SerializeObject(listCashFlowDetailModels));
                return new ResponseCashFlowDetail
                {
                    status = "failed",
                    message = e.Message
                };
            }
        }
    }
}
