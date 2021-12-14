using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace AccountantKit
{
    static class SQLiteHelper
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;
        static SQLiteDataReader dataReader;

        static SQLiteHelper()
        {
            try
            {
                string databaseName = "AccountDB";
                connection = new SQLiteConnection(databaseName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void OpenDataBase()
        {
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static SQLiteDataReader ExecuteCommand(string commandText)
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
