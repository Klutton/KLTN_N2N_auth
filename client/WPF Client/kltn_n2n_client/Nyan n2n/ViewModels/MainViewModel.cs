﻿using Nyan_n2n.Common.Models;
using Nyan_n2n.Extensions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        public MainViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _eventAggregator = ea;
            RunLog _log = new RunLog()
            {
                Message = "Nyan 🐱",
                Stop = true
            };
            //_eventAggregator.GetEvent<RunLogEvent>().Publish(_log);
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this._regionManager = regionManager;
        }
        private bool _init = false;
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Namespace))
                return;
            if (!_init)
            {
                _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("RunLogView");
                _init = true;
            }
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
            MenuBars.Add(new MenuBar() { Icon = "NoteTextOutline", Title = "日志", Namespace = "RunLogView" });
            MenuBars.Add(new MenuBar() { Icon = "Account", Title = "关于", Namespace = "AboutView" });
        }
    }
}