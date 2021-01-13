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
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public double Total { get; set; }
        // FK
        public Guid LocationId { get; set; }
        public Guid ProductId { get; set; }

        public string UserName { get; set; }
        public string LocationName { get; set; }
        public string ProductName { get; set; }
    }
}
