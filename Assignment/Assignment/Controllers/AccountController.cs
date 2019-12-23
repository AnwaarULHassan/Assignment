using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using System.Web.Security;

namespace Assignment.Controllers
{
    public class AccountController : Controller
    {
        private DataBContainer db = new DataBContainer();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetails log)
        {
            bool isValid = db.UserDetails.Any(x => x.Email == log.Email && x.Password == log.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(log.Email, false);
                return Redirect("/Home/Index");
            }else
            {
                ModelState.AddModelError("", "Invalid Email, Password Combination");
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserDetails sign)
        {
            db.UserDetails.Add(sign);
            db.SaveChanges();
            return Redirect("/Accounts/Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}