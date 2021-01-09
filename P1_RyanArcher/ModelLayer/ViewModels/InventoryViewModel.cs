using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class InventoryViewModel
    {
        public Guid InventoryId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        // FK
        public Guid LocationId { get; set; }
        public Guid ProductId { get; set; }

        // This stuff is from the Product
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
