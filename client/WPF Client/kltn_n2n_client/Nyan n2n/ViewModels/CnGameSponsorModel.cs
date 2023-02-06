using Nyan_n2n.Common.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.ViewModels
{
    public class CnGameSponsorModel : INotifyPropertyChanged
    {
        IEventAggregator _eventAggregator;
        public CnGameSponsorModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RunStatusEvent>().Subscribe(UpdateStatus);
        }
        public event PropertyChangedEventHandler PropertyChanged;


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
                Connected = "True";
                CanConnect = "False";
            }

            else
            {
                Connected = "False";
                CanConnect = "True";
            }
        }
    }

}
