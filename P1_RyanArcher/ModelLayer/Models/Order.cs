using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Order
    {
        [Key]
        public Guid OrderId{get;set;}
        public Guid UserId {get;set;}
        public int Total {get;set;}
        // FK
        public Guid LocationId {get;set;}
        public Guid ProductId {get;set; }
        public Guid CartId { get; set; }

        public Order(){}

        public Order(Location store, User user, Product product) {
            this.OrderId = user.UserId;
            this.LocationId = store.LocationId;
            this.ProductId = product.ProductId;
        }
    }
}