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

            System.Diagnostics.Debug.WriteLine("Value of " + loginUserViewModel.UserId);

            // Requires: using Microsoft.AspNetCore.Http;
            HttpContext.Session.SetString(SessionKeyName, userViewModel.Fname);
            HttpContext.Session.SetString(SessionKeyLast, userViewModel.Lname);
            HttpContext.Session.SetString(CustomerId, userViewModel.UserID.ToString());
            //Guid newGuid = Guid(HttpContext.Session.GetString("CustomerId"));


            System.Diagnostics.Debug.WriteLine("Value of " + userViewModel.UserID);
            System.Diagnostics.Debug.WriteLine("Valie of Cookie CustomerId = " + HttpContext.Session.GetString(CustomerId));

            return View("DisplayUserDetails", userViewModel);
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
