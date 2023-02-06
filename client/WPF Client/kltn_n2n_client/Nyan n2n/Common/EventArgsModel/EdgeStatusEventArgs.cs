using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.EventArgsModel
{
    public class EdgeStatusEventArgs : EventArgs
    {
        public int StatusCode { get; set; }
    }
}
