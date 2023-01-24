using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.Models
{
    /// <summary>
    /// 通过该模型初始化edge后转换成为字符串
    /// </summary>
    public class EdgeArgs
    {
        public EdgeArgs(string host, string port, string community)
        {
            Host = host;
            Port = port;
            if(community != null && community != "") { Community = community; }
        }
        public string GenerateArgs()
        {
            string args = string.Empty;
            args += "-l " + Host.ToString() + ":" + Port.ToString();
            args += " -c " + Community;
            //args += " -d " + EdgeName;
            args += " -k " + RandomString(16);
            return args;
        }
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// 社区名称
        /// </summary>
        private string _community = "NETWORKS";
        public string Community
        {
            get { return _community; }
            set { _community = value; }
        }
        /// <summary>
        /// 服务器ip
        /// </summary>
        private string _host;
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        /// <summary>
        /// 服务器端口
        /// </summary>
        private string _port;
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
        /// <summary>
        /// edge用户名称
        /// </summary>
        private string _edgeName = "kltn_n2n_edge";
        public string EdgeName
        {
            get { return _edgeName; }
            set { _edgeName = value; }
        }
    }
}
