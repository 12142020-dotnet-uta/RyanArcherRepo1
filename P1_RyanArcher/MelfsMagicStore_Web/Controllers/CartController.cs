using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
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

        // public object Session { get; private set; }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyLast = "_Last";
        public const string CustomerId = "_Id";
        public const string CartId = "_Cart";
        public const string LocationId = "_Store";
        const string SessionKeyTime = "_Time";

        public IActionResult Index()
        {
            return View();
        }

        public Guid UserId { get { return _businessLogicClass.CurrentUserId; } set { } }

        public IActionResult ShowCart(Guid cartId)
        {
            // Check to see if User is logged in if not then redirect to Login page.
            Guid userId = new Guid();
            try { userId = new Guid(HttpContext.Session.GetString("_Id")); }
            catch { return RedirectToAction("Login", "Login"); };

            // Check to see if a CartId is stored in Session if not look for Active cart or create one & store in session.
            Guid newCart = new Guid();
            try { newCart = new Guid(HttpContext.Session.GetString("_Cart")); }
            catch {
                newCart = _businessLogicClass.GetCurrentCartId(cartId);
            }


        List<OrderViewModel> listOfProductsInOrder = _businessLogicClass.GetAllProductsInCart(newCart);
            return View(listOfProductsInOrder);
        }
        //[HttpPost]
        public IActionResult AddProductToCart(Guid id)
        {
            System.Diagnostics.Debug.WriteLine("The ProductId Passed from the View is = " + id);
            // Get User, Cart & Location Ids if they Exists Else Create New Guid Id or send error message. 
            Guid userId = new Guid();
            Guid cartId = new Guid();
            Guid locationId = new Guid();
            try { userId = new Guid(HttpContext.Session.GetString("_Id")); }
            catch { return RedirectToAction("Login", "Login"); }
            try {  cartId = new Guid(HttpContext.Session.GetString("_Cart")); }
            catch { return RedirectToAction("Login", "Login"); }
            try { locationId = new Guid(HttpContext.Session.GetString(LocationId)); }
            catch { return RedirectToAction("Login", "Login"); }
            // Add the new Order using the AddOrderMethod in BusinessLogicLayer to DB and return the OrderViewModel
            OrderViewModel theOrder = _businessLogicClass.AddOrderToCart(locationId, id, userId, cartId);


            // Create a List of all the OrderViewModels with the current CartId and send to the View to Display
            List<OrderViewModel> listOfProductsInCart = _businessLogicClass.GetAllProductsInCart(/*newLocationId/**//**/cartId/**/);

            //return View(listOfProductsInCart);
            //return RedirectToAction("ShowLocationInventory", "Location", new { id = locationId });
            return RedirectToAction("ShowCart", new { id = cartId });
            //try{
            //    System.Diagnostics.Debug.WriteLine("Trying the Session CartId = " + HttpContext.Session.GetString("_Cart"));
            //    cartId = new Guid(HttpContext.Session.GetString("_Cart"));
            //}
            //catch{
            //    // Save New CartId Guid into Cookie as a string
            //    HttpContext.Session.SetString(CartId, cartId.ToString());
            //    System.Diagnostics.Debug.WriteLine("Catch Exception New Session CartId = " + HttpContext.Session.GetString("_Cart"));
            //}
            //try { userId = new Guid(HttpContext.Session.GetString(CustomerId)); }
            //catch { 
            //    return RedirectToAction("Login", "Login");
            //}
            //try { locationId = new Guid(HttpContext.Session.GetString(LocationId)); }
            //catch { ViewData["error"] = "You must order from a valid location. Please try again."; }
            //// Add the new Order using the AddOrderMethod in BusinessLogicLayer to DB and return the OrderViewModel
            //OrderViewModel theOrder = _businessLogicClass.AddOrderToCart(locationId, productId, userId, cartId);

            //// Create a List of all the OrderViewModels with the current CartId and send to the View to Dispay
            //List<OrderViewModel> listOfProductsInCart = _businessLogicClass.GetAllProductsInCart(/*newLocationId/**//**/cartId/**/);
            ////return View(listOfProductsInCart);
            //return RedirectToAction("ShowLocationInventory", "Location", new { id = locationId});
        }


        public IActionResult ViewOrders()
        {
            List<CartViewModel> cartViewModel = _businessLogicClass.GetAllCartViewModels();


            return View("ViewOrders", cartViewModel);
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
