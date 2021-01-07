using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Order
    {
        [Key]
        public int Id{get;set;}
        public User User {get;set;}
        public int Total {get;set;}
        // FK
        public Location Location {get;set;}
        public Product Product {get;set;}
        
        public Order(){}

        public Order(Location store) {
            this.Location = store;
        }
    }
}