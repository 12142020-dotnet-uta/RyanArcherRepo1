using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ModelLayer
{
    public class Location
    {
        // static int locationIdNum = 0;
        private Guid locationID = Guid.NewGuid();
        [Key]
        public Guid LocationId { get{ return locationID; } set{ locationID = value;} }
        public Location() { 
        }
        
        public Location(string city) {
            // this.LocationId = locationId;
            this.City = city;
        }
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if (value is string && value.Length < 20 && value.Length > 0)
                {
                    city = value;
                }
                else
                {
                    throw new Exception("The city name you sent is not valid");
                }
            }
        }

        public List<Inventory> InventoryItems {get;set;} = new List<Inventory>();

        /*[Key]
        public Guid RoundId = Guid.NewGuid();
        */
        //public Guid RoundId { get { return roundId; } }
        // public Choice Player1Choice { get; set; } // always the computer
        // public Choice Player2Choice { get; set; } // always the user
        // public User WinningPlayer { get; set; } = new User()
        // {
        //     Fname = "TieGame",
        //     Lname = "TieGame"
        // };
    }
}