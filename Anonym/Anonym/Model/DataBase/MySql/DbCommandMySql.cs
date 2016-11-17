using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Anonym.Model.DataBaseMySQL
{
    class DbCommandMySql : IDbCommand
    {
        private MySqlCommand command;

        public string CommandText
        {
            get
            {
                return command.CommandText;
            }

            set
            {
                command.CommandText = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return command.CommandTimeout;
            }

            set
            {
                command.CommandTimeout = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return command.CommandType;
            }

            set
            {
                command.CommandType = value;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return command.Connection;
            }

            set
            {
                command.Connection = (MySqlConnection)value;
            }
        }

        public IDataParameterCollection Parameters
        {
            get
            {
                return command.Parameters;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return command.Transaction;
            }

            set
            {
                command.Transaction = (MySqlTransaction)value;
            }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get
            {
                return command.UpdatedRowSource;
            }

            set
            {
                command.UpdatedRowSource = value;
            }
        }

        public DbCommandMySql(MySqlConnection connection, string cmdText)
        {
            command = new MySqlCommand(cmdText, connection);
        }

        public void Cancel()
        {
            command.Cancel();
        }

        public IDbDataParameter CreateParameter()
        {
            return command.CreateParameter();
        }

        public void Dispose()
        {
            command.Dispose();
        }

        public int ExecuteNonQuery()
        {
            return command.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader()
        {
            return command.ExecuteReader();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return command.ExecuteReader(behavior);
        }

        public object ExecuteScalar()
        {
            return command.ExecuteReader();
        }

        public void Prepare()
        {
            command.Prepare();
        }
    }
}
