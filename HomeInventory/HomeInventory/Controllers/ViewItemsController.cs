using HomeInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeInventory.Controllers
{
    public class ViewItemsController : Controller
    {
        public ActionResult Index()
        {
            using (InventoryItemContext db = new InventoryItemContext())
            {
                var items = (from c in db.InventoryItems
                             where c.Removed == null
                             select c).ToList();

                var listViewItems = new List<InventoryItem>();
                foreach (var item in items)
                {
                    var viewItem = new InventoryItem();
                    viewItem.Id = item.Id;
                    viewItem.Name = item.Name;
                    viewItem.Location = item.Location;
                    viewItem.Quantity = item.Quantity;
                    listViewItems.Add(viewItem);
                }
                return View(listViewItems);
            }
        }

        public ActionResult ReturnToMenu()
        {
            return RedirectToAction("../Home/Index");
        }
    }
}