using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudMusic.WPF.Views
{
    /// <summary>
    /// DiscoverView.xaml 的交互逻辑
    /// </summary>
    public partial class DiscoverView : UserControl
    {
        public DiscoverView()
        {
            InitializeComponent();
        }
        private void Card_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged && e.NewSize.Width > 0)
            {
                Height = e.NewSize.Width / 0.75;
            }
        }
    }
}
