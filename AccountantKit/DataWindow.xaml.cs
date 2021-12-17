using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountantKit
{
    /// <summary>
    /// DataWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataWindow : Window
    {
        string clientName;

        public DataWindow()
        {
            InitializeComponent();
        }

        public DataWindow(string _clientName)
        {
            InitializeComponent();
            clientName = _clientName;
            textBlockClientName.Text = _clientName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> dateList = new List<string>();
            List<string> moneyList = new List<string>();
            string clientNameInCommand = "\"" + clientName + "\"";

            string commandForDate = string.Format("SELECT Date FROM ClientData WHERE ClientName = {0}", clientNameInCommand);
            SQLiteHelper.ExecuteCommand(commandForDate);
            while (SQLiteHelper.dataReader.Read())
            {
                dateList.Add(SQLiteHelper.dataReader.GetString(0));
            }

            string commandForMoney = string.Format("SELECT InvoiceMoney FROM ClientData WHERE ClientName = {0}", clientNameInCommand);
            SQLiteHelper.ExecuteCommand(commandForMoney);
            while (SQLiteHelper.dataReader.Read())
            {
                moneyList.Add(SQLiteHelper.dataReader.GetDouble(0).ToString());
            }

            for (int i = 0; i < dateList.Count; i++)
            {
                DataPanel dataPanel = new DataPanel(dateList[i], moneyList[i], this);
                stackPanelClientData.Children.Add(dataPanel);
            }
        }

        private void ButtonBack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
