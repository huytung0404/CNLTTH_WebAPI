//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiTapAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETPHIEUMUON
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
    
        public virtual DOCGIA DOCGIA { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual QUYENSACH QUYENSACH { get; set; }
    }
}
