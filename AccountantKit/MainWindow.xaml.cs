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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountantKit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteHelper.OpenDataBase();
        }

        private List<string> LoadClientDataTable()
        {
            List<string> clientList = new List<string>();
            SQLiteHelper.ExecuteCommand("SELECT DISTINCT ClientName FROM ClientData");
            while (SQLiteHelper.dataReader.Read())
            {
                clientList.Add(SQLiteHelper.dataReader.GetString(0));
            }
            return clientList;
        }

        private void AddButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            List<string> clientList = new List<string>();
            clientList = LoadClientDataTable();
            for (int i = 0; i < clientList.Count; i++)
            {
                stackPanelDisplayArea.Children.Add(new ListPanel(clientList[i]));
            }
            
        }

    }
}
