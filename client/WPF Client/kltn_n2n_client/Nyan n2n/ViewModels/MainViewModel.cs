using Nyan_n2n.Common;
using Nyan_n2n.Common.EdgeManage;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Extensions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("RunLogView");
            _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeView");
        }

        public void ShutDown()
        {
            EdgeManager.Stop();
        }
    }
}
