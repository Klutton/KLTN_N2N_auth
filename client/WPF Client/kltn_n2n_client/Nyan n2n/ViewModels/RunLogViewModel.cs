using Nyan_n2n.Common.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Nyan_n2n.ViewModels
{
    public class RunLogViewModel : INotifyPropertyChanged
    {
        IEventAggregator _eventAggregator;
        public RunLogViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RunLogEvent>().Subscribe(UpdateLog);
            _eventAggregator.GetEvent<RunStatusEvent>().Subscribe(UpdateStatus);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _log = "Nyan 🐱";
        public string Log
        {
            get { return _log; }
            set
            {
                _log = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Log"));
            }
        }
        void UpdateLog(RunLog log)
        {
            if (log.Start)
                Log = $"Nyan 🐱\n{log.Message}";
            if (!log.Start)
                Log += "\n" + log.Message;
        }

        //绑定状态
        private string _status = "断开";
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }
        //绑定颜色
        private string _foreground = "Red";
        public string Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Foreground"));
            }
        }
        void UpdateStatus(RunStatus status)
        {
            if (status.IsRunning)
            {
                Status = "连接";
                Foreground = "Green";
            }

            else
            {
                Status = "断开";
                Foreground = "Red";
            }
        }
    }
}
