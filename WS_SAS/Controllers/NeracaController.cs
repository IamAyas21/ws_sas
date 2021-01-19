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
    [RoutePrefix("api/Neraca")]
    public class NeracaController : ApiController
    {
        [HttpPost]
        [Route("NeracaClass1")]
        public ResponseNeracaClass1 NeracaClass1(ParamNeraca model)
        {
            List<NeracaClass1> list = new List<Models.NeracaClass1>();
            NeracaClass1 NeracaClass1 = new NeracaClass1();
            try
            {
                string strClass1 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_NERACA_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(strClass1 != dt.Rows[i]["aClassName"].ToString())
                        {
                            NeracaClass1 = new NeracaClass1();
                            strClass1 = dt.Rows[i]["aClassName"].ToString();
                            NeracaClass1.ClassId = dt.Rows[i]["aClassId"].ToString();
                            NeracaClass1.TitleId = dt.Rows[i]["aClassName"].ToString();
                            NeracaClass1.TitleEg = dt.Rows[i]["aClassName2"].ToString();
                            NeracaClass1.Amount = dt.Rows[i]["ValueClass1"].ToString();
                            list.Add(NeracaClass1);
                        }

                        if(total == string.Empty)
                        {
                            total = dt.Rows[i]["Total"].ToString();
                        }
                    }

                    NeracaClass1 = new NeracaClass1();
                    NeracaClass1.TitleId = "Aset - Liabilitas & Ekuitas";
                    NeracaClass1.TitleEg = "Aset - Liabilitas & Ekuitas";
                    NeracaClass1.Amount =total;
                    list.Add(NeracaClass1);
                }
                return new ResponseNeracaClass1
                {
                    status = "success",
                    message = "List Class 1",
                    Data = list
                };
            }
            catch (Exception e)
            {
                return new ResponseNeracaClass1
                {
                    status = "error",
                    message = e.Message,
                    Data = list
                };
            }
        }

        [HttpPost]
        [Route("NeracaClass2")]
        public ResponseNeracaClass3 NeracaClass2(ParamProfitLossClass model)
        {
            List<NeracaClass2> listClass2 = new List<Models.NeracaClass2>();
            List<NeracaClass3> listClass3 = new List<Models.NeracaClass3>();
            NeracaClass2 NeracaClass2 = new NeracaClass2();
            NeracaClass3 NeracaClass3 = new NeracaClass3();
            try
            {
                string strClass2 = string.Empty, strClass3 = string.Empty, strClass4 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_NERACA_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (model.classId == dt.Rows[i]["aClassId"].ToString() && strClass3 != dt.Rows[i]["bClassName"].ToString())
                        {
                            NeracaClass3 = new NeracaClass3();
                            listClass2 = new List<NeracaClass2>();
                            
                            strClass3 = dt.Rows[i]["bClassName"].ToString();
                            NeracaClass3.TitleId = dt.Rows[i]["bClassName"].ToString();
                            NeracaClass3.TitleEg = dt.Rows[i]["bClassName2"].ToString();
                            NeracaClass3.Amount = dt.Rows[i]["ValueClass2"].ToString();

                            NeracaClass3.Data = listClass2;
                            listClass3.Add(NeracaClass3);

                            //NeracaClass2 = new NeracaClass2();
                            //NeracaClass2.ClassId = dt.Rows[i]["cClassId"].ToString();
                            //NeracaClass2.TitleId = "Jumlah " + dt.Rows[i]["bClassName"].ToString();
                            //NeracaClass2.TitleEg = "Jumlah " + dt.Rows[i]["bClassName2"].ToString();
                            //NeracaClass2.Amount = dt.Rows[i]["ValueClass2"].ToString();
                            //listClass2.Add(NeracaClass2);
                        }

                        if (model.classId == dt.Rows[i]["aClassId"].ToString() && strClass2 != dt.Rows[i]["cClassName"].ToString())
                        {
                            NeracaClass2 = new NeracaClass2();
                            strClass2 = dt.Rows[i]["cClassName"].ToString();
                            NeracaClass2.ClassId = dt.Rows[i]["cClassId"].ToString();
                            NeracaClass2.TitleId = dt.Rows[i]["cClassName"].ToString();
                            NeracaClass2.TitleEg = dt.Rows[i]["cClassName2"].ToString();
                            NeracaClass2.Amount = dt.Rows[i]["ValueClass3"].ToString();
                            listClass2.Add(NeracaClass2);
                        }
                    }

                    //NeracaClass3 = new NeracaClass3();
                    //NeracaClass3.TitleId = "Aset - Liabilitas & Ekuitas";
                    //NeracaClass3.TitleEg = "Aset - Liabilitas & Ekuitas";
                    //NeracaClass3.Amount = total;
                    //listClass3.Add(NeracaClass3);
                }
                return new ResponseNeracaClass3
                {
                    status = "success",
                    message = "List Class 3",
                    Data = listClass3
                };
            }
            catch (Exception e)
            {
                return new ResponseNeracaClass3
                {
                    status = "error",
                    message = e.Message,
                    Data = listClass3
                };
            }
        }

        [HttpPost]
        [Route("NeracaClass3")]
        public ResponseNeracaClass3 NeracaClass3(ParamProfitLossClass model)
        {
            List<NeracaClass2> listClass2 = new List<Models.NeracaClass2>();
            List<NeracaClass3> listClass3 = new List<Models.NeracaClass3>();
            NeracaClass2 NeracaClass2 = new NeracaClass2();
            NeracaClass3 NeracaClass3 = new NeracaClass3();
            try
            {
                string strClass2 = string.Empty, strClass3 = string.Empty, strClass4 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_NERACA_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (model.classId == dt.Rows[i]["cClassId"].ToString() && strClass3 != dt.Rows[i]["cClassName"].ToString())
                        {
                            NeracaClass3 = new NeracaClass3();
                            listClass2 = new List<NeracaClass2>();

                            strClass3 = dt.Rows[i]["cClassName"].ToString();
                            NeracaClass3.TitleId = dt.Rows[i]["cClassName"].ToString();
                            NeracaClass3.TitleEg = dt.Rows[i]["ValueClass3"].ToString();

                            NeracaClass3.Data = listClass2;
                            listClass3.Add(NeracaClass3);

                            //NeracaClass2 = new NeracaClass2();
                            //NeracaClass2.TitleId = "Jumlah " + dt.Rows[i]["CoaName"].ToString();
                            //NeracaClass2.TitleEg = "Jumlah " + dt.Rows[i]["CoaName2"].ToString();
                            //NeracaClass2.Amount = dt.Rows[i]["ValueClass3"].ToString();
                            //listClass2.Add(NeracaClass2);
                        }

                        if (model.classId == dt.Rows[i]["cClassId"].ToString() && strClass2 != dt.Rows[i]["CoaName"].ToString())
                        {
                            NeracaClass2 = new NeracaClass2();
                            strClass2 = dt.Rows[i]["CoaName"].ToString();
                            NeracaClass2.TitleId = dt.Rows[i]["CoaName"].ToString();
                            NeracaClass2.TitleEg = dt.Rows[i]["CoaName2"].ToString();
                            NeracaClass2.Amount = dt.Rows[i]["ValueClass4"].ToString();
                            listClass2.Add(NeracaClass2);
                        }
                    }

                    //NeracaClass3 = new NeracaClass3();
                    //NeracaClass3.TitleId = "Aset - Liabilitas & Ekuitas";
                    //NeracaClass3.TitleEg = "Aset - Liabilitas & Ekuitas";
                    //NeracaClass3.Amount = total;
                    //listClass3.Add(NeracaClass3);
                }
                return new ResponseNeracaClass3
                {
                    status = "success",
                    message = "List Class 3",
                    Data = listClass3
                };
            }
            catch (Exception e)
            {
                return new ResponseNeracaClass3
                {
                    status = "error",
                    message = e.Message,
                    Data = listClass3
                };
            }
        }

    }
}
