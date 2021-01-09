using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository
    {
        private readonly DbContextClass _dbContext;
        DbSet<User> users;
        DbSet<Location> locations;
        DbSet<Order> orders;
        DbSet<Product> products;
        DbSet<Inventory> inventories;

        // For Testing Populating Database
        //List<Location> storeList = new List<Location>();
        public Repository(DbContextClass dbContextClass) {
            _dbContext = dbContextClass;
            this.users = _dbContext.users;
            this.locations = _dbContext.locations;
            this.orders = _dbContext.orders;
            this.products = _dbContext.products;
            this.inventories = _dbContext.inventories;
            PopulateDb();
        }

        public User LoginUser(User user)
        {
            User user1 = users.FirstOrDefault(x => x.Fname == user.Fname && x.Lname == user.Lname);

            if (user1 == null)
            {
                user1 = new User()
                {
                    Fname = user.Fname,
                    Lname = user.Lname,
                    DefaultStore = GetDefaultLocation()
                };
                users.Add(user1);
                _dbContext.SaveChanges();
            }
            return user1;
        }

        public Location GetDefaultLocation()
        {
            Location defaultLocation = locations.FirstOrDefault();
            return defaultLocation;
        }

        public List<User> GetAllUsers()
        {
            return users.ToList();
        }
        

        // INVENTORY METHODS //
        public List<Inventory> GetLocationProducts(Guid locationId)
        {
            List<Inventory> filteredInventories = new List<Inventory>();
            foreach (Inventory x in inventories)
            {
                if(x.Location.LocationId == locationId)
                {
                    filteredInventories.Add(x);
                }
            }
            return filteredInventories;
        }

        // LOCATION METHODS //

        public bool DoesLocationExist(Guid locationId)
        {
            if(locations.Any(x => x.LocationId == locationId))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public List<Location> GetAllLocations()
        {
            return locations.ToList();
        }





















        // Populate the Database if Empty
        //
        //
        /// <summary>
        /// Checks to see if Locations Table in Database is Empty
        /// If it is Empty populate with Data
        /// </summary>        
        public void ValidateLocationTable()
        {
            if (locations.Count() == 0)
            {
                locations.Add(new Location("Neverwinter"));
                locations.Add(new Location("Waterdeep"));
                locations.Add(new Location("Baldurs Gate"));
            }
            SaveChanges();
            //foreach (Location store in storeList)
            //{
            //    storeList.Add(store);
            //}
        }
        /// <summary>
        /// Checks to see if Products Table in Database is Empty
        /// If it is Empty populate with Data
        /// </summary>        
        public void ValidateProductTable()
        {
            if (products.Count() == 0)
            {
                products.Add(new Product("Melf's Minute Meteors", 1000, "You create six tiny meteors in your space."));
                products.Add(new Product("Acid Arrow", 500, "A shimmering green arrow streaks toward a target within range and bursts in a spray of acid."));
                products.Add(new Product("Unicorn Arrow", 600, "A translucent unicorn shape appears in midair and speeds toward the target of this spell."));
                products.Add(new Product("Universal Astronomy", 300, "A Book on Universal Astronomy. I'd tell you what''s in it, but no spoilers..."));
                products.Add(new Product("Weapons of the Ether", 300, "A Book on Weapons of the Either. I''d tell you what''s in it, but no spoilers..."));
            }
            SaveChanges();
            //foreach (Product store in products)
            //{
            //    products.Add(store);
            //}
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Calls all of the Methods Which Populate the Database with data if there is not already data in their respective table.
        /// </summary>
        public void PopulateDb()
        {
            ValidateLocationTable();
            ValidateProductTable();
            if (inventories.Count() == 0)
            {
                foreach (Location store in locations.ToList())
                {
                    if (store.InventoryItems.Count() < 1)
                    {
                        foreach (Product product in products.ToList())
                        {
                            AddInventoryItem(store, product, 10);
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
        public bool AddInventoryItem(Location store, Product product, int amount)
        {
            Inventory stockItem = new Inventory
            {
                Location = store,
                Product = product,
                Quantity = amount
            };
            inventories.Add(stockItem);
            SaveChanges();
            return true;
        }
    }
}
