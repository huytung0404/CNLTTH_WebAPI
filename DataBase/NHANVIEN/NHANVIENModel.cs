using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.CHITIETPHIEUMUON;
namespace DataBase.NHANVIEN
{
    [MetadataTypeAttribute(typeof(NHANVIENModel))]
    public class NHANVIENModel
    {
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string TenNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string DiaChi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<System.DateTime> NgaySinh { get; set; }


        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string DienThoai { get; set; }

        public string Email { get; set; }

        public virtual ICollection<CHITIETPHIEUMUONModel> CHITIETPHIEUMUONs { get; set; }
    }
}
