using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SuperMarket
{
    internal class DBConnection
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=product;Integrated Security=True");

        public SqlConnection GetCon()
        {
            return _connection;
        }
        public void OpenCon()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();

            }
        }
        public void Closecon()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                    _connection.Close();
            }
        }

    }
}
