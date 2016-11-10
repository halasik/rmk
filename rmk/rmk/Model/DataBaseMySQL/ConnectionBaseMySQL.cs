using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Anonym.Model.DataBaseMySQL
{
    class ConnectionBaseMySQL
    {

        private string host; // Адрес сервера
        private string port; // Порт
        private string user; // Имя пользователя
        private string password; // Пароль пользователя
        private string dbname; // Имя базы данных
        private MySqlConnection connection;
        private MySqlCommand query;
        private bool isConnection = false;
        private bool isBase = false;

        public string Host
        {
            get
            {
                return host;
            }
        }

        public string Port
        {
            get
            {
                return port;
            }
        }

        public string User
        {
            get
            {
                return user;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
        }

        public string Dbname
        {
            get
            {
                return dbname;
            }
        }

        public bool IsConnection
        {
            get
            {
                return isConnection;
            }
        }

        public bool IsBase
        {
            get
            {
                return isBase;
            }
        }

        public ConnectionBaseMySQL(string host, string port, string user, string password, string dbname)
        {

            this.host = host;
            this.port = port;
            this.user = user;
            this.password = password;
            this.dbname = dbname;

            string connectionString = "Data source=" + host + ";Port=" + port + ";User Id=" + user + ";Password=" + password + ";";

            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    isConnection = true;

                    ActivateBase();
                }
                catch
                {
                    isConnection = false;
                }
            }
        }

        public void CreateBase()
        {
            try
            {
                ExecuteQuery("CREATE DATABASE " + dbname + ";");

                isBase = true;
            }
            catch
            {
                isBase = false;
            }    
        }

        public void ActivateBase()
        {
            try
            {
                ExecuteQuery("USE " + dbname + ";");

                isBase = true;
            }
            catch
            {
                isBase = false;
            }        
        }

        public void CreateTable(string tbname)
        {
            ExecuteQuery("CREATE TABLE " + tbname + " (id int(9));");
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public bool IsOpen()
        {
            return connection.State == ConnectionState.Open;
        }

        private void ExecuteQuery(string commandText)
        {
            query = new MySqlCommand();
            query.Connection = connection;

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    isConnection = true;
                }
                catch
                {
                    isConnection = false;
                }
            }

            query.CommandText = commandText;
            query.ExecuteNonQuery();
        }
    }
}
