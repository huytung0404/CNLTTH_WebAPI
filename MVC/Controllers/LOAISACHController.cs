using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LOAISACHController : Controller
    {
        // GET: LOAISACH
        public ActionResult Index()
        {
            LOAISACHClient loaisachClient = new LOAISACHClient();
            return View(loaisachClient.HienThiLOAISACH());
        }
    }
}