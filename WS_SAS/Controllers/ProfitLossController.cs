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
    [RoutePrefix("api/ProfitLoss")]
    public class ProfitLossController : ApiController
    {
        [HttpPost]
        [Route("Class1")]
        public ResponseClass1 Class1(ParamProfitLoss model)
        {
            List<Class1> list = new List<Models.Class1>();
            Class1 class1 = new Class1();
            try
            {
                string strClass1 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_PROFIT_LOSS_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(strClass1 != dt.Rows[i]["aClassName"].ToString())
                        {
                            class1 = new Class1();
                            strClass1 = dt.Rows[i]["aClassName"].ToString();
                            class1.ClassId = dt.Rows[i]["aClassId"].ToString();
                            class1.TitleId = dt.Rows[i]["aClassName"].ToString();
                            class1.TitleEg = dt.Rows[i]["aClassName2"].ToString();
                            class1.Amount = dt.Rows[i]["ValueClass1"].ToString();
                            list.Add(class1);
                        }

                        if(total == string.Empty)
                        {
                            total = dt.Rows[i]["Total"].ToString();
                        }
                    }

                    class1 = new Class1();
                    class1.TitleId = "Profit / (Loss)";
                    class1.TitleEg = "Profit / (Loss)";
                    class1.Amount =total;
                    list.Add(class1);
                }
                return new ResponseClass1
                {
                    status = "success",
                    message = "List Class 1",
                    Data = list
                };
            }
            catch (Exception e)
            {
                return new ResponseClass1
                {
                    status = "error",
                    message = e.Message,
                    Data = list
                };
            }
        }

        [HttpPost]
        [Route("Class2")]
        public ResponseClass3 Class2(ParamProfitLossClass model)
        {
            List<Class2> listClass2 = new List<Models.Class2>();
            List<Class3> listClass3 = new List<Models.Class3>();
            Class2 class2 = new Class2();
            Class3 class3 = new Class3();
            try
            {
                string strClass2 = string.Empty, strClass3 = string.Empty, strClass4 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_PROFIT_LOSS_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (model.classId == dt.Rows[i]["aClassId"].ToString() && strClass3 != dt.Rows[i]["bClassName"].ToString())
                        {
                            class3 = new Class3();
                            listClass2 = new List<Class2>();
                            
                            strClass3 = dt.Rows[i]["bClassName"].ToString();
                            class3.TitleId = dt.Rows[i]["bClassName"].ToString();
                            class3.TitleEg = dt.Rows[i]["bClassName2"].ToString();
                            class3.Amount = dt.Rows[i]["ValueClass2"].ToString();

                            class3.Data = listClass2;
                            listClass3.Add(class3);

                            //class2 = new Class2();
                            //class2.ClassId = dt.Rows[i]["cClassId"].ToString();
                            //class2.TitleId = "Jumlah " + dt.Rows[i]["bClassName"].ToString();
                            //class2.TitleEg = "Jumlah " + dt.Rows[i]["bClassName2"].ToString();
                            //class2.Amount = dt.Rows[i]["ValueClass2"].ToString();
                            //listClass2.Add(class2);
                        }

                        if (model.classId == dt.Rows[i]["aClassId"].ToString() && strClass2 != dt.Rows[i]["cClassName"].ToString())
                        {
                            class2 = new Class2();
                            strClass2 = dt.Rows[i]["cClassName"].ToString();
                            class2.ClassId = dt.Rows[i]["cClassId"].ToString();
                            class2.TitleId = dt.Rows[i]["cClassName"].ToString();
                            class2.TitleEg = dt.Rows[i]["cClassName2"].ToString();
                            class2.Amount = dt.Rows[i]["ValueClass3"].ToString();
                            listClass2.Add(class2);
                        }
                    }

                    //class3 = new Class3();
                    //class3.TitleId = "Profit / (Loss)";
                    //class3.TitleEg = "Profit / (Loss)";
                    //class3.Amount = total;
                    //listClass3.Add(class3);
                }
                return new ResponseClass3
                {
                    status = "success",
                    message = "List Class 3",
                    Data = listClass3
                };
            }
            catch (Exception e)
            {
                return new ResponseClass3
                {
                    status = "error",
                    message = e.Message,
                    Data = listClass3
                };
            }
        }

        [HttpPost]
        [Route("Class3")]
        public ResponseClass3 Class3(ParamProfitLossClass model)
        {
            List<Class2> listClass2 = new List<Models.Class2>();
            List<Class3> listClass3 = new List<Models.Class3>();
            Class2 class2 = new Class2();
            Class3 class3 = new Class3();
            try
            {
                string strClass2 = string.Empty, strClass3 = string.Empty, strClass4 = string.Empty, total = string.Empty;
                DataTable dt = Common.ExcuteQuery(string.Format("exec dbo.JURNAL_PROFIT_LOSS_SP '{0}','{1}','{2}'", model.userId, Convert.ToDateTime(model.startDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(model.endDate).ToString("yyyy-MM-dd")));
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (model.classId == dt.Rows[i]["cClassId"].ToString() && strClass3 != dt.Rows[i]["cClassName"].ToString())
                        {
                            class3 = new Class3();
                            listClass2 = new List<Class2>();

                            strClass3 = dt.Rows[i]["cClassName"].ToString();
                            class3.TitleId = dt.Rows[i]["cClassName"].ToString();
                            class3.TitleEg = dt.Rows[i]["cClassName2"].ToString();
                            class3.Amount = dt.Rows[i]["ValueClass3"].ToString();

                            class3.Data = listClass2;
                            listClass3.Add(class3);

                            //class2 = new Class2();
                            //class2.TitleId = "Jumlah " + dt.Rows[i]["CoaName"].ToString();
                            //class2.TitleEg = "Jumlah " + dt.Rows[i]["CoaName2"].ToString();
                            //class2.Amount = dt.Rows[i]["ValueClass3"].ToString();
                            //listClass2.Add(class2);
                        }

                        if (model.classId == dt.Rows[i]["cClassId"].ToString() && strClass2 != dt.Rows[i]["CoaName"].ToString())
                        {
                            class2 = new Class2();
                            strClass2 = dt.Rows[i]["CoaName"].ToString();
                            class2.TitleId = dt.Rows[i]["CoaName"].ToString();
                            class2.TitleEg = dt.Rows[i]["CoaName2"].ToString();
                            class2.Amount = dt.Rows[i]["ValueClass4"].ToString();
                            listClass2.Add(class2);
                        }
                    }

                    //class3 = new Class3();
                    //class3.TitleId = "Profit / (Loss)";
                    //class3.TitleEg = "Profit / (Loss)";
                    //class3.Amount = total;
                    //listClass3.Add(class3);
                }
                return new ResponseClass3
                {
                    status = "success",
                    message = "List Class 3",
                    Data = listClass3
                };
            }
            catch (Exception e)
            {
                return new ResponseClass3
                {
                    status = "error",
                    message = e.Message,
                    Data = listClass3
                };
            }
        }

    }
}
