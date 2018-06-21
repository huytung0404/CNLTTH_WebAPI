
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

using DataBase.CHITIETPHIEUMUON;

namespace MVC.Controllers
{
    public class CHITIETPHIEUMUONController : Controller
    {
        // GET: CHITIETPHIEUMUON

        Project_QLThuVien_APIEntities db = new Project_QLThuVien_APIEntities();

        public ActionResult Index(int? page, string SearchText)
        {
            IEnumerable<CHITIETPHIEUMUONModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CHITIETPHIEUMUON").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<CHITIETPHIEUMUONModel>>().Result;

            int pageNumber = (page ?? 1);
            int pageSize = 5;


            //var model = GetMovie();
            int parsedValue;
            if (!string.IsNullOrEmpty(SearchText))
            {
                if (Int32.TryParse(SearchText, out parsedValue))
                {
                    var result = db.CHITIETPHIEUMUONs.Where(s => s.SoPhieuMuon.ToString().Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.SoPhieuMuon).ToPagedList(pageNumber, pageSize = 100));
                }

                //if (IsNumber(SearchText) == false)
                else
                {
                    var result = db.CHITIETPHIEUMUONs.Where(s => s.DOCGIA.TenDG.Contains(SearchText));
                    return View(result.ToList().OrderBy(n => n.SoPhieuMuon).ToPagedList(pageNumber, pageSize = 100));
                }

            }

           return View(db.CHITIETPHIEUMUONs.ToList().OrderBy(n => n.SoPhieuMuon).ToPagedList(pageNumber, pageSize));
            //return View(empList.ToList().OrderBy(n => n.SoPhieuMuon).ToPagedList(pageNumber, pageSize));

            //return View(empList);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            ViewBag.MaSach = new SelectList(db.QUYENSACHes.ToList().OrderBy(n => n.TenSach), "MaSach", "TenSach");
            ViewBag.MaDG = new SelectList(db.DOCGIAs.ToList().OrderBy(n => n.TenDG), "MaDG", "TenDG");
            ViewBag.MaNV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TenNV), "MaNV", "TenNV");
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CHITIETPHIEUMUON/" + id.ToString()).Result;
            
            return View(response.Content.ReadAsAsync<CHITIETPHIEUMUONModel>().Result);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CHITIETPHIEUMUONModel emp)
        {
            ViewBag.MaSach = new SelectList(db.QUYENSACHes.ToList().OrderBy(n => n.TenSach), "MaSach", "TenSach");
            ViewBag.MaDG = new SelectList(db.DOCGIAs.ToList().OrderBy(n => n.TenDG), "MaDG", "TenDG");
            ViewBag.MaNV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TenNV), "MaNV", "TenNV");
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CHITIETPHIEUMUON", emp).Result;
            return RedirectToAction("Index");
        }



        //sửa
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            MVC.Models.CHITIETPHIEUMUON ctpm = db.CHITIETPHIEUMUONs.SingleOrDefault(n => n.SoPhieuMuon == id);
            ViewBag.MaSach = new SelectList(db.QUYENSACHes.ToList().OrderBy(n => n.TenSach), "MaSach", "TenSach", ctpm.MaSach);
            ViewBag.MaDG = new SelectList(db.DOCGIAs.ToList().OrderBy(n => n.TenDG), "MaDG", "TenDG", ctpm.MaDG);
            ViewBag.MaNV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TenNV), "MaNV", "TenNV", ctpm.MaNV);
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CHITIETPHIEUMUON/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<CHITIETPHIEUMUONModel>().Result);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(CHITIETPHIEUMUONModel emp)
        {
            ViewBag.MaSach = new SelectList(db.QUYENSACHes.ToList().OrderBy(n => n.TenSach), "MaSach", "TenSach", emp.MaSach);
            ViewBag.MaDG = new SelectList(db.DOCGIAs.ToList().OrderBy(n => n.TenDG), "MaDG", "TenDG", emp.MaDG);
            ViewBag.MaNV = new SelectList(db.NHANVIENs.ToList().OrderBy(n => n.TenNV), "MaNV", "TenNV", emp.MaNV);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CHITIETPHIEUMUON/" + emp.SoPhieuMuon, emp).Result;
            return RedirectToAction("Index");
        }





        //xóa
        [HttpGet]
        public ActionResult Delete(int id )
        {
            CHITIETPHIEUMUON ctpm = db.CHITIETPHIEUMUONs.SingleOrDefault(n => n.SoPhieuMuon == id);
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
            CHITIETPHIEUMUON ctpm = db.CHITIETPHIEUMUONs.SingleOrDefault(n => n.SoPhieuMuon == id);
            //if (ctpm == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("CHITIETPHIEUMUON/" + id.ToString()).Result;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}