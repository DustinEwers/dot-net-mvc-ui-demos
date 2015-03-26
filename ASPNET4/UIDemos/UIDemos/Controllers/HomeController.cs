
using System.Web.Mvc;
using UIDemos.Models;

namespace UIDemos.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			return View(new Contact());
		}

		[HttpPost]
		public ActionResult Contact(Contact vm)
		{
			return View(new Contact());
		}
	}
}