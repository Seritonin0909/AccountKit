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
    /// ListPanel.xaml 的交互逻辑
    /// </summary>
    public partial class ListPanel : UserControl
    {
        string clientName;
        MainWindow owner;

        public ListPanel()
        {
            InitializeComponent();
        }

        public ListPanel(string _clientName,MainWindow _owner)
        {
            InitializeComponent();
            clientName = _clientName;
            textBlockClientName.Text = _clientName;
            owner = _owner;
        }

        private void ButtonAccountStatus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DataWindow dataWindow = new DataWindow(clientName);
            WindowHelper.ShowNewWindow(this.owner, dataWindow);
        }

        private void ButtonDelete_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            owner.DeleteListPanel(this);
        }
    }
}
