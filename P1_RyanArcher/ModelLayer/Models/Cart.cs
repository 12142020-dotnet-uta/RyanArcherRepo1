using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Cart
    {
        private Guid cartID = Guid.NewGuid();
        [Key]
        public Guid CartId { get { return cartID; } set { cartID = value; } }
        public Cart()
        {
        }

        //public Cart(string city)
        //{
        //    // this.LocationId = locationId;
        //    this.City = city;
        //}
        //public string StoreId
        //{
        //    get { return StoreId; }
        //    set
        //    {
        //        if (value is Guid && value.Length < 20 && value.Length > 0)
        //        {
        //            StoreId = value;
        //        }
        //        else
        //        {
        //            throw new Exception("The city name you sent is not valid");
        //        }
        //    }
        //}

        public Guid StoreId { get; set; }
        public Guid UserId { get; set; }
        public string CartStatus { get; set; }

        // List of Order Items in Cart
        public List<Order> OrderItems { get; set; } = new List<Order>();
    }
}
