using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Common.SaveStruct;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Nyan_n2n.Views
{
    /// <summary>
    /// DirectConView.xaml 的交互逻辑
    /// </summary>
    public partial class DirectConView : UserControl
    {
        DirectConStruct SavedData;
        IEventAggregator _eventAggregator;
        public DirectConView(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
            ReadData();
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            SaveData();
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
            EdgeArgs preArges = new EdgeArgs(Host.Text, Community.Text);
            preArges.ForceRelay = (bool)Relay.IsChecked;
            if (Zip.SelectedItem != null)
            {
                string select = Zip.SelectedItem.ToString();
                if (select != "不压缩")
                {
                    if (select == "lzo1x") preArges.Zip = EdgeArgs.ZipEnum.LZO1x;
                    if (select == "zstd") preArges.Zip = EdgeArgs.ZipEnum.ZSTD;
                }
            }
            preArges.NoPortForwarding = (bool)NoPortForwarding.IsChecked;
            preArges.VirtualIp = VirtualIp.Text;
            preArges.MulticastMAC = (bool)MulticastMAC.IsChecked;
            preArges.Priority = Priority.Text;
            string args = preArges.GenerateArgs();
            EdgeManager.Start(args);
        }
        private void Disconnect(object sender, RoutedEventArgs e)
        {
            EdgeManager.Stop();
        }
        //保存配置
        void SaveData()
        {
            //保存
            if (SavedData is null) SavedData = new DirectConStruct();
            SavedData.Host = Host.Text;
            SavedData.VirtualIp = VirtualIp.Text;
            SavedData.Community = Community.Text;
            SavedData.ForceRelay = (bool)Relay.IsChecked;
            SavedData.NoPortForwarding = (bool)NoPortForwarding.IsChecked;
            SavedData.ZipEnum = Zip.SelectedIndex;
            SavedData.MulticastMAC = (bool)MulticastMAC.IsChecked;
            SavedData.Priority = Priority.Text;

            //io
            XmlSerializer writer = new XmlSerializer(typeof(DirectConStruct));

            var path = ".//data";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream file = File.Create(path + "//DirectViewSaveddata.xml");
            writer.Serialize(file, SavedData);
            file.Close();
        }
        void ReadData()
        {
            //io
            XmlSerializer reader = new XmlSerializer(typeof(DirectConStruct));
            var path = ".//data//DirectViewSaveddata.xml";
            if (!File.Exists(path)) return;
            StreamReader file = new StreamReader(path);
            SavedData = (DirectConStruct)reader.Deserialize(file);
            file.Close();

            Host.Text = SavedData.Host;
            VirtualIp.Text = SavedData.VirtualIp;
            Community.Text = SavedData.Community;
            Relay.IsChecked = SavedData.ForceRelay;
            NoPortForwarding.IsChecked = SavedData.NoPortForwarding;
            Zip.SelectedIndex = SavedData.ZipEnum;
            MulticastMAC.IsChecked = SavedData.MulticastMAC;
            Priority.Text = SavedData.Priority;
        }
    }
}
