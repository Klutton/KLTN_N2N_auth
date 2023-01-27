using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using Prism.Events;
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
    /// DirectConView.xaml 的交互逻辑
    /// </summary>
    public partial class DirectConView : UserControl
    {
        IEventAggregator _eventAggregator;
        public DirectConView(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
        }

        private EdgeManager _manager;
        private void Connect(object sender, RoutedEventArgs e)
        {
            Disconnect(null,null);
            ConUpdate();
            EdgeArgs preArges = new EdgeArgs(this.Ip.Text, this.Port.Text, this.Community.Text);
            string args = preArges.GenerateArgs();
            _manager = new EdgeManager(args, _eventAggregator);
            _manager.Start();
        }
        private void Disconnect(object sender, RoutedEventArgs e)
        {
            DisConUpdate();
            if (_manager != null)
            {
                _manager.Stop();
            }
        }
        private void ConUpdate()
        {
            status.Text = "连接";
            status.Foreground = Brushes.Green;
        }
        private void DisConUpdate()
        {
            status.Text = "断开";
            status.Foreground = Brushes.Red;
        }
    }
}
