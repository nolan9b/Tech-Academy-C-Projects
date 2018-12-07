using HomeInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeInventory.Controllers
{
    public class EditController : Controller
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

        // Take in a string to determine which button was pressed
        public ActionResult ModifyItem(int Id, string submit)
        {
            if (submit == "delete")
            {
                using (InventoryItemContext db = new InventoryItemContext())
                {
                    var item = db.InventoryItems.Find(Id);
                    item.Removed = DateTime.Now;
                    db.SaveChanges();
                }
                return RedirectToAction("../Home/Index");
            }
            else if (submit == "edit")
            {
                using (InventoryItemContext db = new InventoryItemContext())
                {
                    var item = db.InventoryItems.Find(Id);
                    return View("../Edit/EditItem", item);
                }
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        public ActionResult EditItem(InventoryItem item)
        {
            using (InventoryItemContext db = new InventoryItemContext())
            {
                var itemToChange = db.InventoryItems.Find(item.Id);
                itemToChange.Name = item.Name;
                itemToChange.Location = item.Location;
                itemToChange.Quantity = item.Quantity;
                db.SaveChanges();
            }
            return RedirectToAction("../Home/Index");
        }
    }
}