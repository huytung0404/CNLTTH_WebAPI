using DataBase;
using DataBase.DOCGIA;
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
    public class DOCGIAController : Controller
    {
        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        public ActionResult Index(int? page, string SearchText)
        {
            IEnumerable<DOCGIAModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("DOCGIA").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<DOCGIAModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.DOCGIAs.Where(s => s.MaDG.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaDG).ToPagedList(pageNumber, pageSize = 100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.DOCGIAs.Where(s => s.TenDG.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaDG).ToPagedList(pageNumber, pageSize = 100));
                }

            }

            return View(db.DOCGIAs.ToList().OrderBy(n => n.MaDG).ToPagedList(pageNumber, pageSize));
            
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("DOCGIA/" + id.ToString()).Result;         
            return View(response.Content.ReadAsAsync<DOCGIAModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(DOCGIAModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("DOCGIA", emp).Result;
            TempData["SuccessMessage"] = "Thêm mới độc giả thành công";
            return RedirectToAction("Index");
        }
        //sửa
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("DOCGIA/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<DOCGIAModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(DOCGIAModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("DOCGIA/" + emp.MaDG, emp).Result;
            TempData["SuccessMessage"] = "Cập nhật độc giả thành công";
            return RedirectToAction("Index");
        }
        //xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DOCGIA ctpm = db.DOCGIAs.SingleOrDefault(n => n.MaDG == id);
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
            DOCGIA ctpm = db.DOCGIAs.SingleOrDefault(n => n.MaDG == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("DOCGIA/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}