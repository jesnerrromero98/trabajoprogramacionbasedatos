using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace conexion
{
    class conexion
    {
        public SqlConnection Conectar ()
        {
           
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=.\\(local);Initial Catalog=bd_ger;Integrated Security=True";
           
        }
    }
}
