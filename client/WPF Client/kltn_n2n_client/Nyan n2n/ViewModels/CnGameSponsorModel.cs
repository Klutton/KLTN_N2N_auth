using DryIoc;
using MaterialDesignThemes.Wpf;
using Nyan_n2n.Common.Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.ViewModels
{
    public class CnGameSponsorModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        public CnGameSponsorModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RunStatusEvent>().Subscribe(UpdateStatus);
        }


        //绑定IsIndicatorVisible
        private string _connected = "False";
        public string Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                RaisePropertyChanged();
            }
        }
        //绑定IsEnabled
        private string _canConnect = "True";
        public string CanConnect
        {
            get { return _canConnect; }
            set
            {
                _canConnect = value;
                RaisePropertyChanged();
            }
        }
        //绑定Text
        private string _startStatus = "启动";
        public string StartStatus
        {
            get { return _startStatus; }
            set
            {
                _startStatus = value;
                RaisePropertyChanged();
            }
        }
        void UpdateStatus(RunStatus status)
        {
            if (status.IsRunning)
            {
                Connected = "True";
                CanConnect = "False";
                StartStatus = "运行中";

                if (status.IsRunning) { }
            }

            else
            {
                Connected = "False";
                CanConnect = "True";
                StartStatus = "启动";
            }
        }
    }

}
