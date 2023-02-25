using DryIoc;
using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Common.SaveStruct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
        CnGameSponsorStruct SavedData;
        List<ServerListItem> _serverList = new List<ServerListItem>()
        {
            new ServerListItem{ Name = "华北1", Addr = "n2n2.squad.ink:6789" },
            new ServerListItem{ Name = "华北2", Addr = "n2n4.squad.ink:9527" },
            new ServerListItem{ Name = "华东", Addr = "n2n3.squad.ink:9527" }
        };
        public CnGameSponsorView()
        {
            InitializeComponent();

            Servers.ItemsSource = _serverList;
            Servers.Focus();


            ReadData();
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            ServerListItem server = (ServerListItem)Servers.SelectedItem;
            if (!(server is null))
            {
                SaveData();
                EdgeArgs preArgs = new EdgeArgs(server.Addr, "");
                preArgs.ForceRelay = (bool)Relay.IsChecked;
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
        //保存配置
        void SaveData()
        {
            //保存
            if (SavedData is null) SavedData = new CnGameSponsorStruct();
            ServerListItem server = (ServerListItem)Servers.SelectedItem;
            if (!(server is null))
                SavedData.ServerListItem = server;
            SavedData.ForceRelay = (bool)Relay.IsChecked;

            //io
            XmlSerializer writer = new XmlSerializer(typeof(CnGameSponsorStruct));
            
            var path = ".//data";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream file = System.IO.File.Create(path + "//CnGameSponsoredSaveddata.xml");
            writer.Serialize(file, SavedData);
            file.Close();
        }
        void ReadData()
        {
            //io
            XmlSerializer reader = new XmlSerializer(typeof(CnGameSponsorStruct));
            var path = ".//data//CnGameSponsoredSaveddata.xml";
            if (!System.IO.File.Exists(path)) return;
            StreamReader file = new StreamReader(path);
            SavedData = (CnGameSponsorStruct)reader.Deserialize(file);
            file.Close();

            int i = _serverList.IndexOf(SavedData.ServerListItem);
            Servers.SelectedIndex = i;
            bool ForceRelay = SavedData.ForceRelay;
            Relay.IsChecked = ForceRelay;
        }
    }
}
