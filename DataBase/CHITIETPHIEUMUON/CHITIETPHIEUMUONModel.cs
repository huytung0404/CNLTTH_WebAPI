using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DOCGIA;
using DataBase.NHANVIEN;
using DataBase;
using System.Xml.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataBase.CHITIETPHIEUMUON
{
    [MetadataTypeAttribute(typeof(CHITIETPHIEUMUONModel))]
    public class CHITIETPHIEUMUONModel
    {
        
        public int SoPhieuMuon { get; set; }
        [Display(Name = "Tên Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> MaSach { get; set; }
        [Display(Name = "Tên Độc Giả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> MaDG { get; set; }
        [Display(Name = "Tên Nhân Viên: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> MaNV { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
        [Display(Name = "Ngày Mượn: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<System.DateTime> NgayMuon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
        [Display(Name = "Hạn Trả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<System.DateTime> HanTra { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
        [Display(Name = "Ngày Khách Trả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<System.DateTime> NgayKhachTra { get; set; }

        [Display(Name = "Phí Phạt: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> TienPhat { get; set; }

        [Display(Name = "Lý Do Phạt: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string LyDoPhat { get; set; }

        public virtual DOCGIAModel DOCGIA { get; set; }
        public virtual NHANVIENModel NHANVIEN { get; set; }
        public virtual QUYENSACHModel QUYENSACH { get; set; }

        public static object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
