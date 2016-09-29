using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Yoloswag.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			Conversation c = new Conversation();

			c.AddBot();
			c.AddBot();
			c.AddBot();

			return View(c.GenerateConversation(10));
		}

		public ActionResult Generate(int bots, int length)
		{
			Conversation c = new Conversation();

			for (int i = 0; i < length; i++)
				c.AddBot();

			return View(c.GenerateConversation(length));
		}
	}
}
