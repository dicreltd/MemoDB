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
        private MySqlConnection con;

        public MemoConnection()
        {
            con = new MySqlConnection("userid=java;password=pass;database=memo;Host=localhost");
        }

        public MySqlConnection getConnection()
        {
            return con;
        }

        public void Open()
        {
            con.Open();
        }
        public void Close()
        {
            con.Close();
        }
    }
}
