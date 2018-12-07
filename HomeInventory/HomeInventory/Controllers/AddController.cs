using HomeInventory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeInventory.Controllers
{
    public class AddController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new InventoryItemContext())
            {
                List<InventoryItem> InventoryList = context.InventoryItems.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(string name, string location, int quantity)
        {
            using (InventoryItemContext db = new InventoryItemContext())
            {
                var item = new InventoryItem();
                item.Name = name;
                item.Location = location;
                item.Quantity = quantity;
                db.InventoryItems.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("../Home/Index");
        }

        public ActionResult ReturnToMenu()
        {
            return RedirectToAction("../Home/Index");
        }
    }
}