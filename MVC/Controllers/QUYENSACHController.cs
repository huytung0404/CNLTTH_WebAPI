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
    public class QUYENSACHController : Controller
    {
        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        public ActionResult Index(int? page, string SearchText)
        {
            IEnumerable<QUYENSACHModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("QUYENSACH").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<QUYENSACHModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;
            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.QUYENSACHes.Where(s => s.MaSach.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize =100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.QUYENSACHes.Where(s => s.TenSach.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize =100 ));
                }

            }
            return View(db.QUYENSACHes.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize));
            
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            ViewBag.MaLoaiSach = new SelectList(db.LOAISACHes.ToList().OrderBy(n => n.MaLoaiSach), "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("QUYENSACH/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<QUYENSACHModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(QUYENSACHModel emp)
        {
            ViewBag.MaLoaiSach = new SelectList(db.LOAISACHes.ToList().OrderBy(n => n.MaLoaiSach), "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");

            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("QUYENSACH", emp).Result;
            return RedirectToAction("Index");
        }
        //sửa
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            MVC.Models.QUYENSACH ctpm = db.QUYENSACHes.SingleOrDefault(n => n.MaSach == id);
            ViewBag.MaLoaiSach = new SelectList(db.LOAISACHes.ToList().OrderBy(n => n.MaLoaiSach), "MaLoaiSach", "TenLoaiSach",ctpm.LOAISACH.TenLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB",ctpm.NHAXUATBAN.TenNXB);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("QUYENSACH/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<QUYENSACHModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(QUYENSACHModel emp)
        {
            ViewBag.MaLoaiSach = new SelectList(db.LOAISACHes.ToList().OrderBy(n => n.MaLoaiSach), "MaLoaiSach", "TenLoaiSach",emp.LOAISACH.TenLoaiSach);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB",emp.NHAXUATBAN.TenNXB);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("QUYENSACH/" + emp.MaSach, emp).Result;
            return RedirectToAction("Index");
        }






        //xóa
        //public ActionResult Delete(int id = 0)
        //{
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("QUYENSACH/" + id.ToString()).Result;
        //    return RedirectToAction("Index");
        //}

        //xóa
        [HttpGet]
        public ActionResult Delete(int id)
        {
            QUYENSACH ctpm = db.QUYENSACHes.SingleOrDefault(n => n.MaSach == id);
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
            QUYENSACH ctpm = db.QUYENSACHes.SingleOrDefault(n => n.MaSach == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("QUYENSACH/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}