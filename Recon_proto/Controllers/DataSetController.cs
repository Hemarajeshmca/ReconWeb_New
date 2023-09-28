using Microsoft.AspNetCore.Mvc;

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
    }
}
