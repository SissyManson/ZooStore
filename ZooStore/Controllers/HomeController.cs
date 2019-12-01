using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooStore.Entities;
using ZooStore.Models;
using ZooStore.ViewModels.Home;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginVM model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                ZooContext context = new ZooContext();

                User loggedUser = context.Users
                                                .Where(u =>
                                                     u.Username == model.Username &&
                                                     u.Password == model.Password)
                                                .FirstOrDefault();

                if (loggedUser != null)
                    Session["loggedUser"] = loggedUser;
                else
                    ModelState.AddModelError("AuthFailed", "Wrong Username or Password");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["loggedUser"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}