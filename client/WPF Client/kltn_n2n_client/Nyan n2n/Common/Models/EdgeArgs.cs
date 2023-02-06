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
        public EdgeArgs(string host, string community)
        {
            Host = host;
            if (community != null && community != "") { Community = community; }
        }
        /*清单：
         * -c 社区
         * -l 主机
         * -S1 强制中转（使用UDP）
         * -S2 强制中转（使用TCP）我擦Windows不支持
         * -z1 压缩传输lzo1x
         * -z2 压缩传输zstd
         * --no-port-forwarding 关闭UPnP/PMP端口转发
         * -a 自定义虚拟ip（不推荐）
         * -E 网卡启用多播
         * -x 网卡优先级*/
        public string GenerateArgs()
        {
            string args = string.Empty;
            args += "-l " + Host;
            args += " -c " + Community;
            if (_forceRelay) args += " -S1 ";
            if (_zip == ZipEnum.LZO1x) args += " -z1 ";
            if (_zip == ZipEnum.ZSTD) args += " -z2 ";
            if (_noPortForwarding) args += " --no-port-forwarding ";
            if (_virtualIp != null && _virtualIp != "") args += " -a " + _virtualIp;
            if (_multicastMAC) args += " -E ";
            if (_priority != "0" && _priority != "") args += " -x " + _priority;
            return args;
        }

        //社区
        private string _community = "NETWORKS";
        public string Community
        {
            get { return _community; }
            set { _community = value; }
        }
        //主机
        private string _host;
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        //强制中转（使用UDP）
        private bool _forceRelay = false;
        public bool ForceRelay
        {
            get { return _forceRelay; }
            set { _forceRelay = value; }
        }
        /* -z1 压缩传输lzo1x
         * -z2 压缩传输zstd*/
        public enum ZipEnum
        {
            None,
            LZO1x,
            ZSTD
        }
        private ZipEnum _zip = ZipEnum.None;
        public ZipEnum Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        //关闭UPnP/PMP端口转发
        private bool _noPortForwarding = false;
        public bool NoPortForwarding
        {
            get { return _noPortForwarding; }
            set { _noPortForwarding = value; }
        }
        //自定义虚拟ip（不推荐）
        private string _virtualIp = null;
        public string VirtualIp
        {
            get { return _virtualIp; }
            set { _virtualIp = value; }
        }
        //网卡启用多播
        private bool _multicastMAC = true;
        public bool MulticastMAC
        {
            get { return _multicastMAC; }
            set { _multicastMAC = value; }
        }
        //网卡优先级
        private string _priority = "1";
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
