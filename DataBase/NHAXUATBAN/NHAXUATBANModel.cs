using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class NHAXUATBANModel
    {
        public int MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<QUYENSACHModel> QUYENSACHes { get; set; }
    }
}
