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
        }
        public event PropertyChangedEventHandler PropertyChanged;

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
            set {
                _foreground = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Foreground"));
            }
        }
        //绑定IsIndicatorVisible
        private string _connected = "False";
        public string Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Connected"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanConnect"));
            }
        }
        void UpdateStatus(RunStatus status)
        {
            if (status.IsRunning)
            {
                Status = "连接";
                Foreground = "Green";
                Connected = "True";
                CanConnect = "False";
            }

            else
            {
                Status = "断开";
                Foreground = "Red";
                Connected = "False";
                CanConnect = "True";
            }
        }
    }


}
