using BaiTapAPI.Models;
using DataBase;
using DataBase.CHITIETPHIEUMUON;
using MVC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DataBase.CHITIETPHIEUMUON;
namespace MVC.Controllers
{
    public class CHITIETPHIEUMUONController : Controller
    {
        // GET: CHITIETPHIEUMUON

        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();
        
        public ActionResult Index(int? page)
        {
            IEnumerable<CHITIETPHIEUMUONModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CHITIETPHIEUMUON").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<CHITIETPHIEUMUONModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.CHITIETPHIEUMUONs.ToList().OrderBy(n => n.SoPhieuMuon).ToPagedList(pageNumber, pageSize));
            //return View(empList);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CHITIETPHIEUMUON/" + id.ToString()).Result;
            ViewBag.MaSach = new SelectList(db.QUYENSACHes.ToList().OrderBy(n => n.TenSach), "MaSach", "TenSach");
            ViewBag.MaDG = new SelectList(db.DOCGIAs.ToList().OrderBy(n => n.TenDG), "MaDG", "TenDG");
            ViewBag.MaNV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TenNV), "MaNV", "TenNV");
            return View(response.Content.ReadAsAsync<CHITIETPHIEUMUONModel>().Result);
        }
        [HttpPost]
        public ActionResult Create(CHITIETPHIEUMUONModel emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CHITIETPHIEUMUON", emp).Result;
            return RedirectToAction("Index");
        }
    }
}