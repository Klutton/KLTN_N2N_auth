using Nyan_n2n.Common.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            if (log.Stop)
            {
                Log = $"Nyan 🐱\n{log.Message}";
            }
            Log += "\n" + log.Message;
        }
    }
}
