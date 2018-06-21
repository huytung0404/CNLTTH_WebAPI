using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.CHITIETPHIEUMUON;
namespace DataBase.DOCGIA
{
    [MetadataTypeAttribute(typeof(DOCGIAModel))]
    public class DOCGIAModel
    {
        [Display(Name = "Tên Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public int MaDG { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string TenDG { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string DiaChi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public Nullable<System.DateTime> NgaySinh { get; set; }
        

        public string GioiTinh { get; set; }

          public virtual ICollection<CHITIETPHIEUMUONModel> CHITIETPHIEUMUONs { get; set; }
    }
}
