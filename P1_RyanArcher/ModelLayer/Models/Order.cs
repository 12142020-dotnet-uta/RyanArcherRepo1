using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Order
    {
        [Key]
        public Guid OrderId{get;set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        // FK
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public Guid LocationId {get;set;}
        public Guid ProductId {get;set; }

        public Order(){}

        public Order(Cart cart, Location store, User user, Product product) {
            this.CartId = cart.CartId;
            this.UserId = user.UserId;
            this.LocationId = store.LocationId;
            this.ProductId = product.ProductId;
            this.Total = product.Price;
        }
    }
}