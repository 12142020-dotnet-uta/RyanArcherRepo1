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
            // foreach(Inventory inventory in currentLocation.InventoryItems){
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
        /// Creates a player after verifying that the player does not already exist. returns the player obj
        /// </summary>
        /// <returns></returns>
        public User CreateUser(string fName = "null", string lName = "null", string eMail = "..@email.net")
        {
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
        /// returns all location objects in List<Location>
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
                DbContext.Products.Add(new Product("Unicorn Arrow", 300, "A Book on Universal Astronomy. I'd tell you what''s in it, but no spoilers..."));
                DbContext.Products.Add(new Product("Weapons of the Ether", 300, "A Book on Weapons of the Either. I''d tell you what''s in it, but no spoilers..."));
            }
            DbContext.SaveChanges();
            foreach (Product store in DbContext.Products)
            {
                productList.Add(store);
            }
        }
        
        /// <summary>
        /// Checks to see if Inventory Table in Database is Empty
        /// If it is Empty populate with Data
        /// </summary>        
        // public void ValidateInventoryTable(List<Location> st, List<Product> prod) {
        //     if (DbContext.Inventories.Count() == 0)
        //     {
        //         Console.WriteLine("Inventories Table Is Empty.");
        //         foreach(Location o in st) {
        //             foreach(Product y in prod) {
        //                 DbContext.Inventories.Add(new Inventory(o.City, y.Name, 50));
        //                 Console.WriteLine($"Adding {y.Name} to {o.City}");
        //             }
        //         }
        //         // foreach(Location o in store) {
        //         //     foreach(Product y in prod) {
        //         //         DbContext.Inventories.Add(new Inventory(o.LocationId, y.ProductId, 50));
        //         //     }
        //         // }
        //         // DbContext.products.Add(new Product("Acid Arrow", 500, "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid."));
        //         // DbContext.products.Add(new Product("Unicorn Arrow", 600, "A translucent unicorn shape appears in midair and speeds toward the target of this spell."));
        //         // DbContext.products.Add(new Product("Unicorn Arrow", 300, "A Book on Universal Astronomy. I'd tell you what''s in it, but no spoilers..."));
        //         // DbContext.products.Add(new Product("Weapons of the Ether", 300, "A Book on Weapons of the Either. I''d tell you what''s in it, but no spoilers..."));
        //     }
        //     DbContext.SaveChanges();
        //     foreach (Inventory store in DbContext.Inventories) {
        //         inventoryList.Add(store);
        //     }
        // }
        public void PopulateDb(){
            ValidateLocationTable();
            ValidateProductTable();
            // if(DbContext.Locations.Count()<1){
            //     for(int i = 0;i<3;i++){
            //         AddLocationToDb("Store "+i);
            //     }
            // }
            // if(DbContext.Products.Count()<1){
            //     for(int i = 0;i<3;i++){
            //         AddProductToDb("Product "+i,i+1,"Something Special");
            //     }
            // }
            // Restock Stores
            if (DbContext.Inventories.Count() == 0){
                foreach(Location store in DbContext.Locations.ToList()){
                    // if(DbContext.Inventories.Count() == 0){
                    if(store.InventoryItems.Count()<1){
                        foreach(Product product in DbContext.Products.ToList()){
                            AddInventoryItem(store, product,10);
                        }
                    }
                } 
            }
        }

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