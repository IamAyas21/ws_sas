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
    [RoutePrefix("api/REB")]
    public class REBController : ApiController
    {
        [HttpPost]
        [Route("List")]
        public ResponseREB List(ParamREB model)
        {
            REBViewModels rebViewModels = new REBViewModels();
            try
            {
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_REB_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy MMM dd"), Convert.ToDateTime(model.endDate).ToString("yyyy MMM dd")));

                if (dt.Rows.Count != 0)
                {
                    rebViewModels.ModalSaham = dt.Rows[0]["ModalSaham"].ToString();
                    rebViewModels.TambahSaham = dt.Rows[0]["TambahSaham"].ToString();
                    rebViewModels.LastProfit = dt.Rows[0]["LastProfit"].ToString();
                    rebViewModels.JumlahAwal = dt.Rows[0]["JumlahAwal"].ToString();
                    rebViewModels.Balance = dt.Rows[0]["Balance"].ToString();
                    rebViewModels.Deviden = dt.Rows[0]["Deviden"].ToString();
                    rebViewModels.JumlahAkhir = dt.Rows[0]["JumlahAkhir"].ToString();
                }

                return new ResponseREB
                {
                    status = "success",
                    message = "Data REB",
                    Data = rebViewModels
                };
            }
            catch (Exception e)
            {
                return new ResponseREB
                {
                    status = "success",
                    message = e.Message,
                    Data = rebViewModels
                };
            }
        }
    }
}
