using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
    internal class PhimBLL
    {
        PhimDAL dalP;
        public PhimBLL()
        {
            dalP = new PhimDAL();
        }
        public DataTable getAllP()
        {
            return dalP.getAllP();
        }
        public bool InsertP(Phim p)
        {
            return dalP.InsertP(p);
        }
        public bool UpdateP(Phim p)
        {
            return dalP.UpdateP(p);
        }
        public bool DeleteP(Phim p)
        {
            return dalP.DeleteP(p);
        }
        public DataTable FindP(string p)
        {
            return dalP.FindP(p);
        }
    }
}
