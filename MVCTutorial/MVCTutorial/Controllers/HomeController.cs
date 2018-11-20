using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCTutorial.Models;

namespace MVCTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string text = "hello";
            //System.IO.File.WriteAllText(@"D:\logs\allusers.txt", text);

            //var rnd = new Random(10);
            //int num = rnd.Next();


            //ViewBag.RandomNumber = num;

            // return View("About");

            // return Content("Hello");

            // return RedirectToAction("Contact");


            var names = new List<string>()
            {
                "Peter",
                "Pan",
                "Wendy"
            };

            var user = new User();
            user.Id = 1;
            user.FirstName = "Peter";
            user.LastName = "Pan";
            user.Age = 32;

            return View(user);

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