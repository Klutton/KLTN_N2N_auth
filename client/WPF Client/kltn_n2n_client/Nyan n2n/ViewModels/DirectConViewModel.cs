using MaterialDesignColors;
using Nyan_n2n.Common.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nyan_n2n.ViewModels
{
    public class DirectConViewModel : INotifyPropertyChanged
    {
        IEventAggregator _eventAggregator;
        public DirectConViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RunStatusEvent>().Subscribe(UpdateStatus);
            //DisConUpdate = new RelayCommand(Search);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DisConUpdate { get; set; }
        public ICommand ConUpdate { get; set; }

        private string _status = "Nyan 🐱";
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }
        void UpdateStatus(RunStatus status)
        {
            if (status.IsRunning)
                Status = "连接";
            else
                Status = "断开";
        }
    }


}
