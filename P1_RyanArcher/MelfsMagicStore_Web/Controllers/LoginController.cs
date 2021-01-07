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
            //User user = new User()
            //{
            //    Fname = loginUserViewModel.Fname,
            //    Lname = loginUserViewModel.Lname,
            //    Email = "",
            //    defaultStore = ""
            //};

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
