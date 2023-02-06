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
    }
}
