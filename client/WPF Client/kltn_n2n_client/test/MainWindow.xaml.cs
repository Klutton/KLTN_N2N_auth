using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace test
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
        private void run(object sender, EventArgs e)
        {
            Process r = new Process();
            ProcessStartInfo _info = new ProcessStartInfo("edge.exe")
            {
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal,
                Arguments = "-l 111.173.83.101:24687 -c NETWORKS",
            };
            r.StartInfo = _info;
            r.Start();
        }
    }
}
