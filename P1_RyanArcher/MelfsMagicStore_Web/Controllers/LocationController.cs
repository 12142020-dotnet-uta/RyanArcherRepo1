using BusinessLogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelfsMagicStore_Web.Controllers
{
    public class LocationController : Controller
    {
        private BusinessLogicClass _businessLogicClass; // Get access to the DbContext through BusinessLogicClass
        public LocationController(BusinessLogicClass businessLogicClass)
        {
            // Creates instance of the businessLogicClass for use in UserController as a service.
            _businessLogicClass = businessLogicClass;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAllLocations()
        {
            List<LocationViewModel> listOfLocations = _businessLogicClass.GetAllLocationViewModels();
            return View(listOfLocations);
        }

        //[HttpPost]
        //[ActionName("ViewStore")]
        //public ActionResult ViewStore(Guid locationId)
        //{
        //    ViewBag.CaseId = locationId;
        //    List<InventoryViewModel> listOfProductsInStore = _businessLogicClass.GetAllStoreProductViewModels(locationId);
        //    return View(listOfProductsInStore);
        //    //if (!ModelState.IsValid) { return View(locationViewModel); }
        //    //// call a method on BusinessLogic Layer that will take a locationId and return a InventoryView Model
        //    //List<InventoryViewModel> inventoryViewModel = _businessLogicClass.GetAllStoreProductViewModels(locationViewModel.LocationId);
        //    //return View(inventoryViewModel);
        //}

        ////[Authorize]
        //[Route("set-store-view")]
        //public IActionResult SetStoreView(string value)
        //{

        //    List<InventoryViewModel> listOfProductsInStore = _businessLogicClass.GetAllStoreProductViewModels(Guid.Parse(value));
        //    return View(listOfProductsInStore);

        //}
        //public IActionResult AnchorTagHelper(Guid id)
        //{
        //    var speaker = new InventoryViewModel
        //    {
        //        LocationId = id
        //    };

        //    return View(speaker);
        //}


        //public ActionResult ShowLocationInventory(Guid locationId)
        //{
        //    Guid newLocationId = Guid.Parse("a7ebefbb-b7cb-423a-ac62-03bbaf9d2062");
        //    List<InventoryViewModel> listOfProductsInStore = _businessLogicClass.GetAllStoreProductViewModels(/**/newLocationId/**//*locationId/**/);
        //    return View(listOfProductsInStore);
        //}
        public IActionResult ShowLocationInventory(Guid id)
        {
            //Guid newLocationId = Guid.Parse("a7ebefbb-b7cb-423a-ac62-03bbaf9d2062");
            List<InventoryViewModel> listOfProductsInStore = _businessLogicClass.GetAllStoreProductViewModels(/*newLocationId/**//**/id/**/);
            return View(listOfProductsInStore);
        }
    }
}
