using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace AccountantKit
{
    class SQLiteHelper
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteDataReader dataReader;

        public SQLiteHelper(string databaseName)
        {
            try
            {
                connection = new SQLiteConnection(databaseName);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SQLiteDataReader ExecuteCommand(string commandText)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = commandText;
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }

            return dataReader;
        }
    }
}
