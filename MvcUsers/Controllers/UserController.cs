﻿using MvcUsers.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserRegistration ur)
        {
            Repository.CreateUser(ur.Name, ur.Password);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }
    }
}