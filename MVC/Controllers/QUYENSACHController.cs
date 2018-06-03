using DataBase;
using MVC.Models;
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
        public ActionResult Index()
        {
            IEnumerable<QUYENSACHModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("QUYENSACH").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<QUYENSACHModel>>().Result;

            return View(empList);
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
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("QUYENSACH/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<QUYENSACHModel>().Result);
        }
        [HttpPost]
        public ActionResult Edit(QUYENSACHModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("QUYENSACH/" + emp.MaSach, emp).Result;
            return RedirectToAction("Index");
        }
        //xóa
        public ActionResult Delete(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("QUYENSACH/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}