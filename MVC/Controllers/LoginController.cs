using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login (string name, string password)
        {
            if ("admin".Equals(name) && "admin".Equals(password) )
            {
                Session["User"] = new User { UserName = name };
                return RedirectToAction("Index","QUYENSACH");
            }
            return View();
        }
    }
}