using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
    internal class PhongChieuBLL
    {
       PhongChieuDAL dalPC;
        public PhongChieuBLL()
        {
            dalPC = new PhongChieuDAL();
        }
        public DataTable getAllPC()
        {
            return dalPC.getAllPC();
        }
        public bool InsertPC(PhongChieu pc)
        {
            return dalPC.InsertPC(pc);
        }
        public bool UpdatePC(PhongChieu pc)
        {
            return dalPC.UpdatePC(pc);
        }
        public bool DeletePC(PhongChieu pc)
        {
            return dalPC.DeletePC(pc);
        }
    }
}
