using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrarydal
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=SHAMPY\\SQLEXPRESS;Initial Catalog=FypDiscountify;Integrated Security=True");
            return con;
        }
    }
}
