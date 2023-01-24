using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    public class RunLogEvent : PubSubEvent<RunLog> { }
    public class RunLog
    {
        private bool _stop = false;
        public bool Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
