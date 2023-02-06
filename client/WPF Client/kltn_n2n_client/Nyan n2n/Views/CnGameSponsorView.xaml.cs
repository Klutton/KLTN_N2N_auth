using DryIoc;
using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using static System.Net.WebRequestMethods;

namespace Nyan_n2n.Views
{
    /// <summary>
    /// CnGameSponsorView.xaml 的交互逻辑
    /// </summary>
    public partial class CnGameSponsorView : UserControl
    {

        List<ServerList> _serverList = new List<ServerList>
        {
            new ServerList("华北1", "n2n2.squad.ink:6789"),
            new ServerList("华北2", "n2n4.squad.ink:9527"),
            new ServerList("华东", "n2n3.squad.ink:9527")
        };
        public CnGameSponsorView()
        {
            InitializeComponent();

            Servers.ItemsSource = _serverList;
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            ServerList server = (ServerList)Servers.SelectedItem;
            if (server != null)
            {
                EdgeArgs preArgs = new EdgeArgs(server.Addr, "");
                preArgs.ForceRelay = (bool)this.Relay.IsChecked;
                EdgeManager.Start(preArgs.GenerateArgs());
            }
        }
        private void Disconnect(object sender, RoutedEventArgs e)
        {
            EdgeManager.Stop();
        }
        private void CnGame(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://www.cngame.wiki/zanzhu");
        }
    }
}
