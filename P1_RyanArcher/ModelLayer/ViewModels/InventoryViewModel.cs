using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BusinessLogicLayer;
//using ModelLayer;
//using Microsoft.AspNetCore.Mvc;

namespace ModelLayer.ViewModels
{
    public class InventoryViewModel
    {
        //private BusinessLogicClass _businessLogicClass; // Get access to the DbContext through BusinessLogicClass
        //public LocationController(BusinessLogicClass businessLogicClass)
        //{
        //    // Creates instance of the businessLogicClass for use in UserController as a service.
        //    _businessLogicClass = businessLogicClass;
        //}
        //public Guid CurrentUserId { get { return BusinessLogicClass.CurrentUserId; } set { } }


        public Guid InventoryId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        // FK
        public Guid LocationId { get; set; }
        public Guid ProductId { get; set; }

        // This stuff is from the Product
        [Display(Name = "Store")]
        public string StoreName { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
