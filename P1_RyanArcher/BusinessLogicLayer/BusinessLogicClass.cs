using ModelLayer;
using System.Collections.Generic;
using ModelLayer.ViewModels;
using RepositoryLayer;
using System;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        private readonly MapperClass _mapperClass;
        public Guid CurrentUserId;
        public Guid CurrentLocationId;

        public BusinessLogicClass(Repository repository, MapperClass mapperClass) {
            _repository = repository;
            _mapperClass = mapperClass;
        }

        // public object Session { get; private set; }
        //public const string SessionKeyName = "_Name";
        //public const string SessionKeyLast = "_Last";
        //public const string CustomerId = "_Id";
        //const string SessionKeyTime = "_Time";



                        //***** USER METHODS *****//
        /// <summary>
        /// Takes a LoginUserViewModel instances and returns a UserViewModel Instance
        /// </summary>
        /// <param name="loginUserViewModel"></param>
        /// <returns></returns>
        public UserViewModel LoginUser(LoginUserViewModel loginUserViewModel)
        {
            // Have all logic confined to this Business layer.
            User user = new User()
            {
                Fname = loginUserViewModel.Fname,
                Lname = loginUserViewModel.Lname,
                DefaultStoreId = _repository.GetDefaultLocationId()
            };

            User user1 = _repository.LoginUser(user);
            //CreateSession(user1);

            // Convert the User to a UserViewModel
            UserViewModel userViewModel = _mapperClass.ConvertUserToUserViewModel(user1);
            CurrentUserId = userViewModel.UserID;
            CurrentLocationId = userViewModel.DefaultStoreId;
            return userViewModel;
        }

        //public void CreateSession(User loggedUser, HttpContext context)
        //{
        //    System.Diagnostics.Debug.WriteLine("SignUp");

        //    // Requires: using Microsoft.AspNetCore.Http;
        //    context.Session.SetString(SessionKeyName, loggedUser.Fname);
        //    context.Session.SetString(SessionKeyLast, loggedUser.Lname);
        //    HttpContext.Session.SetInt32(CustomerId, loggedUser.UserId);



        //    return true;
        //}

        public UserViewModel GetUserViewModel(User user)
        {
            UserViewModel userViewModel = _mapperClass.ConvertUserToUserViewModel(user);
            return userViewModel;
        }
        public List<UserViewModel> GetAllUserViewModels()
        {
            List<User> allUsers = _repository.GetAllUsers();
            List<UserViewModel> allUserViewModels = new List<UserViewModel>();
            foreach(User x in allUsers)
            {
                UserViewModel userViewModel = _mapperClass.ConvertUserToUserViewModel(x);
                allUserViewModels.Add(userViewModel);
            }
            return allUserViewModels;
        }

        public UserViewModel EditedUser(UserViewModel userViewModel)
        {
            // get an instance of the user being edited.
            User user = _repository.GetUserById(userViewModel.UserID);

            user.Fname = userViewModel.Fname;
            user.Lname = userViewModel.Lname;
            
            User user1 = _repository.EditUser(user);
            UserViewModel userViewModel1 = _mapperClass.ConvertUserToUserViewModel(user1);
            return userViewModel1;
        }







                        //***** PRODUCT METHODS *****//

        public List<InventoryViewModel> GetLocationProductViewModels()
        {
            List<Inventory> locationInventories = _repository.GetLocationProducts(CurrentLocationId);
            List<InventoryViewModel> locationInventoryViewModels = new List<InventoryViewModel>();
            foreach (Inventory x in locationInventories)
            {
                InventoryViewModel inventoryViewModel = _mapperClass.ConvertInventoryToInventoryViewModel(x, GetProductById(x.ProductId), GetLocationById(x.LocationId));
                locationInventoryViewModels.Add(inventoryViewModel);
            }
            return locationInventoryViewModels;
        }








                    //****** LOCATION METHOD ******//

        public bool SetCurrentLocation(Guid locationId)
        {
            if (_repository.DoesLocationExist(locationId))
            {
                CurrentLocationId = locationId;
                return true;
            } else
            {
                return false;
            }
        }

        public List<LocationViewModel> GetAllLocationViewModels()
        {
            List<Location> allLocations = _repository.GetAllLocations();
            List<LocationViewModel> allLocationViewModels = new List<LocationViewModel>();
            foreach (Location x in allLocations)
            {
                LocationViewModel locationViewModel = _mapperClass.ConvertLocationToLocationViewModel(x);
                allLocationViewModels.Add(locationViewModel);
            }
            return allLocationViewModels;
        }

        public List<InventoryViewModel> GetAllStoreProductViewModels(Guid locationId)
        {
            List<Inventory> allInventories = _repository.GetAllInventories();
            List<InventoryViewModel> allLocationInventories = new List<InventoryViewModel>();
            foreach (Inventory x in allInventories)
            {
                if(x.LocationId == locationId)
                {
                    InventoryViewModel inventoryViewModel = _mapperClass.ConvertInventoryToInventoryViewModel(x, GetProductById(x.ProductId), GetLocationById(x.LocationId));
                    allLocationInventories.Add(inventoryViewModel);
                }
            }

            return allLocationInventories;
        }

        //public ProductViewModel GetProductViewModelById(Guid productId)
        //{
        //    List<Product> allProducts = _repository.GetAllProducts();
        //    List<ProductViewModel> allProductViewModels = new List<ProductViewModel>();
        //    foreach (Product x in allProducts)
        //    {
        //        if (x.ProductId == productId)
        //        {
        //            ProductViewModel productViewModel = _mapperClass.ConvertProductToProductViewModel(x, GetProductById(x.ProductId), GetLocationById(x.LocationId));
        //            allLocationInventories.Add(inventoryViewModel);
        //        }
        //    }
        //    return productViewModel;
        //}


        public Cart CreateCart(Guid userId)
        {
            List<Cart> allCarts = _repository.GetAllCarts();
            Cart cart = new Cart()
            {
                CartId = Guid.NewGuid(),
                StoreId = new Guid("42a320e9-276b-4540-824d-68775f048083"),
                UserId = userId
            };
            allCarts.Add(cart);
            return cart;
        }
        public List<CartViewModel> GetAllCartViewModels()
        {
            List<Cart> allCarts = _repository.GetAllCarts();
            List<CartViewModel> allCartViewModels = new List<CartViewModel>();
            foreach(Cart x in allCarts)
            {
                allCartViewModels.Add(_mapperClass.ConvertCartToCartViewModel(x));
            }
            return allCartViewModels;
        }

        public List<OrderViewModel> GetAllProductsInCart(Guid cartId)
        {

            List<Order> allOrders = new List<Order>();
            try { allOrders = _repository.GetAllOrders(); }
            catch {  }
            List<OrderViewModel> allProductsInCart = new List<OrderViewModel>();
            foreach (Order x in allOrders)
            {
                if (x.CartId == cartId)
                {
                    //OrderViewModel orderViewModel = _mapperClass.ConvertOrderToOrderViewModel(x, GetOrderById(x.OrderId), GetCartById(x.CartId));
                    OrderViewModel orderViewModel = _mapperClass.ConvertOrderToOrderViewModel(x);
                    allProductsInCart.Add(orderViewModel);
                }
            }

            return allProductsInCart;
        }

        public List<CartViewModel> GetAllCartsOfUser(Guid userId)
        {
            List<Cart> allUserCarts = _repository.GetCartByUser(userId);
            List<CartViewModel> allUserCartViewModels = new List<CartViewModel>();
            //foreach(Cart _mapperClass.ConvertCartToCartViewModel(usedId);
            return allUserCartViewModels;
        }

        public List<CartViewModel> GetCartsOfUser(Guid userId)
        {
            //Cart newCart = new Cart();
            List<Cart> allCarts = _repository.GetAllCarts();
            List<CartViewModel> allCartOfUserViewModels = new List<CartViewModel>();
            foreach(Cart x in allCarts)
            {
                if(x.UserId == userId)
                {
                    CartViewModel cartViewModel = _mapperClass.ConvertCartToCartViewModel(x);
                    allCartOfUserViewModels.Add(cartViewModel);
                }
            }
            return allCartOfUserViewModels;
        }
        public Guid GetCurrentCartId(Guid userId)
        {
            // Get a List of all Carts
            List<Cart> allCarts = _repository.GetAllCarts();
            Cart theCart = new Cart();
            // Loop through all the Carts for Cart that belongs to User.
            // If Cart belongs to the user check to see if Active.
            // If Cart is Active return the Cart's Id
            foreach(Cart x in allCarts)
            {
                if (x.UserId == userId)
                {
                    if(x.CartStatus == "Active")
                    {
                        return x.CartId;
                    }
                }
            }
            // Create a New Cart and return the Id
            theCart = new Cart();
            allCarts.Add(theCart);
            return theCart.CartId;
        }

        //public List<OrderViewModel> GetAllCartOrderViewModels(Guid cartId)
        //{
        //    List<OrderViewModel> listOfOrdersInCart = new List<OrderViewModel>();
        //    return listOfOrdersInCart;
        //}


        public OrderViewModel AddOrderToCart(Guid locationId, Guid productId, Guid userId, Guid cartId)
        {
            // Gets a Product by it's Id
            Location location = GetLocationById(locationId);
            Product product = GetProductById(productId);
            User user = _repository.GetUserById(userId);
            Cart cart = _repository.GetCartById(cartId);
            // Create new Order from Product
            Order newOrder = new Order
            {
                CartId = cartId,
                UserId = new Guid(),
                Total = product.Price,
                LocationId = new Guid(),
                ProductId = product.ProductId
            };
            // Add Order to Database
            _repository.AddOrderItem(location, product, user, cart);
            _repository.SaveChanges();
            // Convert Order to OderViewModel
            OrderViewModel orderViewModel = _mapperClass.ConvertOrderToOrderViewModel(newOrder);
            // Return OrderViewModel to CartController
            return orderViewModel;
        }



        //public PlayerViewModel LoginPlayer()


        public User GetUserById(Guid userId)
        {
            return _repository.GetUserById(userId);
        }
        public Product GetProductById(Guid productId)
        {
            return _repository.GetProductById(productId);
        }
        public Location GetLocationById(Guid locationId)
        {
            return _repository.GetLocationById(locationId);
        }
        public Cart GetCartById(Guid cartId)
        {
            return _repository.GetCartById(cartId);
        }
        public Inventory GetInventoryById(Guid inventoryId)
        {
            return _repository.GetInventoryById(inventoryId);
        }
        public Order GetOrderById(Guid orderId)
        {
            return _repository.GetOrderById(orderId);
        }




        public User GetCurrentUserById()
        {
            return _repository.GetUserById(CurrentUserId);
        }
    }
}
