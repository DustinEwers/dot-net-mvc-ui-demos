using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using UIDemos.Models;

namespace UIDemos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
			var vm = new ContactViewModel();
            return View(vm);
        }
		
		public IActionResult SignUp()
		{
			var vm = new ContactViewModel();
			return View(vm);
		}

		[HttpPost]
		public IActionResult SignUp(ContactViewModel rvm)
		{
			
			return View(rvm);
		}

		public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}