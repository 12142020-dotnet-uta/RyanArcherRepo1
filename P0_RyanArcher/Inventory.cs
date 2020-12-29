using System;
using System.ComponentModel.DataAnnotations;

namespace MelfsMagic
{
    public class Inventory
    {
        private Guid inventoryID = Guid.NewGuid();
        [Key]
        public Guid InventoryId { get{ return inventoryID; } set{ inventoryID = value;} }
        public Inventory() { 
        }
        
        public Inventory(Location store, string product) {
            this.LocationId = store.LocationId;
            this.ProductName = productName;
        }
        private Guid locationID;
        public Guid LocationId { get { return locationID; }
            set { locationID = value; }
        } // End LocationId
        private string productName;
        public string ProductName { get { return productName; }
            set {
                if (value is string && value.Length < 20 && value.Length > 0) {
                    productName = value;
                } else {
                    throw new Exception("The product name in Inventory item is not valid");
                }
            }
        } // End ProductName


    }
}