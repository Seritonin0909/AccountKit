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
    /// DataPanel.xaml 的交互逻辑
    /// </summary>
    public partial class DataPanel : UserControl
    {
        DataWindow owner;

        public DataPanel()
        {
            InitializeComponent();
        }

        public DataPanel(string Date, string AmountOfMoney, DataWindow _owner)
        {
            InitializeComponent();
            textBlockDate.Text = Date;
            textBlockAmountOfMoney.Text = AmountOfMoney;
            owner = _owner;
        }

        private void ButtonCancel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            owner.stackPanelClientData.Children.Remove(this);
        }
    }
}
