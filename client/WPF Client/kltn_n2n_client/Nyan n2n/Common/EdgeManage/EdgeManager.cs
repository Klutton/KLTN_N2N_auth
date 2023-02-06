using ImTools;
using Nyan_n2n.Common.EventArgsModel;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyan_n2n.Common.EdgeManage
{
    public class EdgeManager
    {
        static IEventAggregator _eventAggregator;
        private static bool _running = false;
        public static string Args;
        public static void SetEventAggregator(IEventAggregator ea)
        {
            _eventAggregator = ea;
        }

        public static void Start(string args)
        {
            Stop();

            ProcessStartInfo info = new ProcessStartInfo("edge.exe")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                Arguments = args,
            };

            RunLog log = new RunLog()
            {
                Message = $"正在尝试创建连接...\n使用参数{args}",
                Start = true
            };
            _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
            //新开一个线程运行edge
            Task.Run(() =>
            {
                if(!_running )
                    _running = true;

                _edge = new Process();
                _edge.StartInfo = info;
                _edge.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        log = new RunLog()
                        {
                            Message = e.Data,
                            Start = false
                        };
                        _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
                    }
                });
                _edge.Start();

                RunStatus status = new RunStatus(true);
                _eventAggregator.GetEvent<RunStatusEvent>().Publish(status);

                _edge.BeginOutputReadLine();
                _edge.WaitForExit();
                _running = false;
                log.Message = "程序退出（若闪退请检查参数完整性、文件完整性、虚拟网卡是否安装）";
                log.Start = false;
                _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
                //广播进程结束
                status.IsRunning = false;
                _eventAggregator.GetEvent<RunStatusEvent>().Publish(status);
                _edge.Dispose();
            });
        }
        public static void Stop()
        {
            if (_running)
            {
                if (_edge == null)
                {
                    _running = false;
                    return;
                }
                if (!_edge.HasExited)
                {
                    _edge.Kill();
                    _edge.Dispose();
                    RunLog log = new RunLog()
                    {
                        Message = null,
                        Start = false
                    };
                    _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
                }
                _running = false;
            }
        }
        private static Process _edge;
        private string _file = "edge.exe";
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}
