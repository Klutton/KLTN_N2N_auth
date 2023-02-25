using ImTools;
using Nyan_n2n.Common.Models;
using Nyan_n2n.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                bool connecting = true;
                bool waiting = true;
                bool connected = true;
                bool tapNotInstalled = true;

                string Connecting = "send REGISTER_SUPER to supernode";
                string Connected = "[OK]";
                string Waiting = "ERROR: authentication error, MAC or IP address already in use or not released yet by supernode";
                string TapNotInstalled = "No Windows tap devices found";

                _edge.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        log = new RunLog()
                        {
                            Notification = LogNotification.None,
                            Message = e.Data,
                            Start = false
                        };

                        //通知连接状态
                        if (Regex.IsMatch(e.Data, Connecting) && connecting)
                        {
                            connecting = false;
                            log.Notification = LogNotification.Connecting;
                        }
                        if (Regex.IsMatch(e.Data, Waiting) && waiting)
                        {
                            waiting = false;
                            log.Notification = LogNotification.Waiting;
                        }
                        if (Regex.IsMatch(e.Data, Connected) && connected)
                        {
                            connected = false;
                            log.Notification = LogNotification.Connected;
                        }
                        if (Regex.IsMatch(e.Data, TapNotInstalled) && tapNotInstalled)
                        {
                            tapNotInstalled = false;
                            log.Notification = LogNotification.TapNotInstalled;
                        }

                        _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
                    }
                });
                _edge.Start();

                RunStatus status = new RunStatus(true);
                _eventAggregator.GetEvent<RunStatusEvent>().Publish(status);

                _edge.BeginOutputReadLine();
                _edge.WaitForExit();
                _running = false;
                log.Notification = LogNotification.Stop;
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
