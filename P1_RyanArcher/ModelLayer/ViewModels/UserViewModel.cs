using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class UserViewModel
    {

            public Guid UserID { get; set; } = Guid.NewGuid();

            [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be between 3 & 20 characters long.")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
            [Required]
            [Display(Name = "First Name")]
            public string Fname { get; set; }

            [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be between 3 & 20 characters long.")]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
            [Required]
            [Display(Name = "Last Name")]
            public string Lname { get; set; }
            public string Email { get; set; }
            public Guid DefaultStoreId { get; set; }

            //public string jpgStringImage { get; set; }

    }
}
