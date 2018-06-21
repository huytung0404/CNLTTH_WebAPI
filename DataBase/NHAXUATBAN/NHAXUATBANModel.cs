using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    [MetadataTypeAttribute(typeof(NHAXUATBANModel))]
    public class NHAXUATBANModel
    {
        [Display(Name = "Mã NXB: ")]//Thuộc tính Display dùng để đặt tên lại cho cột 
        
        public int MaNXB { get; set; }

        
        [Display(Name = "Tên NXB: ")]//Thuộc tính Display dùng để đặt tên lại cho cột 
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //kiểm tra rỗng
        public string TenNXB { get; set; }

        
        [Display(Name = "Địa Chỉ ")]//Thuộc tính Display dùng để đặt tên lại cho cột 
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string DiaChi { get; set; }

        public virtual ICollection<QUYENSACHModel> QUYENSACHes { get; set; }
    }
}
