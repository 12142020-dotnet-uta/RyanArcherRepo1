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
    public class LoginController : Controller
    {
        private BusinessLogicClass _businessLogicClass;
        public LoginController(BusinessLogicClass businessLogicClass) {
            _businessLogicClass = businessLogicClass;
        }

        // public object Session { get; private set; }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyLast = "_Last";
        public const string CustomerId = "_Id";
        public const string CustomerStore = "_Store";
        public const string CartId = "_Cart";
        const string SessionKeyTime = "_Time";


        // GET: LoginController
        //[ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }

        // GET: LoginController
        [ActionName("LoginUser")]
        public ActionResult Login(LoginUserViewModel loginUserViewModel)
        {
            // instead of doing logic here call a method in the business logoc 
            // layer to create the User, persist in the Db, and return a user to display.
            // user DI (Dependecy Injection) to get an instance of the business class and access to it's functionality.
            UserViewModel userViewModel = _businessLogicClass.LoginUser(loginUserViewModel);

            System.Diagnostics.Debug.WriteLine("Value of logging in UserId = " + loginUserViewModel.UserId);
            System.Diagnostics.Debug.WriteLine("Value of userViewModel is = " + userViewModel.UserID);
            Cart newCart = _businessLogicClass.CreateCart(userViewModel.UserID);

            // Set Session Data
            // Requires: using Microsoft.AspNetCore.Http;
            HttpContext.Session.SetString(SessionKeyName, userViewModel.Fname);
            HttpContext.Session.SetString(SessionKeyLast, userViewModel.Lname);
            HttpContext.Session.SetString(CustomerId, userViewModel.UserID.ToString());
            HttpContext.Session.SetString(CustomerStore, newCart.StoreId.ToString());
            HttpContext.Session.SetString(CartId, newCart.CartId.ToString());
            //Guid newGuid = Guid(HttpContext.Session.GetString("CustomerId"));
            //HttpContext.Session.SetString(CartId, )

            // Check Session Data in Output 
            System.Diagnostics.Debug.WriteLine("Value of UserID = " + userViewModel.UserID);
            System.Diagnostics.Debug.WriteLine("Value of Cookie First Name = " + HttpContext.Session.GetString(SessionKeyName));
            System.Diagnostics.Debug.WriteLine("Value of Cookie Last tName = " + HttpContext.Session.GetString(SessionKeyLast));
            System.Diagnostics.Debug.WriteLine("Value of Cookie CustomerId = " + HttpContext.Session.GetString(CustomerId));
            System.Diagnostics.Debug.WriteLine("Value of Cookie CustomerStore = " + HttpContext.Session.GetString(CustomerStore));
            System.Diagnostics.Debug.WriteLine("Value of Cookie CartId = " + HttpContext.Session.GetString(CartId));

            return View("DisplayUserDetails", userViewModel);
        }

        // GET: LoginController/Details/5
        [ActionName("ViewAccount")]
        public ActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View("Login");
            } else
            {
                User user = _businessLogicClass.GetUserById(id);
                UserViewModel userViewModel = _businessLogicClass.GetUserViewModel(user);
                return View("DisplayUserDetails", userViewModel);
            }
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
