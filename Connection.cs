using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTNNhom10
{
   class Connection
    {
        private static string connectionString = "Data Source=DESKTOP-N0ISESO;Initial Catalog=BTNNhom10;Integrated Security=True";

        public string myConnection()
        {
            return connectionString;
        }
    }
}
