using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSiteBanSach.Models
{
   [MetadataTypeAttribute(typeof(SachMetadata))]
    public partial class Sach
    {
       internal sealed class SachMetadata
       {

           [Display(Name = "Mã Sách")]//Thuộc tính Display dùng để đặt tên lại cho cột
           public int MaSach { get; set; }
           [Display(Name = "Tên Sách")]//Thuộc tính Display dùng để đặt tên lại cho cột
           [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
           public string TenSach { get; set; }
           [Display(Name = "Giá Bán")]//Thuộc tính Display dùng để đặt tên lại cho cột
           public Nullable<decimal> GiaBan { get; set; }
           [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
           [Display(Name = "Mô Tả")]//Thuộc tính Display dùng để đặt tên lại cho cột
           public string MoTa { get; set; }

           [DataType(DataType.Date)]
           [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
           [Display(Name = "Ngày Cập Nhật")]//Thuộc tính Display dùng để đặt tên lại cho cột
           [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
           public Nullable<System.DateTime> NgayCapNhat { get; set; }

           [Display(Name = "Ảnh Bìa")]//Thuộc tính Display dùng để đặt tên lại cho cột
        
           public string AnhBia { get; set; }
           [Display(Name = "Số Lượng Tồn")]//Thuộc tính Display dùng để đặt tên lại cho cột
           [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
           public Nullable<int> SoLuongTon { get; set; }
           [Display(Name = "Chủ Đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
          
           public Nullable<int> MaChuDe { get; set; }
           [Display(Name = "Nhà Xuất Bản")]//Thuộc tính Display dùng để đặt tên lại cho cột
     
           public Nullable<int> MaNXB { get; set; }
           [Display(Name = "Mới")]//Thuộc tính Display dùng để đặt tên lại cho cột
           [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
           public Nullable<int> Moi { get; set; }
       }
    }
}