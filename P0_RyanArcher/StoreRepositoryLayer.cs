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
        DbSet<Location> locations = DbContext.Locations;
        DbSet<Product> products = DbContext.Products;
        DbSet<Inventory> inventories = DbContext.Inventories;

        Location currentLocation;

        public Guid curLocation;
        // Display all ProductNames of Current Store from Inventory
        public List<string> GetCurrentProductNames(){
            List<string> products = new List<string>();
            // Loops through the inventory items and stores them into a Products List for access.
            foreach(Inventory inventory in InventoryItems){
                products.Add(inventory.Product.Name);
            }
            return products;
        }

        
        List<Location> storeList = new List<Location>();
        List<Product> productList = new List<Product>();
        List<Inventory> inventoryList = new List<Inventory>();
        public List<Inventory> InventoryItems {get;set;} = new List<Inventory>();

        /// <summary>
        /// Creates a user after verifying that the user does not already exist. returns the user obj
        /// </summary>
        /// <returns></returns>
        public User CreateUser(string fName = "null", string lName = "null", string eMail = "..@email.net") {
            User u1 = new User();
            u1 = users.Where(x => x.Fname == fName && x.Lname == lName).FirstOrDefault();

            if (u1 == null) {
                Console.WriteLine($"\nThere was not user with that name: Creating a new user for you.\nWelcome {fName} we own your soul now.\nHaha! Just kidding. That's only on Sacramental Soul Saturdays.");
                u1 = new User() {
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
        /// Converts string input form the user to its int32 variant if unsuccessful. Else it returns -1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int ConvertStringToInt(string input) {
            int result;
            bool logInOrQuitBool = int.TryParse(input, out result);
            if (logInOrQuitBool == false) {
                return -1;
            }
            else {
                return result;
            }
        }
        /// <summary>
        /// returns all user objects in List<User>
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            //return users;
            return users.ToList();
        }
        /// <summary>
        /// Returns all location objects in to a List of Location objects.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            //return locations;
            return locations.ToList();
        }
        /// <summary>
        /// returns all products in List<Location>
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            //return products;
            return products.ToList();
        }
        /// <summary>
        /// returns all inventory in List<Location>
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetInventories()
        {
            //return inventories;
            return inventories.ToList();
        }


        // Populate the Database if Empty
        //
        //
        /// <summary>
        /// Checks to see if Locations Table in Database is Empty
        /// If it is Empty populate with Data
        /// </summary>        
        public void ValidateLocationTable() {
            if (DbContext.Locations.Count() == 0)
            {
                DbContext.Locations.Add(new Location("Neverwinter"));
                DbContext.Locations.Add(new Location("Waterdeep"));
                DbContext.Locations.Add(new Location("Baldurs Gate"));
            }
            DbContext.SaveChanges();
            foreach (Location store in DbContext.Locations)
            {
                storeList.Add(store);
            }
        }
        /// <summary>
        /// Checks to see if Products Table in Database is Empty
        /// If it is Empty populate with Data
        /// </summary>        
        public void ValidateProductTable() {
            if (DbContext.Products.Count() == 0)
            {
                DbContext.Products.Add(new Product("Melf's Minute Meteors", 1000, "You create six tiny meteors in your space."));
                DbContext.Products.Add(new Product("Acid Arrow", 500, "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid."));
                DbContext.Products.Add(new Product("Unicorn Arrow", 600, "A translucent unicorn shape appears in midair and speeds toward the target of this spell."));
                DbContext.Products.Add(new Product("Universal Astronomy", 300, "A Book on Universal Astronomy. I'd tell you what''s in it, but no spoilers..."));
                DbContext.Products.Add(new Product("Weapons of the Ether", 300, "A Book on Weapons of the Either. I''d tell you what''s in it, but no spoilers..."));
            }
            DbContext.SaveChanges();
            foreach (Product store in DbContext.Products)
            {
                productList.Add(store);
            }
        }

        public void SaveChanges() {
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Calls all of the Methods Which Populate the Database with data if there is not already data in their respective table.
        /// </summary>
        public void PopulateDb(){
            ValidateLocationTable();
            ValidateProductTable();
            if (DbContext.Inventories.Count() == 0){
                foreach(Location store in DbContext.Locations.ToList()){
                    if(store.InventoryItems.Count()<1){
                        foreach(Product product in DbContext.Products.ToList()){
                            AddInventoryItem(store, product,10);
                        }
                    }
                } 
            }
        }

        /// <summary>
        /// Adds the selected Inventory Item to the Orders table in Context.
        /// </summary>
        /// <param name="store"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddInventoryItem(Location store,Product product,int amount) {
            Inventory stockItem = new Inventory{
                Location = store,
                Product = product,
                Quantity = amount
            };
            DbContext.Inventories.Add(stockItem);
            DbContext.SaveChanges();
            return true;
        }
        



    }
}