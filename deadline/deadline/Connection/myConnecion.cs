using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deadline.Connection
{
    public class myConnecion
    {
        MySqlConnection conn;
        MySqlCommand cmm;
        MySqlDataReader dr;

        public myConnecion()
        {
            conn = new MySqlConnection(StrConnection);
        }


        private string StrConnection
        {
            get {
                return "Server=localhost" +
                    ";Port=3306" +
                    ";Database=deadline" +
                    ";Uid=root" +
                    ";Pwd=";
            }
        }

        private void Connect()
        {
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void ExecuteCommand(MySqlCommand c)
        {
            Connect();
            c.Connection = conn;
            c.ExecuteNonQuery();
            Close();
        }

        public MySqlDataReader getDataReader(MySqlCommand c)
        {
            Connect();
            c.Connection = conn;
            dr = c.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            return dr;
        }

    }
}