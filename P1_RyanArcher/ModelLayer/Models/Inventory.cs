using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Inventory
    {
        [Key]
        public Guid InventoryId{get;set;}
        [Range(0, int.MaxValue)]
        public int Quantity {get;set;}

        // FK
        public Guid LocationId {get;set;}
        public Guid ProductId {get;set;}

        // private Guid inventoryID = Guid.NewGuid();
        // [Key]
        // public Guid InventoryId { get{ return inventoryID; } set{ inventoryID = value;} }
        // public Inventory() { 
        // }
        
        // public Inventory(string store, string product, int qunatity) {
        //     this.Location = store;
        //     this.Product = product;
        //     this.Quantity = qunatity;
        // }
        // private string location;
        // public string Location { get { return location; }
        //     set { location = value; }
        // } // End LocationId
        // private string product;
        // public string Product { get { return product; }
        //     set {
        //         // if (value is string && value.Length < 20 && value.Length > 0) {
        //             product = value;
        //         // } else {
        //         //     throw new Exception("The product name in Inventory item is not valid");
        //         // }
        //     }
        // } // End ProductId
        // private int quantity;
        // public int Quantity { get { return quantity; }
        //     set {
        //         // if (value is string && value.Length < 20 && value.Length > 0) {
        //             quantity = value;
        //         // } else {
        //         //     throw new Exception("The product name in Inventory item is not valid");
        //         // }
        //     }
        // } // End ProductId


    }
}