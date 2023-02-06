using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    public class Server
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    public class ServerList
    {
        public ServerList(string n, string a)
        {
            Name = n;
            Addr = a;
        }
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
