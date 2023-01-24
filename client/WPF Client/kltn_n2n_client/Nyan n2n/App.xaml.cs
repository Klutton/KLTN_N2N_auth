using DryIoc;
using Nyan_n2n.ViewModels;
using Nyan_n2n.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nyan_n2n
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
            containerRegistry.RegisterForNavigation<AuthConView, AuthConViewModel>();
            containerRegistry.RegisterForNavigation<RunLogView, RunLogViewModel>();
            containerRegistry.RegisterForNavigation<DirectConView, DirectConViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        }
    }
}
