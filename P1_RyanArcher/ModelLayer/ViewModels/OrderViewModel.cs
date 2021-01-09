using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public int Total { get; set; }
        // FK
        public Location Location { get; set; }
        public Product Product { get; set; }
    }
}
