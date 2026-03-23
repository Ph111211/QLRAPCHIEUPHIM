using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
	internal class DataConnection
	{
		private string conStr;

		public DataConnection()
		{
			conStr = @"Data Source=LAPTOPK1;Initial Catalog=BaiTapLon;Integrated Security=True";
		}

		public SqlConnection getConnect()
		{
			return new SqlConnection(conStr);
		}
	}
}