using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataBase
{
    public class LOAISACHModel
    {
        public int MaLoaiSach { get; set; }
        public string TenLoaiSach { get; set; }

       public virtual ICollection<QUYENSACHModel> QUYENSACHes { get; set; }
    }
}
