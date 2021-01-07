using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    class UserViewModel
    {
        public class User
        {
            public User() { }
            public User(string fname = "null", string lname = "null", string email = "null")
            {

                this.Email = email;
                this.Fname = fname;
                this.Lname = lname;
                // this.DefaultStore = 2;
                // "Chicago, IL"
            }


            // Create User Fields & Properties
            private Guid userID = Guid.NewGuid();
            [Key]
            public Guid UserId { get { return userID; } set { userID = value; } }
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
            public string defaultStore { get; set; }
        }
    }
}
