using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelfsMagic
{
    public class User
    {
        public User(){
            
        }
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
        public Guid UserId { get{ return userID; } set{ userID = value;} }

        private string eMail;
        public string Email {get{ return eMail; } 
            set {
            if (value is string && value.Length < 20 && value.Length > 0) {
                    eMail = value;
                } else {throw new Exception("The user e-mail you sent is not valid");}
            }
        }
                private string fName;
        public string Fname {get { return fName; }
            set {
                if (value is string && value.Length < 20 && value.Length > 0) {
                    fName = value;
                } else {throw new Exception("The user first name you sent is not valid");}
            }
        }

        private string lName;
        public string Lname {get { return lName; }
            set {
                if (value is string && value.Length < 20 && value.Length > 0) {
                    lName = value;
                } else {throw new Exception("The user last name you sent is no valid");}
            }
        }
        // private int defaultStore;
        // [ForeignKey("LocationId")]
        // public int DefaultStore { get => defaultStore; set => defaultStore = value; }
        // private Guid cartId = Guid.NewGuid();
        // [ForeignKey("CartId")]
        // public Guid CartId { get => cartId; set => cartId = value; }


        // //below is methods
        // /// <summary>
        // /// This method inrements the Wins or the player
        // /// </summary>
        // public void AddWin()
        // {
        //     NumWins++;
        // }

        // /// <summary>
        // /// This methods increments the wins of the player by the passed integer amount.
        // /// </summary>
        // /// <param name="x"></param>
        // public void AddWin(int x)
        // {
        //     NumWins += x;
        // }

        // public void AddLoss()
        // {
        //     NumLosses++;
        // }

        // public int[] GetWinLossRecord()
        // {
        //     int[] winsAndLosses = new int[2]; // create an array to hole the num of wins and losses

        //     winsAndLosses[0] = NumWins; // put in the wins and losses
        //     winsAndLosses[1] = NumLosses;

        //     return winsAndLosses; // return the array.
        // }

    }
}