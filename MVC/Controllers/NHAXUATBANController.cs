using DataBase;
using MVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class NHAXUATBANController : Controller
    {
        // GET: NHAXUATBAN
        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        public ActionResult Index(int? page, string SearchText)
        {
            IEnumerable<NHAXUATBANModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHAXUATBAN").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<NHAXUATBANModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;
            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.NHAXUATBANs.Where(s => s.MaNXB.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize = 100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.NHAXUATBANs.Where(s => s.TenNXB.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize));
           
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHAXUATBAN/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<NHAXUATBANModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(NHAXUATBANModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("NHAXUATBAN", emp).Result;
            return RedirectToAction("Index");
        }
        //sửa
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHAXUATBAN/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<NHAXUATBANModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(NHAXUATBANModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("NHAXUATBAN/" + emp.MaNXB, emp).Result;
            return RedirectToAction("Index");
        }
        //xóa
        //public ActionResult Delete(int id = 0)
        //{
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("NHAXUATBAN/" + id.ToString()).Result;
        //    return RedirectToAction("Index");
        //}

        //xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NHAXUATBAN ctpm = db.NHAXUATBANs.SingleOrDefault(n => n.MaNXB == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            return View(ctpm);
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult XacNhanXoa(int id)
        {
            NHAXUATBAN ctpm = db.NHAXUATBANs.SingleOrDefault(n => n.MaNXB == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("NHAXUATBAN/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}