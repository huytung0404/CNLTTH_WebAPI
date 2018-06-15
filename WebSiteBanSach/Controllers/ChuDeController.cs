using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class ChuDeController : Controller
    {
        //
        // GET: /ChuDe/
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult ChuDePartial()
        {

            return PartialView(db.ChuDes.Take(5).ToList());
        }
        //Sách theo chủ đề
        public ViewResult SachTheoChuDe(int? page,int MaChuDe=0)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Kiểm tra chủ đề tồn tại hay không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if(cd==null)
            {
                Response.StatusCode=404;
                return null;
            }
            //Truy xuất danh sách các quyển sách theo chủ đề
            List<Sach> lstSach = db.Saches.Where(n=>n.MaChuDe==MaChuDe).OrderBy(n=>n.GiaBan).ToList();
            if(lstSach.Count==0)
            {
                ViewBag.Sach="Không có sách nào thuộc chủ đề này";
            }
            //Gán danh sách chủ để
            ViewBag.MaChuDe = MaChuDe;
            ViewBag.lstChuDe = db.ChuDes.ToList();
            return View(lstSach.ToPagedList(pageNumber,pageSize));
        }
        //Hiển thị các chủ đề và sách theo chủ đề đầu tiên
        public ViewResult DanhMucChuDe(int? page)
  
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int MaChuDe = int.Parse(db.ChuDes.ToList().ElementAt(0).MaChuDe.ToString());
            //Tạo 1 viewbag gán sách theo chủ đề đầu tiên trong csdl
            ViewBag.SachTheoChuDe = db.Saches.Where(n => n.MaChuDe == MaChuDe).ToList() ;
            return View(db.ChuDes.ToList());
        }
	}
}