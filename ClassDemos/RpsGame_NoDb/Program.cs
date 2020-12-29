using System;
using System.Collections.Generic;

namespace RpsGame_NoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is The Official Batch Rock-Paper-Sissors Game");

            //Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 Aand hiiting enter.");
            //Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");
            //Console.WriteLine("2. Paper");
            //Console.WriteLine("3. Scissors");
            //string userResponse = Console.ReadLine();
            //var userResponse = Console.ReadLine(); //var will make it the proper type 'string'
            //Console.WriteLine(userResponse);
            //int userResponseInt = int.Parse(userResponse); //Will have an exception if noyt an int
            //try {int userResponseInt = int.Parse(userResponse);}
            //catch (FotmatException ex) {//throw new FormatException("There was a problem with parsing the user input", ex);}
            
            /*
            int number;
            bool userResponseParsed = int.TryParse(userResponse, out number);
            if(userResponseParsed == false) {
                // Error
            }
            */
            

            // CLASS EXAMPLE 
            /*
            int userChoice;
            bool userResponseParsed;
            do 
            {
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 Aand hiiting enter.");
                Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");
                var userResponse = Console.ReadLine(); //var will make it the proper type 'string'
                
                userResponseParsed = int.TryParse(userResponse, out userChoice);    // parse the users input to an int
 
                if(userResponseParsed == false || userChoice > 3 || userChoice < 1) // give a message if the users input was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                }
            } while (userResponseParsed == false || userChoice > 3 || userChoice < 1);  // state conditions for if we will repeat the loop

            Console.WriteLine("Starting the game...");

            Random randomNumber = new Random(10); // create a random number object
            int computerChoice = randomNumber.Next(1, 4); // get a random number 1, 2, or 3.

            Console.WriteLine(computerChoice);
            // Compare Two Choices
            if(userChoice == computerChoice) 
            {
                Console.WriteLine("The game was a tie");
            }
            else if((userChoice == 2 && computerChoice == 1) || 
                (userChoice == 3 && computerChoice == 2) ||
                (userChoice == 1 && computerChoice == 3)
                ) {
                Console.WriteLine("Congratulations you (the user) WON!");
            } 
            else 
            {
                Console.WriteLine("We're sorry.The computer won.");
            }
            */

            // GROUP 2 Ryan Archer, Anthony Mungle, Lucas Stang & Chris Sophiea
            // Version 1
            /*
            string userInput;
            int userSelection;
            bool userSelectionParsed;
            int botSelection;
            while (true)
            {
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 and hitting enter.");
                Console.WriteLine("\t1) Rock \n\t2) Paper \n\t3) Scissors");
                Console.Write("\nYour choice: ");
                userInput = Console.ReadLine();
                userSelectionParsed = int.TryParse(userInput, out userSelection);
                if (!userSelectionParsed || userSelection < 1 || userSelection > 3)
                {
                    Console.WriteLine("Input is invalid. Enter a number 1-3.");
                }
                else
                {
                    break;
                }
            }
            Random rnd = new Random();
            botSelection = rnd.Next(1, 4);
            switch (userSelection)
            {
                case 1:
                    switch (botSelection)
                    {
                        case 1: Console.WriteLine("Tie. You chose rock. Bot chose rock."); break;
                        case 2: Console.WriteLine("Lose. You chose rock. Bot chose paper."); break;
                        default: Console.WriteLine("Win. You chose rock. Bot chose scissors."); break;
                    }
                    break;
                case 2:
                    switch (botSelection)
                    {
                        case 1: Console.WriteLine("Win. You chose paper. Bot chose rock."); break;
                        case 2: Console.WriteLine("Tie. You chose paper. Bot chose paper."); break;
                        default: Console.WriteLine("Lose. You chose paper. Bot chose scissors."); break;
                    }
                    break;
                default:
                    switch (botSelection)
                    {
                        case 1: Console.WriteLine("Lose. You chose scissors. Bot chose rock."); break;
                        case 2: Console.WriteLine("Win. You chose scissors. Bot chose paper."); break;
                        default: Console.WriteLine("Tie. You chose scissors. Bot chose scissors."); break;
                    }
                    break;
                }
            }
            */
            /*
            public enum Choice{
                Rock,
                Paper,
                Scissors
            }
            */
            // Version 2
            /*
            Console.WriteLine("This is The Group 2 Awesome Rock-Paper-Sissors Game!\n");
            while(true) {
                int userSelection;
                bool userResponseParsed;
                int botSelection;
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 Aand hiiting enter.");
                Console.WriteLine("\t1. Rock \n\t2. Paper \n\t3. Scissors");
                var userResponse = Console.ReadLine(); //var will make it the proper type 'string'
                userResponseParsed = int.TryParse(userResponse, out userSelection);    // parse the users input to an int
                
                if(userResponseParsed == false || userSelection > 3 || userSelection < 1) // give a message if the users input was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                    continue;
                }

                Console.WriteLine("Starting the game...");

                Random rnd = new Random();
                botSelection = rnd.Next(1, 4);
                switch (userSelection)
                {
                    case 1:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Tie. You chose rock. Bot chose rock."); break;
                            case 2: Console.WriteLine("Lose. You chose rock. Bot chose paper."); break;
                            default: Console.WriteLine("Win. You chose rock. Bot chose scissors."); break;
                        }
                        break;
                    case 2:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Win. You chose paper. Bot chose rock."); break;
                            case 2: Console.WriteLine("Tie. You chose paper. Bot chose paper."); break;
                            default: Console.WriteLine("Lose. You chose paper. Bot chose scissors."); break;
                        }
                        break;
                    default:
                        switch (botSelection)
                        {
                            case 1: Console.WriteLine("Lose. You chose scissors. Bot chose rock."); break;
                            case 2: Console.WriteLine("Win. You chose scissors. Bot chose paper."); break;
                            default: Console.WriteLine("Tie. You chose scissors. Bot chose scissors."); break;
                        }
                        break;
                    }

                Console.WriteLine("\nWould you like to play again?\n\tType y for Yes\n\tType n for No\n");
                string playAgain = Console.ReadLine(); // User input and add into playAgain
                if(playAgain.ToLower() == "y" || playAgain.ToLower() == "yes") {
                    continue;
                } else {
                    Console.WriteLine("\nGood bye.");
                    break;
                }
            }
            */

            List<Player> players = new List<Player>();
            List<Match> matches = new List<Match>();
            List<Round> rounds = new List<Round>();

            /*
            Player p1 = new Player();
            p1.PlayerId = -1;
            Console.WriteLine(p1.PlayerId);
            Match myMatch = new Match();
            myMatch.RoundWinner();
            */

            // create the Computer that everyone plays against.
            Player p1 = new Player(){
                Fname = "Max",
                Lname = "Headroom"
            };
            players.Add(p1);


            //loging or create a new player. unique fName and lName means create a new player, other wise, grab the existing player
            string[] userNamesArray;
            do {
                Console.WriteLine("Please enter your firstname.\n If you enter a unique first and last name I will create a new player.");
                string userNames = Console.ReadLine();
                userNamesArray = userNames.Split(' ');
            } while(userNamesArray[0] == null);

            Player p2 = new Player();

            // create player 2's name based on if they have first and last name or not
            if(userNamesArray.Length > 1) {
                p2.Fname = userNamesArray[0];
                p2.Lname = userNamesArray[1];
            } else {
                p2.Fname = userNamesArray[0];
            }

            /*
            foreach(var name in userNamesArray){
                Console.WriteLine(name);
            }
            */

            players.Add(p2);
            Match match = new Match();
            match.Player1 = p1;
            match.Player2 = p2;

            Round round = new Round();


            // user will choose Rock, Paper, Scissors
            Choice userChoice;
            bool userResponseParsed;
            do 
            {
                Console.WriteLine($"Welcome, {p2.Fname}. Please choose Rock, Paper, or Scissors by typing 0, 1, or 2 Aand hiiting enter.");
                Console.WriteLine("\t0. Rock \n\t1. Paper \n\t2. Scissors");
                var userResponse = Console.ReadLine(); //var will make it the proper type 'string'
                
                userResponseParsed = Choice.TryParse(userResponse, out userChoice);    // parse the users input to an int
 
                if(userResponseParsed == false || (int)userChoice > 2 || (int)userChoice < 0) // give a message if the users input was invalid
                {
                    Console.WriteLine("Your response is invalid.");
                }
            } while (userResponseParsed == false || (int)userChoice > 2 || (int)userChoice < 0);  // state conditions for if we will repeat the loop

            Console.WriteLine("Starting the game...");

            Random randomNumber = new Random(10); // create a random number object
            Choice computerChoice = (Choice)randomNumber.Next(0, 3); // get a random number 0, 1, or 2.

            round.Player1Choice = computerChoice;
            round.Player2Choice = userChoice;

            Console.WriteLine($"The computer chose is => {computerChoice}.");
            // Compare Two Choices
            if(userChoice == computerChoice) 
            {
                Console.WriteLine("The game was a tie");
                // round winning player is null by default
                match.RoundWinner();
            }
            else if(((int)userChoice == 1 && (int)computerChoice == 0) || 
                ((int)userChoice == 2 && (int)computerChoice == 1) ||
                ((int)userChoice == 0 && (int)computerChoice == 2)
                ) {
                Console.WriteLine("Congratulations you (the user) WON!");
                round.WinningPlayer = p2;
                match.RoundWinner(p2);
            } 
            else 
            {
                Console.WriteLine("We're sorry.The computer won.");
                round.WinningPlayer = p1;
                match.RoundWinner(p1);
            }
            rounds.Add(round);
            match.Rounds.Add(round);

            foreach(Round round1 in rounds) {
                Console.WriteLine($"\nROUND - \nThe GUID is {round.RoundId.ToString()}.\nP1 Choice is {round.Player1Choice}\nP1 Choice is {round.Player1Choice}\n The winning player is {round.WinningPlayer.Fname}");
            }

        }
    }
}
