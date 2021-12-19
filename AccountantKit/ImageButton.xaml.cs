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
    /// ImageButton.xaml 的交互逻辑
    /// </summary>
    public partial class ImageButton : UserControl
    {
        private static ImageButton button;

        public ImageButton()
        {
            InitializeComponent();
        }

        public string ImageUri
        {
            get { return (string)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageUriProperty =
            DependencyProperty.Register("ImageUri", typeof(string), typeof(ImageButton), new PropertyMetadata(new PropertyChangedCallback(ChangeImageSource)));

        public static void ChangeImageSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            button = (ImageButton)d;
            string uriString = e.NewValue.ToString();
            button.mainImage.Stretch = Stretch.Uniform;
            button.mainImage.Source = BitmapFrame.Create(new Uri(uriString, UriKind.Relative));

        }
    }
}
