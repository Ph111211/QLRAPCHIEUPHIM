using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
    internal class VeBLL
    {
        VeDAL dalVe;
        public VeBLL()
        {
            dalVe = new VeDAL();
        }
        public DataTable getAllVe()
        {
            return dalVe.getAllVe();
        }
        public bool InsertVe(Ve v)
        {
            return dalVe.InsertVe(v);
        }
        public bool UpdateVe(Ve v)
        {
            return dalVe.UpdateVe(v);
        }
        public bool DeleteVe(Ve v)
        {
            return dalVe.DeleteVe(v);
        }
        public DataTable FindVe(string v)
        {
            return dalVe.FindVe(v);
        }
    }
}
