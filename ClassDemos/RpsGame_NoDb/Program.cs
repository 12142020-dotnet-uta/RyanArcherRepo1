using System;

namespace RpsGame_NoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("This is The Official Batch Rock-Paper-Sissors Game");

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

            // Version 2
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


        }
    }
}
