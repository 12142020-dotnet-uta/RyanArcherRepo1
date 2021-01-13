
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Product
    {
        public Product(){}
        public Product(string name = "null", int price = 0, string description = "null") {
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }
        private Guid productID = Guid.NewGuid();
        [Key]
        public Guid ProductId { get{ return productID; } set{ productID = value;} }

        [Display(Name = "Product Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Letters only please")]
        public string Name { get; set; }
        //public string Name {get{ return name; } 
        //    set {
        //    if (value is string && value.Length < 200 && value.Length > 0) {
        //            name = value;
        //        } else {throw new Exception("The product name is not valid");}
        //    }
        //}
        [Display(Name = "Price")]
        [Range(0,double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }
        //public int Price {get{ return price; } 
        //    set {
        //        price = value;
        //    // if (int.TryParse(value) && value.Length < 20 && value.Length > 0) {
        //    //         name = value;
        //    //     } else {throw new Exception("The product name is not valid");}
        //    }
        //}
        [Display(Name = "Description")]
        public string Description { get; set; }
        //public string Description {get{ return description; } 
        //    set {
        //    // if (value is string && value.Length < 20 && value.Length > 0) {
        //            description = value;
        //        // } else {throw new Exception("The product description is not valid");}
        //    }
        //}


        /*[Key]
        public Guid MatchId = Guid.NewGuid();
        */
        //private Guid matchId = Guid.NewGuid();
        //public Guid MatchId { get { return matchId; } }

        // public Player Player1 { get; set; } // always the computer
        // public Player Player2 { get; set; } // always the user.

        // public List<Round> Rounds = new List<Round>();

        // // private int p1RoundWins { get; set; } // ho many rounds has the player won?
        // // private int p2RoundWins { get; set; }
        // public int p1RoundWins { get; set; } // ho many rounds has the player won?
        // public int p2RoundWins { get; set; }
        // private int ties { get; set; }


        // /// <summary>
        // /// This is the description of the method called RoundWinner
        // /// This methodtakes an optional Player object and increments the numnber of round wins for that player.
        // /// no arguments means a tie.
        // /// </summary>
        // /// <param name="p"></param>
        // public void RoundWinner(Player p = null)
        // {
        //     if (p == null)
        //     {
        //         ties++;
        //     }
        //     else if (p.PlayerId == Player1.PlayerId)
        //     {
        //         p1RoundWins++;
        //     }
        //     else if (p.PlayerId == Player2.PlayerId)
        //     {
        //         p2RoundWins++;
        //     }
        // }

        // public Player MatchWinner()
        // {
        //     if (p1RoundWins == 2)
        //     {
        //         return Player1;
        //     }
        //     else if (p2RoundWins == 2)
        //     {
        //         return Player2;
        //     }
        //     else
        //     {
        //         return new Player();
        //     }
        // }





    }


}
