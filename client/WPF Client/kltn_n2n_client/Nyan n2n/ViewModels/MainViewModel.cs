using MaterialDesignThemes.Wpf;
using Nyan_n2n.Common;
using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Extensions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        IEventAggregator _eventAggregator;
        public MainViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _eventAggregator = ea;
            EdgeManager.SetEventAggregator(ea);
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this._regionManager = regionManager;
            _eventAggregator.GetEvent<RunLogEvent>().Subscribe(DoNotify);
            Snackbar = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(2000));

        }
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Namespace))
                return;
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Namespace);
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        private IRegionManager _regionManager;
        private ObservableCollection<MenuBar> _menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _menuBars; }
            set { _menuBars = value; RaisePropertyChanged(); }
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "主页", Namespace = "HomeView" });
            MenuBars.Add(new MenuBar() { Icon = "TransitConnectionHorizontal", Title = "直连", Namespace = "DirectConView" });
            MenuBars.Add(new MenuBar() { Icon = "TransitConnectionVariant", Title = "验证连接", Namespace = "AuthConView" });
            MenuBars.Add(new MenuBar() { Icon = "GamepadVariantOutline", Title = "CnGame节点", Namespace = "CnGameSponsorView" });
            MenuBars.Add(new MenuBar() { Icon = "NoteTextOutline", Title = "日志", Namespace = "RunLogView" });
            MenuBars.Add(new MenuBar() { Icon = "Account", Title = "关于", Namespace = "AboutView" });
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Configure()
        {
            CreateMenuBar();
            foreach (var menuBar in MenuBars)
            {
                _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(menuBar.Namespace);
            }
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeView");
        }

        /// <summary>
        /// 获取runlog并弹出提示
        /// </summary>
        private SnackbarMessageQueue _snackbar;
        public SnackbarMessageQueue Snackbar
        {
            get { return _snackbar; }
            set
            {
                _snackbar = value;
                RaisePropertyChanged();
            }
        }

        void DoNotify(RunLog log)
        {
            if (log.Notification == LogNotification.Connecting)
            {
                Snackbar.Enqueue("正在尝试连接到服务器");
            }
            else if (log.Notification == LogNotification.Connected)
            {
                Snackbar.Enqueue("连接成功！");
            }
            else if (log.Notification == LogNotification.Waiting)
            {
                Snackbar.Enqueue("等待服务器分配位置");
            }
            else if (log.Notification == LogNotification.Stop)
            {
                Snackbar.Enqueue("连接关闭");
            }
            else if (log.Notification == LogNotification.TapNotInstalled)
            {
                Snackbar.Enqueue("未安装驱动，到Nyan n2n目录下安装tap-windows-9.24.7-I601-Win10.exe");
            }
            
        }
        public void ShutDown()
        {
            EdgeManager.Stop();
        }
    }
}
