using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataBase
{
    [MetadataTypeAttribute(typeof(LOAISACHModel))]
    public class LOAISACHModel
    {
        [Display(Name = "Mã Loại Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public int? MaLoaiSach { get; set; }
       
        [Display(Name = "Tên Loại Sách: ")]//Thuộc tính Display dùng để đặt tên lại cho cột
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
        public string TenLoaiSach { get; set; }

       public virtual ICollection<QUYENSACHModel> QUYENSACHes { get; set; }
    }
}
