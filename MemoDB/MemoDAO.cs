using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MemoDB
{
    class MemoDAO
    {
        MySqlConnection con;

        public MemoDAO(MySqlConnection con)
        {
            this.con = con;
        }

        public Memo findById(int mid)
        {
            string sql = "SELECT * FROM memo WHERE mid=?";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add(new MySqlParameter("mid", mid));

            MySqlDataReader reader = cmd.ExecuteReader();

            Memo memo = null;
            if (reader.Read())
            {
                string title = reader.GetString("title");
                string body = reader.GetString("body");
                DateTime utime = reader.GetDateTime("utime");

                memo = new Memo(mid, title, body, utime);
            }
            reader.Close();

            return memo;
        }


        public void insert(Memo memo)
        {
            string sql = "INSERT INTO memo(title,body,utime) VALUES(?,?,now())";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add(new MySqlParameter("title", memo.Title));
            cmd.Parameters.Add(new MySqlParameter("body", memo.Body));

            cmd.ExecuteNonQuery();

        }

        public void update(Memo memo)
        {
            string sql = "UPDATE memo SET title=?,body=?,utime=now() WHERE mid=?";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add(new MySqlParameter("title", memo.Title));
            cmd.Parameters.Add(new MySqlParameter("body", memo.Body));
            cmd.Parameters.Add(new MySqlParameter("mid", memo.Mid));

            cmd.ExecuteNonQuery();

        }

        public void delete(int mid)
        {
            string sql = "DELETE FROM  memo WHERE mid=?";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add(new MySqlParameter("mid", mid));

            cmd.ExecuteNonQuery();

        }

    }
}
