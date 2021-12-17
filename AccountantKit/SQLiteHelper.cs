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
        public static SQLiteDataReader dataReader;

        static SQLiteHelper()
        {
            try
            {
                string databaseName = "data source=AccountDB.db";
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

        /// <summary>
        /// 读取ClientData表中所有客户的名称
        /// </summary>
        /// <returns>客户的名称表</returns>
        public static List<string> ReadDistinctClientNameFormCLientData()
        {
            List<string> clientList = new List<string>();
            SQLiteHelper.ExecuteCommand("SELECT DISTINCT ClientName FROM ClientData");
            while (SQLiteHelper.dataReader.Read())
            {
                clientList.Add(SQLiteHelper.dataReader.GetString(0));
            }
            return clientList;
        }

        /// <summary>
        /// 读取ClientData表中指定客户按照时间排序的开票时间和开票金额
        /// </summary>
        /// <param name="clientName">客户名称</param>
        /// <param name="_dateList">输出的开票时间表</param>
        /// <param name="_moneyList">输出的开票金额表</param>
        public static void ReadDateAndInvoiceMoneyFromClientNameOrderByDate(string clientName, out List<string> _dateList, out List<string> _moneyList)
        {
            string clientNameInCommand = "\"" + clientName + "\"";
            string command = string.Format("SELECT Date, InvoiceMoney FROM ClientData WHERE ClientName = {0} ORDER BY Date", clientNameInCommand);
            _dateList = new List<string>();
            _moneyList = new List<string>();

            SQLiteHelper.ExecuteCommand(command);
            while (SQLiteHelper.dataReader.Read())
            {
                _dateList.Add(SQLiteHelper.dataReader.GetString(0));
                _moneyList.Add(SQLiteHelper.dataReader.GetDouble(1).ToString());
            }
        }
    }
}
