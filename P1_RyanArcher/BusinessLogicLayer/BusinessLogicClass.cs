using ModelLayer;
using System.Collections.Generic;
using ModelLayer.ViewModels;
using RepositoryLayer;
using System;

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

            // Convert the User to a UserViewModel
            UserViewModel userViewModel = _mapperClass.ConvertUserToUserViewModel(user1);
            CurrentUserId = userViewModel.UserID;
            CurrentLocationId = userViewModel.DefaultStoreId;
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

        public List<InventoryViewModel> GetLocationProductViewModels()
        {
            List<Inventory> locationInventories = _repository.GetLocationProducts(CurrentLocationId);
            List<InventoryViewModel> locationInventoryViewModels = new List<InventoryViewModel>();
            foreach (Inventory x in locationInventories)
            {
                InventoryViewModel inventoryViewModel = _mapperClass.ConvertInventoryToInventoryViewModel(x);
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

        //public PlayerViewModel LoginPlayer()
    }
}
