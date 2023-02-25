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

namespace Nyan_n2n.Views
{
    /// <summary>
    /// HomeView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            LayoutUpdated += (s, e) =>
            {
                try
                {
                    Viewer.Width = ActualWidth - 40;
                    Viewer.Height = ActualHeight - 40;
                }
                catch { }
            };
        }

        private void Doc(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://www.cngame.wiki/Nyan-n2n-document");
        }
        private void Blog(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://klutton.github.io");
        }
        private void Sponsor(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://klutton.github.io/sponsor");
        }
    }
}
