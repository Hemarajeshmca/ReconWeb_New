﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using static Recon_proto.Controllers.DataSetController;
using static Recon_proto.Controllers.ReconController;

namespace Recon_proto.Controllers
{
	public class RulesetupController : Controller
	{
		public IActionResult Rulesetup()
		{
			return View();
		}
		public IActionResult Rulesetupdetail()
		{
			return View();
		}

		#region list
		public class Rulesetuplist
		{
			public String? in_user_code { get; set; }
		}
		public class Rulesetuplistmodel
		{
			public string? rule_code { get; set; }
			public string? rule_name { get; set; }
			public int rule_gid { get; set; }
			public string? recon_code { get; set; }
			public string? recon_name { get; set; }
			public string? active_status { get; set; }
			public string? active_status_desc { get; set; }
		}

		[HttpPost]
		public JsonResult Rulesetuplistfetch([FromBody] Rulesetuplist context)
		{
			DataTable result = new DataTable();
			List<Rulesetuplistmodel> objcat_lst = new List<Rulesetuplistmodel>();
			string post_data = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44348/api/Rulesetup/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(context), UTF8Encoding.UTF8, "application/json");
				var response = client.PostAsync("rulelist", content).Result;
				Stream data = response.Content.ReadAsStreamAsync().Result;
				StreamReader reader = new StreamReader(data);
				post_data = reader.ReadToEnd();
				string d2 = JsonConvert.DeserializeObject<string>(post_data);
				result = JsonConvert.DeserializeObject<DataTable>(d2);
				for (int i = 0; i < result.Rows.Count; i++)
				{
					Rulesetuplistmodel objcat = new Rulesetuplistmodel();
					objcat.rule_gid = Convert.ToInt32(result.Rows[i]["rule_gid"]);
					objcat.rule_code = result.Rows[i]["rule_code"].ToString();
					objcat.rule_name = result.Rows[i]["rule_name"].ToString();
					objcat.recon_code = result.Rows[i]["recon_code"].ToString();
					objcat.recon_name = result.Rows[i]["recon_name"].ToString();
					objcat.active_status = result.Rows[i]["active_status"].ToString();
					objcat.active_status_desc = result.Rows[i]["active_status_desc"].ToString();
					objcat_lst.Add(objcat);
				}
				return Json(objcat_lst);
			}
		}
		#endregion

		#region rule header
		public class Rulesetupheader
		{
			public Int64? in_rule_gid { get; set; }
			public string? in_rule_code { get; set; }
			public string? in_rule_name { get; set; }
			public string? in_recon_code { get; set; }
			public String in_period_from { get; set; }
			public String? in_period_to { get; set; }
			public string? in_until_active_flag { get; set; }
			public string? in_applyrule_on { get; set; }
			public string? in_source_dataset_code { get; set; }
			public string? in_comparison_dataset_code { get; set; }
			public string? in_source_acc_mode { get; set; }
			public string? in_parent_dataset_code { get; set; }
			public string? in_support_dataset_code { get; set; }
			public string? in_parent_acc_mode { get; set; }
			public string? in_reversal_flag { get; set; }
			public string? in_group_flag { get; set; }
			public string? in_active_status { get; set; }
			public string? in_action { get; set; }
			public string? in_user_code { get; set; }
			public string? out_msg { get; set; }
			public string? out_result { get; set; }
		}
		[HttpPost]
		public JsonResult Ruleheader([FromBody] Rulesetupheader context)
		{
			Rulesetupheader objList = new Rulesetupheader();
			DataTable result = new DataTable();
			string post_data = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44348/api/Rulesetup/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(context), UTF8Encoding.UTF8, "application/json");
				var response = client.PostAsync("ruleheader", content).Result;
				Stream data = response.Content.ReadAsStreamAsync().Result;
				StreamReader reader = new StreamReader(data);
				post_data = reader.ReadToEnd();
				string d2 = JsonConvert.DeserializeObject<string>(post_data);
				result = JsonConvert.DeserializeObject<DataTable>(d2);
				for (int i = 0; i < result.Rows.Count; i++)
				{
					objList.in_rule_gid = Convert.ToInt32(result.Rows[i]["in_rule_gid"]);
					objList.out_msg = result.Rows[i]["out_msg"].ToString();
					objList.out_result = result.Rows[i]["out_result"].ToString();
				}
				return Json(objList);
			}
		}
		#endregion

		#region fetch
		public class fetchRule
		{
			public string? in_rule_code { get; set; }
		}
		[HttpPost]
		public JsonResult rulefetch([FromBody] fetchRule context)
		{
			DataSet result = new DataSet();
			DataTable result1 = new DataTable();
			List<fetchRecondataset> objcat_lst = new List<fetchRecondataset>();
			string post_data = "";
			string d2 = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44348/api/Rulesetup/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(context), UTF8Encoding.UTF8, "application/json");
				var response = client.PostAsync("fetchrule", content).Result;
				Stream data = response.Content.ReadAsStreamAsync().Result;
				StreamReader reader = new StreamReader(data);
				post_data = reader.ReadToEnd();
				d2 = JsonConvert.DeserializeObject<string>(post_data);
				result = JsonConvert.DeserializeObject<DataSet>(d2);
				var rr = result.Tables.Count;
				if (rr <= 0)
				{
					d2 = "";
				}
				return Json(d2);
			}
		}
		#endregion
	}
}
