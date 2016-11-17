using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Anonym.Model.DataBaseMySQL
{
    class DbConnectionMySQL : IDbConnection
    {

        private MySqlConnection connection;
       
        public string ConnectionString
        {
            get
            {
                return connection.ConnectionString;
            }

            set
            {
                connection.ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get
            {
                return connection.ConnectionTimeout;
            }
        }

        public string Database
        {
            get
            {
                return connection.Database;
            }
        }

        public ConnectionState State
        {
            get
            {
                return connection.State;
            }
        }

        public DbConnectionMySQL(string connectionString)
        {
            connection = new MySqlConnection(connectionString);         
        }

        public IDbTransaction BeginTransaction()
        {
            return connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return connection.BeginTransaction(il);
        }

        public void Close()
        {
            connection.Close();
        }

        public void ChangeDatabase(string databaseName)
        {
            connection.ChangeDatabase(databaseName);
        }

        public IDbCommand CreateCommand()
        {
            return connection.CreateCommand();
        }

        public void Open()
        {
           connection.Open();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
