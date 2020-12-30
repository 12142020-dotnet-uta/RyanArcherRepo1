using System;
using System.Collections.Generic;
using System.Linq;

namespace MelfsMagic
{
    class Program
    {
        static List<Order> orderList = new List<Order>();
        // static Location curStore;
        static StoreRepositoryLayer storeContext = new StoreRepositoryLayer(); // create the context here to acceess it in all methods of this class
        // static int numberOfChoices = Enum.GetNames(typeof(Choice)).Length;
        static void Main(string[] args)
        {
            
            List<Location> storeList = new List<Location>();
            List<Product> productList = new List<Product>();
            List<Order> orders = new List<Order>();
            // User p1 = storeContext.CreateUser("Max", "HeadRoom", "test@email.net"); // create the computer
            // storeContext.ValidateLocationTable();
            // storeContext.ValidateProductTable();
            // storeContext.ValidateInventoryTable(storeList, productList);
            storeContext.PopulateDb();
            // storeContext.ValidateOrder();

            Console.WriteLine("Welcome to Melf's Magic Store \n\tWhich is now Online!\n\tIf anyone in D&D even has a computer.");

            // program loop starts here.
            int logInOrQuitInt;
            // Location curStore;
            // get all db info and store in Lists.
            List<Location> locations = storeContext.GetLocations();
            List<User> users = storeContext.GetUsers();
            List<Product> products = storeContext.GetProducts();
            List<Inventory> inventories = storeContext.GetInventories();
            // List<Order> orders = orderList.GetOrders();
            do
            {
                //Menu to log in or quit. start loop for logged in user. exits when he logs out
                logInOrQuitInt = WelcomeMenu();
                if (logInOrQuitInt == 2) { break; }
                //log in or create a new user. unique fName and lName means create a new player, other wise, grab the existing player
                string[] userNamesArray = GetUserNames();

                User p2;
                if (userNamesArray.Length == 1)                                         //if the user input just one name
                { p2 = storeContext.CreateUser(fName: userNamesArray[0]); }
                else if (userNamesArray.Length > 1)                                     //if the user input 2 names
                { p2 = storeContext.CreateUser(userNamesArray[0], userNamesArray[1]); }
                else
                { throw new ArgumentNullException("User input for name was invalid."); } // if the userNamesArray is empty.

                int response1Parsed;
                do // Store Loop starts here.
                {
                    PrintUserData(users);
                    
                    Location curStore = LocationMenu(locations);
                    StoreMenu(curStore, inventories);
                    // Console.WriteLine($"Curent Store Location after method is: {curStore.City}");
                    // StoreMenu(curStore, inventories);
                    // Order curOrder = new Order(curStore); 
                    // orderList.Add(curOrder);
                    // CartMenu(curStore, curOrder);



                    // End of Loop
                    do {
                        Console.WriteLine("Do you want to shop again? Enter 1 to shop again, Enter 2 to Log out.");
                        string response1 = Console.ReadLine();
                        bool r1pBool = int.TryParse(response1, out response1Parsed);
                        if (r1pBool == false) {
                            Console.WriteLine("What you entered was not a valid option.\nEnter 1 to play again, Enter 2 to Log out.");
                        }
                    } while (response1Parsed != 1 && response1Parsed != 2); // shop again or quit.
                } while (response1Parsed == 1);// end of the main loop.
            } while (logInOrQuitInt != 2); // log out


            // PrintUserData(users);
            // PrintLocationData(locations);
            // curStore = LocationMenu(locations);
            // StoreMenu(curStore, inventories);
            // PrintProductData(products);

        }// END Main end

        /// <summary>
        /// Gives the user the choice to log in or quit the program
        /// </summary>
        /// <returns></returns>
        public static int WelcomeMenu() {
            int logInOrQuitInt;
            do {
                Console.WriteLine("Enter 1 to log in and 2 to quit the program.");
                //call a method to validate user input.
                logInOrQuitInt = storeContext.ConvertStringToInt(Console.ReadLine());
                // string logInOrQuit = Console.ReadLine();
                // bool logInOrQuitBool = int.TryParse(logInOrQuit, out logInOrQuitInt);
                if (logInOrQuitInt == -1)
                { Console.WriteLine("I SAID... Enter 1 to play again, Enter 2 to Log out. Get it right!"); }
            } while (logInOrQuitInt != 1 && logInOrQuitInt != 2);// loop runs till the user selects 1 or 2
            return logInOrQuitInt;
        }

        /// <summary>
        /// takes a user input string and max number. Verifies that that string can be converted to a int and tha thte int is within the range.
        /// returns -1 if the string cannot be converted to an int, returns the index of the choice otherwise
        /// </summary>
        /// <param name="input"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int verifyNumber(string input, int max) {
            int returnInt;
            bool result = int.TryParse(input, out returnInt);

            if(result == true){
                if(returnInt >0 && returnInt <= max){
                    return (returnInt-1);
                }
                else {
                    return -1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the users name and returns a  string array of those names.
        /// If the user inputs more than 2 names only the first 2 are taken.
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserNames()
        {
            string[] userNamesArray;
            do
            {
                Console.WriteLine("\n\tPlease enter your first and last name.\n\tIf you enter unique first and last name I will create a new player.\n");
                userNamesArray = Console.ReadLine().Trim().Split(' ');
                //userNames.Trim(); // take out whitespace;
                //userNamesArray = userNames.Split(' ');
            } while (userNamesArray[0] == "");

            return userNamesArray;
        }

        public static void PrintUserData(List<User> p)
        {
            // int i = 1;
            foreach (User user in p)
            {
                Console.WriteLine($"\n\t\tUser Profile for {user.Fname} {user.Lname}.");
                Console.WriteLine($"\tFirst name is {user.Fname}.");
                Console.WriteLine($"\tLast Name is {user.Lname}.");
                Console.WriteLine($"\tE-mail Address is {user.Email}.\n");
                // Console.WriteLine($"\tDefault Location is {user.DefaultStore}.");
            }

        }

        public static void PrintLocationData(List<Location> p)
        {
            int i = 1;
            foreach (Location location in p)
            {
                Console.WriteLine($"\t{i++} - {location.City}");
            }
            LocationMenu(p);
        }
        public static Location LocationMenu(List<Location> p) {
            int i = 1;
            Console.WriteLine("\nSelect the store location:");
            foreach (Location o in p)
            {
                Console.WriteLine($"\t{i++} - {o.City}");
            }
            string userChoice = Console.ReadLine();
            int choice = verifyNumber(userChoice, p.Count);
            Console.WriteLine($"Location Selected: {p.ElementAt(choice).City}.");
            return p.ElementAt(choice);
            // return Location[0];
        }
        public static void StoreMenu(Location curStore, List<Inventory> p) {
            // int i = 1;
            Console.WriteLine($"\nWelcome to {curStore.City}");
            // foreach(Inventory inventory in curStore.InventoryItems){
            //     Console.WriteLine($"\t{i++} - {inventory.Product.Name} for ${inventory.Product.Price} - {inventory.Quantity} Left in Stock.");
            // }
            Inventory curItem = AddItem(curStore, p);
        }

        public static Inventory AddItem(Location curStore, List<Inventory> p) {
            int i = 1;
            Console.WriteLine("Select the product you would like to add to cart:");
            foreach (Inventory inventory in curStore.InventoryItems){
                Console.WriteLine($"\t{i++} - {inventory.Product.Name} for ${inventory.Product.Price} - {inventory.Quantity} Left in Stock.");
            }
            string userChoice = Console.ReadLine();
            int choice = verifyNumber(userChoice, p.Count);
            Inventory cInv = p.ElementAt(choice);
            Console.WriteLine($"Product Selected: {p.ElementAt(choice).Product.Name}.");
            Order tempOrder = new Order(cInv.Location);
            orderList.Add(tempOrder);
            DbContext.SaveChanges();

            return cInv;
        }

        // public static void CartMenu(Location store, Order order){
        //     Console.WriteLine("Your Cart:");
        //     foreach(Order o in orderList){
        //         if(store == o.Location) {
        //             Console.WriteLine($"Order Number {o.OrderId} from the {o.Location.City} store.");
        //         }
        //     }
        // }




    }// END Class
}// END namespace
