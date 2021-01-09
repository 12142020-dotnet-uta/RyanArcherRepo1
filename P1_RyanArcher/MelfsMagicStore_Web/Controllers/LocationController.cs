using BusinessLogicLayer;
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
    }
}
