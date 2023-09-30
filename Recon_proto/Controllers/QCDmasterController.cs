using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace Recon_proto.Controllers
{
    public class QCDmasterController : Controller
    {
        public IActionResult QcdMaster()
        {
            return View();
        }


        //public string Login_validation([FromBody] Login_model1 model)
        //{
        //    string post_data = "";
        //    DataTable result = new DataTable();
        //    List<user_model> objcat_lst = new List<user_model>();
        //    try
        //    {
        //        string hostName = Dns.GetHostName();
        //        ipAddress = Dns.GetHostAddresses(hostName)[0].ToString();

        //        var pass = Encrypt(model.Password);

        //        Login_model loginmodel = new Login_model();
        //        loginmodel.user_id = model.UserName;
        //        loginmodel.password = pass;
        //        loginmodel.ip = ipAddress;
        //        loginmodel.msg = "";
        //        loginmodel.ip_address = "";
        //        loginmodel.datasource = "";
        //        loginmodel.user_code = "";
        //        loginmodel.user_name = "";
        //        loginmodel.oldpassword = "";
        //        string post_data1 = _commonController.GetApiResult(JsonConvert.SerializeObject(loginmodel), "Loginvalidation");
        //        string d2 = JsonConvert.DeserializeObject<string>(post_data1);
        //        result = JsonConvert.DeserializeObject<DataTable>(d2);
        //        for (int i = 0; i < result.Rows.Count; i++)
        //        {
        //            user_model objcat = new user_model();
        //            objcat.user_gid = Convert.ToInt32(result.Rows[i]["user_gid"]);
        //            objcat.user_name = result.Rows[i]["user_name"].ToString();
        //            objcat.passwordexpdate = result.Rows[i]["password_expiry_date"].ToString();
        //            objcat.usergroup_gid = Convert.ToInt32(result.Rows[i]["usergroup_code"]);
        //            objcat.result = Convert.ToInt32(result.Rows[i]["out_result"]);
        //            objcat.msg = result.Rows[i]["out_msg"].ToString();
        //            objcat.oldpassworrd = Decrypt(pass);
        //            objcat.user_status = result.Rows[i]["user_status"].ToString();
        //            objcat_lst.Add(objcat);
        //            //ViewBag.userdetails = objcat;
        //            ViewBag.user_gid = objcat.user_gid;
        //            ViewBag.user_name = objcat.user_name;
        //            HttpContext.Session.SetString("usercode", model.UserName);
        //            HttpContext.Session.SetString("username", result.Rows[i]["user_name"].ToString());
        //            HttpContext.Session.SetString("mindate", result.Rows[i]["min_tran_date"].ToString());
        //            HttpContext.Session.SetString("fin_date", result.Rows[i]["fin_start_date"].ToString());
        //            HttpContext.Session.SetString("user_code", result.Rows[i]["user_gid"].ToString());
        //            HttpContext.Session.SetString("usergroup_code", result.Rows[i]["usergroup_code"].ToString());
        //            HttpContext.Session.SetString("userrole", "ADMIN");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        string control = this.RouteData.Values["controller"].ToString();
        //        _logger.LogError(ex, $"An error occurred in {control}");
        //    }

        //    return JsonConvert.SerializeObject(objcat_lst);
        //}

        //public ActionResult QcdMasterRead([DataSourceRequest] DataSourceRequest request, QcdMaster Qcdmastergrid)   // ProgressView  Read
        //{
        //    List<QcdMaster> objcat_lst = new List<QcdMaster>();
        //    DataTable result = new DataTable();
        //    QcdMaster QcdMasterRead = new QcdMaster();


        //    string post_data = objcommon.getApiResult(JsonConvert.SerializeObject(QcdMasterRead), "QcdMasterRead");
        //    result = (DataTable)JsonConvert.DeserializeObject(post_data, result.GetType());



        //    for (int i = 0; i < result.Rows.Count; i++)
        //    {
        //        QcdMaster objcat = new QcdMaster();
        //        objcat.masterGid = Convert.ToInt32(result.Rows[i]["master_gid"]);
        //        objcat.masterSyscode = result.Rows[i]["master_syscode"].ToString();
        //        objcat.masterCode = result.Rows[i]["master_code"].ToString();
        //        objcat.masterName = result.Rows[i]["master_name"].ToString();
        //        objcat_lst.Add(objcat);

        //    }

        //    //return Json(objcat_lst.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //    return Json(objcat_lst, JsonRequestBehavior.AllowGet);

        //}

    }
}
