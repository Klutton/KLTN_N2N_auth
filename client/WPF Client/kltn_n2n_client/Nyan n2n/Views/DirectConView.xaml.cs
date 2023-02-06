using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.EventArgsModel;
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
        private void Connect(object sender, RoutedEventArgs e)
        {
            /*清单：
             * -c 社区
             * -l 主机
             * -S1 强制中转（使用UDP）
             * -S2 强制中转（使用TCP）我擦Windows不支持
             * -z1 压缩传输lzo1x
             * -z2 压缩传输zstd
             * --no-port-forwarding 关闭UPnP/PMP端口转发
             * -a 自定义虚拟ip（不推荐）
             * -E 网卡启用多播
             * -x 网卡优先级*/
            EdgeArgs preArges = new EdgeArgs(this.Host.Text, this.Community.Text);
            preArges.ForceRelay = (bool)this.Relay.IsChecked;
            if (this.Zip.SelectedItem != null)
            {
                string select = this.Zip.SelectedItem.ToString();
                if (select != "不压缩")
                {
                    if (select == "lzo1x") preArges.Zip = EdgeArgs.ZipEnum.LZO1x;
                    if (select == "zstd") preArges.Zip = EdgeArgs.ZipEnum.ZSTD;
                }
            }
            preArges.NoPortForwarding = (bool)this.NoPortForwarding.IsChecked;
            preArges.VirtualIp = this.VirtualIp.Text;
            preArges.MulticastMAC = (bool)this.MulticastMAC.IsChecked;
            preArges.Priority = this.Priority.Text;
            string args = preArges.GenerateArgs();
            EdgeManager.Start(args);
        }
        private void Disconnect(object sender, RoutedEventArgs e)
        {
            EdgeManager.Stop();
        }
    }
}
