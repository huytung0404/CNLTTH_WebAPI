using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DOCGIA;
using DataBase.NHANVIEN;
using DataBase;
namespace DataBase.CHITIETPHIEUMUON
{
    public class CHITIETPHIEUMUONModel
    {
        public int SoPhieuMuon { get; set; }
        public Nullable<int> MaSach { get; set; }
        public Nullable<int> MaDG { get; set; }
        public Nullable<int> MaNV { get; set; }
        public Nullable<System.DateTime> NgayMuon { get; set; }
        public Nullable<System.DateTime> HanTra { get; set; }
        public Nullable<System.DateTime> NgayKhachTra { get; set; }
        public Nullable<int> TienPhat { get; set; }
        public string LyDoPhat { get; set; }

        public virtual DOCGIAModel DOCGIA { get; set; }
        public virtual NHANVIENModel NHANVIEN { get; set; }
        public virtual QUYENSACHModel QUYENSACH { get; set; }
    }
}
