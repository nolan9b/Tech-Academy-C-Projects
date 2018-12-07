using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeInventory.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime? Removed { get; set; }
    }
}