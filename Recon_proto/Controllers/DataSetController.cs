using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Text;

namespace Recon_proto.Controllers
{
	public class DataSetController : Controller
	{
        public IActionResult DataSetList()
        {
            return View();
        }
        public IActionResult DataSetForm()
        {
            return View();
        }
		string urlstring = "";
		[HttpPost]
		public JsonResult Datasetlistfetch([FromBody] Datasetlistmodel context)
		{
			Datasetlistmodel objList = new Datasetlistmodel();
			DataTable result = new DataTable();
			List<Datasetlistmodel> objcat_lst = new List<Datasetlistmodel>();
			string post_data = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44348/api/Dataset/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(context), UTF8Encoding.UTF8, "application/json");
				var response = client.PostAsync("DatasetRead", content).Result;
				Stream data = response.Content.ReadAsStreamAsync().Result;
				StreamReader reader = new StreamReader(data);
				post_data = reader.ReadToEnd();
				string d2 = JsonConvert.DeserializeObject<string>(post_data);
				result = JsonConvert.DeserializeObject<DataTable>(d2);
				for (int i = 0; i < result.Rows.Count; i++)
				{
					Datasetlistmodel objcat = new Datasetlistmodel();
					objcat.dataset_id = Convert.ToInt32(result.Rows[i]["dataset_gid"]);
					objcat.dataset_name = result.Rows[i]["dataset_name"].ToString();
					objcat.datasetCode = result.Rows[i]["dataset_code"].ToString();
					objcat.active_status = result.Rows[i]["active_status"].ToString();
					objcat.dataset_category = result.Rows[i]["dataset_category"].ToString();
					objcat.active_status_desc = result.Rows[i]["active_status_desc"].ToString();
					objcat_lst.Add(objcat);
				}
				return Json(objcat_lst);
			}
		}
		#region list
		public class Datasetlistmodel
		{
			public string? dataset_name { get; set; }
			public string? datasetCode { get; set; }
			public int dataset_id { get; set; }
			public string? dataset_category { get; set; }
			public string? active_status { get; set; }
			public string? active_status_desc { get; set; }
			public int in_user_gid { get; set; }
			public string? in_user_code { get; set; }
			public string? in_active_status { get; set; }
		}
		#endregion
	}
}
