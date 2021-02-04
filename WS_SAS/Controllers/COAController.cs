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
    [RoutePrefix("api/COA")]
    public class COAController : ApiController
    {
        [HttpPost]
        [Route("List")]
        public ResponseCOA List(ParamCOA model)
        {
            List<COAViewModels> Details1 = new List<COAViewModels>();
            List<COAViewModels> Details2 = new List<COAViewModels>();
            List<COAViewModels> Details3 = new List<COAViewModels>();
            List<COAViewModels> Details4 = new List<COAViewModels>();
            COAViewModels Detail1 = new COAViewModels();
            COAViewModels Detail2 = new COAViewModels();
            COAViewModels Detail3 = new COAViewModels();
            COAViewModels Detail4 = new COAViewModels();

            Detail4.Acc = "0";
            Detail4.Name = " All Account ";
            Details4.Add(Detail4);

            try
            {
                COAViewModels data = new COAViewModels();
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.COA_TREEVIEW_DROPDOWN_SP '{0}'", model.userId));
                string Class1 = string.Empty;
                string Class2 = string.Empty;
                string Class3 = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Detail1 = new COAViewModels();
                    Class1 = dt.Rows[i]["Class1"].ToString();
                    //Detail1.Acc = dt.Rows[i]["Class1"].ToString();
                    //Detail1.Name = dt.Rows[i]["Class1"].ToString();

                    //Details2 = new List<COAViewModels>();
                    for (int j = i; j < dt.Rows.Count; j++)
                    {
                        if (Class1 == dt.Rows[j]["Class1"].ToString())
                        {
                            //Detail2 = new COAViewModels();
                            Class2 = dt.Rows[j]["Class2"].ToString();
                            //Detail2.Acc = dt.Rows[j]["Class2"].ToString();
                            //Detail2.Name = dt.Rows[j]["Class2"].ToString();

                            //Details3 = new List<COAViewModels>();
                            for (int k = j; k < dt.Rows.Count; k++)
                            {
                                if (Class2 == dt.Rows[k]["Class2"].ToString())
                                {
                                    //Detail3 = new COAViewModels();
                                    Class3 = dt.Rows[k]["Class3"].ToString();
                                    //Detail3.Acc = dt.Rows[k]["Class3"].ToString();
                                    //Detail3.Name = dt.Rows[k]["Class3"].ToString();

                                    //Details4 = new List<COAViewModels>();
                                    for (int l = k; l < dt.Rows.Count; l++)
                                    {
                                        if (Class3 == dt.Rows[l]["Class3"].ToString())
                                        {
                                            k = l;
                                            Detail4 = new COAViewModels();
                                            Detail4.Acc = dt.Rows[l]["CoaNo"].ToString();
                                            Detail4.Name = dt.Rows[l]["Class4"].ToString();
                                            Details4.Add(Detail4);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    j = k;
                                    //Detail3.Data = Details4;
                                    //Details3.Add(Detail3);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            i = j;
                            //Detail2.Data = Details3;
                            //Details2.Add(Detail2);
                        }
                        else
                        {
                            break;
                        }
                    }
                    //Detail1.Data = Details2;
                    //Details1.Add(Detail1);
                }
                return new ResponseCOA
                {
                    status = "success",
                    message = "List COA",
                    Data = Details4
                };
            }
            catch (Exception e)
            {
                return new ResponseCOA
                {
                    status = "error",
                    message = e.Message,
                    Data = Details4
                };
            }
        }
    }
}
