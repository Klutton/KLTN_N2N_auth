using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    [Serializable]
    public class ServerListItem
    {
        public override int GetHashCode()
        {
            return this.Addr.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ServerListItem other = obj as ServerListItem;
            if (this.Name == other.Name && this.Addr == other.Addr)
                return true;
            return false;
        }
        public static bool operator == (ServerListItem a, ServerListItem b)
        {
            if (a.Addr == b.Addr && a.Name == b.Name) return true;
            else return false;
        }
        public static bool operator != (ServerListItem a, ServerListItem b)
        {
            if (a.Addr != b.Addr && a.Name != b.Name) return true;
            else return false;
        }
        /*public ServerListItem(string n, string a)
        {
            Name = n;
            Addr = a;
        }*/
        /// <summary>
        /// 服务器名字
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 服务器地址
        /// </summary>
        private string _addr;
        public string Addr
        {
            get { return _addr; }
            set { _addr = value; }
        }
    }
}
