using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.CHITIETPHIEUMUON;
namespace DataBase.DOCGIA
{
    public class DOCGIAModel
    {
        public int MaDG { get; set; }
        public string TenDG { get; set; }
        public string DiaChi { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }

          public virtual ICollection<CHITIETPHIEUMUONModel> CHITIETPHIEUMUONs { get; set; }
    }
}
