using Nyan_n2n.Common.Models;
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
    /// RunLogView.xaml 的交互逻辑
    /// </summary>
    public partial class RunLogView : UserControl
    {
        public RunLogView()
        {
            InitializeComponent();
            LayoutUpdated += (s, e) =>
            {
                try
                {
                    Log.Height = ActualHeight - 80;
                }
                catch { }
            };
        }
    }
}
