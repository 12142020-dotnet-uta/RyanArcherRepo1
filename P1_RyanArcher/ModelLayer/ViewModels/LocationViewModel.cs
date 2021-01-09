using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class LocationViewModel
    {
        public Guid LocationId { get; set; }

        public string City { get; set; }

        //public List<Inventory> InventoryItems { get; set; } = new List<Inventory>();
    }
}
