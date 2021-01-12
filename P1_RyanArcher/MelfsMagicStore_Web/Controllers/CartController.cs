using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelfsMagicStore_Web.Controllers
{
    public class CartController : Controller
    {
        private BusinessLogicClass _businessLogicClass; // Get access to the DbContext through BusinessLogicClass
        public CartController(BusinessLogicClass businessLogicClass)
        {
            // Creates instance of the businessLogicClass for use in CartController as a service.
            _businessLogicClass = businessLogicClass;
        }
        public IActionResult Index()
        {
            return View();
        }

        public Guid UserId { get { return _businessLogicClass.CurrentUserId; } set { } }

        public IActionResult ShowCart(Guid cartId)
        {
            Guid curGuid = new Guid();
            try
            {
                curGuid = new Guid(HttpContext.Session.GetString("_Id"));
            }
            catch
            {
                //Guid curGuid = new Guid();
            }
            //curGuid = new Guid(HttpContext.Session.GetString("_Id"));
            System.Diagnostics.Debug.WriteLine("Value of Cookie curGuid = " + curGuid);
            //Guid newCartId = Guid.Parse("a7ebefbb-b7cb-423a-ac62-03bbaf9d2062");
            //Guid curCartId = _businessLogicClass.GetCartsOfUser(_businessLogicClass.CurrentUserId);
            Guid curCartId = _businessLogicClass.GetCurrentCartId(curGuid);
            List<OrderViewModel> listOfProductsInOrder = _businessLogicClass.GetAllProductsInCart(/**/curCartId/**//*cartId/**/);
            return View(listOfProductsInOrder);
        }


        // POST: CartController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
