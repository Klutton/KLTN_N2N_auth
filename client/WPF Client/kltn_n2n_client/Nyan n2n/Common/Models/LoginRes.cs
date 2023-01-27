using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    public class LoginRes
    {
        public LoginRes(bool success)
        {

        }
        /// <summary>
        /// 先判断是否成功
        /// </summary>
        private bool _success;
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }
        /// <summary>
        /// 服务器名字
        /// </summary>
        private string _serverName;
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }
        /// <summary>
        /// 服务器信息
        /// </summary>
        private string _serverInfo;
        public string ServerInfo
        {
            get { return _serverInfo; }
            set { _serverInfo = value; }
        }
        private List<string> _servers;
        public List<string> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }
    }
}
