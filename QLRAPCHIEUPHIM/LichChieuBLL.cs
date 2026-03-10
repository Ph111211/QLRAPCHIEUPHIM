using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
    internal class LichChieuBLL
    {
        LichChieuDAL dalLC;

        public LichChieuBLL()
        {
            dalLC = new LichChieuDAL();
        }

        public DataTable getAllLC()
        {
            return dalLC.getAllLC();
        }

        public bool InsertLC(LichChieu lc)
        {
            return dalLC.InsertLC(lc);
        }
        public bool UpdateLC(LichChieu lc)
        {
            return dalLC.UpdateLC(lc);
        }
        public bool DeleteLC(LichChieu lc)
        {
            return dalLC.DeleteLC(lc);
        }
    }
}
