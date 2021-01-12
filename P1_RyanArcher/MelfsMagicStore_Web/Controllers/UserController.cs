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
    public class UserController : Controller
    {
        private BusinessLogicClass _businessLogicClass; // Get access to the DbContext through BusinessLogicClass
        public UserController(BusinessLogicClass businessLogicClass)
        {
            // Creates instance of the businessLogicClass for use in UserController as a service.
            _businessLogicClass = businessLogicClass;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListAllUsers()
        {
            List<UserViewModel> listOfUsers = _businessLogicClass.GetAllUserViewModels();
            return View(listOfUsers);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        [HttpPost]
        [ActionName("EditedUser")]
        public ActionResult EditUser(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) { return View(userViewModel); }

            // call a method on BusinessLogic Layer that will take a playerId and return a PlayerView Model
            UserViewModel newUserViewModel = _businessLogicClass.EditedUser(userViewModel);
            return View("DisplayPlayerDetails", newUserViewModel);
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
