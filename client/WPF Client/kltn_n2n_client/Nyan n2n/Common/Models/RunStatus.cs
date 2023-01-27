using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    public class RunStatusEvent : PubSubEvent<RunStatus> { }
    public class RunStatus
    {
        public RunStatus(bool status) { _isRunning = status; }
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }
    }
}
