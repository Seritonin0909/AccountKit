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
            List<string> dateList;
            List<string> moneyList;

            SQLiteHelper.ReadDateAndInvoiceMoneyFromClientNameOrderByDate(clientName, out dateList, out moneyList);

            for (int i = 0; i < dateList.Count; i++)
            {
                DataPanel dataPanel = new DataPanel(dateList[i], moneyList[i], this);
                stackPanelClientData.Children.Add(dataPanel);
            }
        }

        private void ButtonBack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.Close();
            WindowHelper.BackToOldWindow(this);
        }
    }
}
