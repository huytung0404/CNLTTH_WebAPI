using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LOAISACHController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<LOAISACHModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<LOAISACHModel>>().Result;

            return View(empList);
        }
        //add+edit
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new LOAISACHModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<LOAISACHModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(LOAISACHModel emp)
        {
            if (emp.MaLoaiSach == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("LOAISACH", emp).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("LOAISACH/" + emp.MaLoaiSach, emp).Result;
            }
            return RedirectToAction("Index");
        }
        //xóa
        public ActionResult Delete(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("LOAISACH/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}   