using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeInventory.Models
{
    public class InventoryItemContext : DbContext
    {
        public InventoryItemContext() : base("DefaultConnection")
        {
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}