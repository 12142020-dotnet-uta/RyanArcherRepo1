using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class User
    {
        public User(){}
        public User(Guid defaultstoreId, string fname = "null", string lname = "null", string email = "null")
        {
            
            this.Email = email;
            this.Fname = fname;
            this.Lname = lname;
            this.DefaultStoreId = defaultstoreId;
            // this.DefaultStore = 2;
            // "Chicago, IL"
        }


        // Create User Fields & Properties
        private Guid userID = Guid.NewGuid();
        [Key]
        public Guid UserId { get{ return userID; } set{ userID = value;} }
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

        //private string eMail;
        //public string Email {get{ return eMail; } 
        //    set {
        //    if (value is string && value.Length < 20 && value.Length > 0) {
        //            eMail = value;
        //        } else {throw new Exception("The user e-mail you sent is not valid");}
        //    }
        //}
        //
        //private string fName;
        //public string Fname {get { return fName; }
        //    set {
        //        if (value is string && value.Length < 20 && value.Length > 0) {
        //            fName = value;
        //        } else {throw new Exception("The user first name you sent is not valid");}
        //    }
        //}
        //
        //private string lName;
        //public string Lname {get { return lName; }
        //    set {
        //        if (value is string && value.Length < 20 && value.Length > 0) {
        //            lName = value;
        //        } else {throw new Exception("The user last name you sent is no valid");}
        //    }
        //}

    }
}