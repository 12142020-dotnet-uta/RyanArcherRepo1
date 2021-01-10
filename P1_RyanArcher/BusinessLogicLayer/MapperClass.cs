﻿using ModelLayer.ViewModels;
using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MapperClass
    {
        //private readonly BusinessLogicClass _businessLogicClass;
        //public MapperClass(BusinessLogicClass businessLogicClass)
        //{
        //    _businessLogicClass = businessLogicClass;
        //}
        public UserViewModel ConvertUserToUserViewModel(User user)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                UserID = user.UserId,
                Fname = user.Fname,
                Lname = user.Lname,
                Email = user.Email,
                DefaultStoreId = user.DefaultStoreId
                //Image = ConvertByteArrayToJpgString(u.Image)
            };
            return userViewModel;
        }

        /// <summary>
        /// Converts Inventory to InventoryViewModel
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public InventoryViewModel ConvertInventoryToInventoryViewModel(Inventory inventory, Product product)
        {
            //Product product = _businessLogicClass.GetProductById(inventory.ProductId);
            InventoryViewModel inventoryViewModel = new InventoryViewModel()
            {
                InventoryId = inventory.InventoryId,
                Quantity = inventory.Quantity,
                LocationId = inventory.LocationId,
                ProductId = inventory.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description

            };
            return inventoryViewModel;
        }

        public LocationViewModel ConvertLocationToLocationViewModel(Location location)
        {
            LocationViewModel locationViewModel = new LocationViewModel()
            {
                LocationId = location.LocationId,
                City = location.City
            };
            return locationViewModel;
        }
    }
}
