using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.CHITIETPHIEUMUON;
namespace DataBase
{
    public class QUYENSACHModel
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public Nullable<int> MaLoaiSach { get; set; }
        public string NamXB { get; set; }
        public string LanXB { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> Moi { get; set; }
        public Nullable<int> Gia { get; set; }
        public Nullable<int> LuotXem { get; set; }

        public virtual ICollection<CHITIETPHIEUMUONModel> CHITIETPHIEUMUONs { get; set; }
        public virtual LOAISACHModel LOAISACH { get; set; }
        public virtual NHAXUATBANModel NHAXUATBAN { get; set; }
    }
}
