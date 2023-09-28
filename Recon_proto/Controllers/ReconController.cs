using Microsoft.AspNetCore.Mvc;

namespace Recon_proto.Controllers
{
	public class ReconController : Controller
	{
		public IActionResult ReconView()
		{
			return View();
		}
		public IActionResult ReconList()
		{
			return View();
		}
	}
}
