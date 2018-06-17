using DataBase;
using MVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LOAISACHController : Controller
    {
        // GET: loaisach
        //public bool IsNumber(string SearchText)
        //{
        //    Regex regex = new Regex(@"^[-+]?[0 - 9] *\.?[0 - 9] +$");
        //    return regex.IsMatch(SearchText);
        //}
        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        public ActionResult Index(int? page, string SearchText,LOAISACHModel lOAISACHModel)
        {
            IEnumerable<LOAISACHModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<LOAISACHModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;
            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.LOAISACHes.Where(s => s.MaLoaiSach.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaLoaiSach).ToPagedList(pageNumber, pageSize = 100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.LOAISACHes.Where(s => s.TenLoaiSach.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaLoaiSach).ToPagedList(pageNumber, pageSize = 100));
                }

            }



            return View(db.LOAISACHes.ToList().OrderBy(n => n.MaLoaiSach).ToPagedList(pageNumber, pageSize));

        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<LOAISACHModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(LOAISACHModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("LOAISACH", emp).Result;
            return RedirectToAction("Index");
        }
        //sửa
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("LOAISACH/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<LOAISACHModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(LOAISACHModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("LOAISACH/" + emp.MaLoaiSach, emp).Result;
            return RedirectToAction("Index");
        }
        //xóa
        //public ActionResult Delete(int id = 0)
        //{
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("LOAISACH/" + id.ToString()).Result;
        //    return RedirectToAction("Index");
        //}
        //xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LOAISACH ctpm = db.LOAISACHes.SingleOrDefault(n => n.MaLoaiSach == id);
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
            LOAISACH ctpm = db.LOAISACHes.SingleOrDefault(n => n.MaLoaiSach == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("LOAISACH/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}