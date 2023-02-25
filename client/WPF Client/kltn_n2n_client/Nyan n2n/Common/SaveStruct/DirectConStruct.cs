using Nyan_n2n.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.SaveStruct
{
    [Serializable]
    public class DirectConStruct
    {
        public string Host { get; set; } = string.Empty;
        public string VirtualIp { get; set; } = string.Empty;
        public string Community { get; set; } = string.Empty;
        public bool ForceRelay { get; set; } = false;
        public bool NoPortForwarding { get; set; } = false;
        public int ZipEnum { get; set; } = -1;
        public bool MulticastMAC { get; set; } = true;
        public string Priority { get; set; } = "1";
    }
}
