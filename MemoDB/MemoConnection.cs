using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDB
{
    class MemoConnection
    {
        MySqlConnection con;

        public MySqlConnection getConnection()
        {
            con = new MySqlConnection("userid=java;password=pass;database=memo;Host=localhost");
            return con;
        }

        public void Open()
        {
            con.Open();
        }
        public void close()
        {
            con.Close();
        }
    }
}
