using Microsoft.AspNet.Mvc;

namespace UIDemos.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


		public IActionResult Search()
		{
			return View();
		}

	}
}
