using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace MelfsMagic
{
    public class StoreRepositoryLayer
    {  
        // int numberOfChoices = Enum.GetNames(typeof(Choice)).Length; // get a always-current number of options of Enum Choice
        // Random randomNumber = new Random((int)DateTime.Now.Millisecond); // create a random number object

        static StoreDbContext DbContext = new StoreDbContext(); // Create Database Object
        DbSet<User> users = DbContext.users;
        DbSet<Location> locations = DbContext.locations;
        DbSet<Product> products = DbContext.products;

        public Guid curLocation;

        
        List<Location> storeList = new List<Location>();

        /// <summary>
        /// Creates a player after verifying that the player does not already exist. returns the player obj
        /// </summary>
        /// <returns></returns>
        public User CreateUser(string fName = "null", string lName = "null", string eMail = "..@email.net")
        {
            ValidateLocationTable();
            User u1 = new User();
            u1 = users.Where(x => x.Fname == fName && x.Lname == lName).FirstOrDefault();
            //p1 = DbContext.players.Where(x => x.Fname == fName && x.Lname == lName).FirstOrDefault();

            if (u1 == null)
            {
                u1 = new User()
                {
                    Email = eMail,
                    Fname = fName,
                    Lname = lName,
                    // DefaultStore = 3
                };
                users.Add(u1);
                //DbContext.SaveChanges();
            }
            DbContext.SaveChanges();
            return u1;
        }

        /// <summary>
        /// Converts string input fornt he user to its int32 variant. If unsuccessful, returns -1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int ConvertStringToInt(string input)
        {
            int result;
            bool logInOrQuitBool = int.TryParse(input, out result);
            if (logInOrQuitBool == false)
            {
                return -1;
            }
            else
            {
                return result;
            }
        }


        public void ValidateLocationTable() {
            if (DbContext.locations.Count() == 0)
            {
                DbContext.locations.Add(new Location("New York, NY"));
                DbContext.locations.Add(new Location("Orlando, FL"));
                DbContext.locations.Add(new Location("Los Angeles, CA"));
                DbContext.locations.Add(new Location("Palo Alto, CA"));
                DbContext.locations.Add(new Location("Chicago, IL"));
            }
            DbContext.SaveChanges();
            foreach (Location store in DbContext.locations)
            {
                storeList.Add(store);
            }
        }
        // public void ValidateProductTable()
        // {
        //     if (DbContext.Products.Count() == 0)
        //     {
        //         List<Product> productList = new List<Product>();
        //         string[] descriptions = {"Ball-in-a-Cup Game", "Left Shoe", "Broken Soldering Iron", "Wedge of Cheese", "Straightened Paperclip"};
        //         decimal[] prices = {5.00m, 7.83m, 8.41m, 4.99m, 0.99m};
        //         for (int i = 0; i < 5; i++)
        //         {
        //             Product newProduct = new Product();
        //             newProduct.Description = $"{descriptions[i]}";
        //             newProduct.Price = prices[i];
        //             DbContext.Products.Add(newProduct);
        //         }
        //         DbContext.SaveChanges();
        //     }

        // }
        // public void ValidateInventory()
        // {
        //     if (DbContext.InventoryLines.Count() == 0)
        //     {
        //         foreach (Location location in DbContext.Locations)
        //         {
        //             foreach (Product product in DbContext.Products)
        //             {
        //                 DbContext.InventoryLines.Add(new InventoryLine(location.LocationId, product.ProductId, 99));
        //             }
        //         }
        //         DbContext.SaveChanges();
        //     }
        // }




        // /// <summary>
        // /// takes 2 players, creates  match with those players and returns the match.
        // /// </summary>
        // /// <param name="p1"></param>
        // /// <param name="p2"></param>
        // /// <returns></returns>
        // public Match CreateMatch(Player p1, Player p2)
        // {
        //     Match match = new Match();
        //     match.Player1 = p1;
        //     match.Player2 = p2;
        //     return match;
        // }

        // /// <summary>
        // /// takes a new match instance and saves it to the List<Match> (or context).
        // /// If the match already exists, returns false.
        // /// </summary>
        // /// <returns></returns>
        // public bool SaveMatch(Match match)
        // {
        //     //check if the match is already there
        //     //if (!matches.Exists(x => x.MatchId == match.MatchId))
        //     if (!matches.Any(x => x.MatchId == match.MatchId))
        //     {
        //         matches.Add(match);
        //         DbContext.SaveChanges();
        //         return true;
        //     }
        //     else return false;
        // }

        // /// <summary>
        // /// returns a random Choice Enum based on the number of options.
        // /// </summary>
        // /// <returns></returns>
        // public Choice GetRandomChoice()
        // {
        //     return (Choice)randomNumber.Next(numberOfChoices);
        // }

        // /// <summary>
        // /// plays an entire round and adds the completedd round to the List<Match>, roiund to the List<Round>
        // /// </summary>
        // /// <param name="match"></param>
        // /// <param name="computerChoice"></param>
        // /// <param name="userChoice"></param>
        // /// <returns></returns>
        // public Round PlayRound(Match match, Choice computerChoice, Choice userChoice)
        // {
        //     Round round = new Round();
        //     round.Player1Choice = computerChoice;
        //     round.Player2Choice = userChoice;
        //     if (userChoice == computerChoice)   // is the playes tied
        //     {
        //         round.WinningPlayer = CreatePlayer("TieGame", "TieGame");
        //         rounds.Add(round);
        //         match.Rounds.Add(round);
        //         match.RoundWinner(); // send in the player who won. empty args means a tie round
        //         //DbContext.SaveChanges();
        //     }
        //     else if (((int)userChoice == 1 && (int)computerChoice == 0) || // if the user won
        //         ((int)userChoice == 2 && (int)computerChoice == 1) ||
        //         ((int)userChoice == 0 && (int)computerChoice == 2))
        //     {
        //         round.WinningPlayer = match.Player2;
        //         rounds.Add(round);
        //         match.Rounds.Add(round);
        //         match.RoundWinner(match.Player2);
        //         //DbContext.SaveChanges();
        //     }
        //     else
        //     {
        //         round.WinningPlayer = match.Player1;
        //         rounds.Add(round);
        //         match.Rounds.Add(round);
        //         match.RoundWinner(match.Player1);
        //         //DbContext.SaveChanges();
        //     }
        //     DbContext.SaveChanges();
        //     return round;
        // }

        // /// <summary>
        // /// adds the completed match to the List<Match> if it ins't already in the List.
        // /// returns true if the match was successfully added, false if the matchId already exists
        // /// </summary>
        // /// <param name="match"></param>
        // public bool AddCompletedMatch(Match match)
        // {
        //     //if (!matches.Exists(x => x.MatchId == match.MatchId))
        //     if (!matches.Any(x => x.MatchId == match.MatchId))
        //     {
        //         matches.Add(match);
        //         DbContext.SaveChanges();
        //         return true;
        //     }
        //     DbContext.SaveChanges();
        //     return false;
        // }

        // /// <summary>
        // /// Updates the win/Loss records of both players in the match sent as an argument
        // /// </summary>
        // /// <param name="match"></param>
        // public void UpdateWinLossRecords(Match match)
        // {
        //     if (match.MatchWinner().PlayerId == match.Player1.PlayerId)
        //     {
        //         match.Player1.AddWin();
        //         match.Player2.AddLoss();
        //     }
        //     else if (match.MatchWinner().PlayerId == match.Player2.PlayerId)
        //     {
        //         match.Player2.AddWin();
        //         match.Player1.AddLoss();
        //     }
        // }

        // /// <summary>
        // /// returns all match objects in List<Match>
        // /// </summary>
        // /// <returns></returns>
        // public List<Match> GetMatches()
        // {
        //     //return matches;
        //     return matches.ToList();
        // }

        /// <summary>
        /// returns all user objects in List<User>
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            //return players;
            return users.ToList();
        }
        /// <summary>
        /// returns all location objects in List<Location>
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            //return players;
            return locations.ToList();
        }


    }
}