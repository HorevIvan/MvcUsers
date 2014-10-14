using MvcUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUsers.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserRegistration ur)
        {
            Repository.CreateUser(ur.Name, ur.Password);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(Repository.GetUsers());
        }

        public ActionResult Info(Int32 number)
        {
            return View(Repository.GetUser(number));
        }

        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(UserAuthorization ua)
        {
            Session["User"] = Repository.GetUser(ua.Name, ua.Password);

            return RedirectToAction("List");
        }

        public ActionResult Exit()
        {
            Session["User"] = null;

            return RedirectToAction("List");
        }
    }
}