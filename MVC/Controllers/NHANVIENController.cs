using DataBase;
using DataBase.NHANVIEN;
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
    public class NHANVIENController : Controller
    {
        // GET: NHANVIEN
        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        public ActionResult Index(int? page, string SearchText)
        {
            IEnumerable<NHANVIENModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHANVIEN").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<NHANVIENModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.NHANVIENs.Where(s => s.MaNV.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNV).ToPagedList(pageNumber, pageSize = 100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.NHANVIENs.Where(s => s.TenNV.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaNV).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.NHANVIENs.ToList().OrderBy(n => n.MaNV).ToPagedList(pageNumber, pageSize));
            //return View(empList);
        }
        [HttpGet]
        public ActionResult Create(int id=0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHANVIEN/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<NHANVIENModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(NHANVIENModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("NHANVIEN", emp).Result;
            return RedirectToAction("Index");
        }
        //sửa
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("NHANVIEN/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<NHANVIENModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(NHANVIENModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("NHANVIEN/" + emp.MaNV, emp).Result;
            return RedirectToAction("Index");
        }
        //xóa
        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("NHANVIEN/" + id.ToString()).Result;
        //    return RedirectToAction("Index");
        //}

        //xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NHANVIEN ctpm = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
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
            NHANVIEN ctpm = db.NHANVIENs.SingleOrDefault(n => n.MaNV == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("NHANVIEN/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}