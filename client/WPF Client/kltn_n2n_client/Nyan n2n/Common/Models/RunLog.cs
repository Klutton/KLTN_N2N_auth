using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    public class RunLogEvent : PubSubEvent<RunLog> { }
    public enum LogNotification
    {
        None,
        Connected,
        Waiting,
        Connecting,
        TapNotInstalled,
        Stop
    }
    public class RunLog
    {
        private bool _start = false;
        public bool Start
        {
            get { return _start; }
            set { _start = value; }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private LogNotification _notification = LogNotification.None;
        public LogNotification Notification
        {
            get { return _notification; }
            set { _notification = value; }
        }
    }
}
