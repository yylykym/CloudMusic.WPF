using CloudMusic.WPF.Services;
using CloudMusic.WPF.ViewModels;
using System.Windows;

namespace CloudMusic.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new NavigationService());
        }
    }
}