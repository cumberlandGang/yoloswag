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

			return View(c.GenerateConversation(2));
		}

		public ActionResult Generate()
		{
			var bots = int.Parse(Request.Params["bots"]);
			var length = int.Parse(Request.Params["length"]);

			Conversation c = new Conversation();

			for (int i = 0; i < length; i++)
				c.AddBot();

			return View("/Views/Home/Index.cshtml", c.GenerateConversation(length));
		}
	}
}
