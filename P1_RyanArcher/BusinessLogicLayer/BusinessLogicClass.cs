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

        public List<OrderViewModel> GetAllProductsInCart(Guid cartId)
        {
            List<Order> allOrders = _repository.GetAllOrders();
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
            List<Cart> allCarts = _repository.GetAllCarts();
            Cart theCart = new Cart();
            foreach(Cart x in allCarts)
            {
                if (x.UserId == userId)
                {
                    if(x.CartStatus == "Active")
                    {
                        theCart = x;
                    }
                }
            }
            return theCart.CartId;
        }




        //public PlayerViewModel LoginPlayer()


        public Product GetProductById(Guid productId)
        {
            return _repository.GetProductById(productId);
        }


        public Location GetLocationById(Guid locationId)
        {
            return _repository.GetLocationById(locationId);
        }

        public User GetCurrentUserById()
        {
            return _repository.GetUserById(CurrentUserId);
        }
    }
}
