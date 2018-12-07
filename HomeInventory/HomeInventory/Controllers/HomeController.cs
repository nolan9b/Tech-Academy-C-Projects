using System.Web.Mvc;

namespace HomeInventory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View("../Add/Index");
        }

        public ActionResult EditItem()
        {
            return RedirectToAction("../Edit/Index");
        }

        public ActionResult ViewItems()
        {
            return RedirectToAction("../ViewItems/Index");
        }
    }
}