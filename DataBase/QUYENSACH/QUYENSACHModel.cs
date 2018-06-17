using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.CHITIETPHIEUMUON;
namespace DataBase
{
    [MetadataTypeAttribute(typeof(QUYENSACHModel))]
    public class QUYENSACHModel
    {
        [Display(Name = "Mã Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột  
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public int MaSach { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //kiểm tra rỗng
        [Display(Name = "Tên Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột        
        public string TenSach { get; set; }


        [Display(Name = "Tác Giả: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string TacGia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> MaNXB { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<int> MaLoaiSach { get; set; }

        [Display(Name = "Năm Xuất Bản: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public string NamXB { get; set; }

        [Display(Name = "Lần Xuất Bản: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public string LanXB { get; set; }

        [Display(Name = "Số Lượng: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public Nullable<int> SoLuong { get; set; }

        [Display(Name = "Hình Ảnh: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public string HinhAnh { get; set; }

        [Display(Name = "Mới: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public Nullable<int> Moi { get; set; }

        [Display(Name = "Giá: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public Nullable<int> Gia { get; set; }

        [Display(Name = "Lượt Xem: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        public Nullable<int> LuotXem { get; set; }

        public virtual ICollection<CHITIETPHIEUMUONModel> CHITIETPHIEUMUONs { get; set; }
        public virtual LOAISACHModel LOAISACH { get; set; }
        public virtual NHAXUATBANModel NHAXUATBAN { get; set; }
    }
}
