using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			string old = "How are you";
			string[] array = old.Split(' ');
			string append = string.Empty;
			for(var i=1;i<=array.Length;i++)
			{
				append += array[array.Length - i]+ " ";
			}
			append.Ravinder("");
			string test = Convert.ToString("");
			String path = @"F:\Ravinder\SGH\Reading Materials\Videos\Angular";
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			var directories = directoryInfo.GetDirectories().ToList().OrderBy(x=>x.CreationTime);
			foreach (var item in directories)
			{
				System.IO.File.AppendAllText(@"F:\Ravinder\SGH\Reading Materials\Videos\Angular\N.txt", item.Extension.Substring(1, item.Extension.Length-1)+Environment.NewLine);
			}
			//string a = old.Reverse('a',);
			ViewBag.Version = typeof(Controller).Assembly.GetName().Version.ToString();
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}