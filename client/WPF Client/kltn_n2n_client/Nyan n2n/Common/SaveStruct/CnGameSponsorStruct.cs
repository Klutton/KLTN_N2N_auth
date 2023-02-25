using Nyan_n2n.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.SaveStruct
{
    [Serializable]
    public class CnGameSponsorStruct
    {
        public ServerListItem ServerListItem { get; set; } = null;
        public bool ForceRelay { get; set; } = false;
    }
}
