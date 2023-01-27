using ImTools;
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
        IEventAggregator _eventAggregator;
        private bool _running = false;
        public bool Disposed
        {
            get { return _running; }
            set { _running = value; }
        }
        private string _args;
        public EdgeManager(string args, IEventAggregator ea)
        {
            _args = args;
            _eventAggregator = ea;
            _info = new ProcessStartInfo("edge.exe")
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                Arguments = args,
            };
        }
        public void Start()
        {
            if (_running) return;
            _running = true;
            RunLog _log = new RunLog()
            {
                Message = $"正在尝试创建连接...\n使用参数{_args}",
                Stop = false
            };
            _eventAggregator.GetEvent<RunLogEvent>().Publish(_log);
            Task.Run(() =>
            {
                _edge = new Process();
                _edge.StartInfo = _info;
                _edge.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        _log = new RunLog()
                        {
                            Message = e.Data,
                            Stop = false
                        };
                        _eventAggregator.GetEvent<RunLogEvent>().Publish(_log);
                    }
                });
                _edge.Start();
                _edge.BeginOutputReadLine();
                _edge.WaitForExit();
                _log.Message = "程序退出（若闪退请检查参数完整性以及文件完整性，后续版本会在启动前检查参数）";
                _eventAggregator.GetEvent<RunLogEvent>().Publish(_log);
                _edge.Dispose();
            });
        }
        public void Stop()
        {
            if (_running)
            {
                _running = true;
                try
                {
                    _edge.Kill();
                    _edge.Dispose();
                    RunLog log = new RunLog()
                    {
                        Message = null,
                        Stop = true
                    };
                    _eventAggregator.GetEvent<RunLogEvent>().Publish(log);
                }
                catch(Exception ex)
                {
                    RunLog __log = new RunLog()
                    {
                        Message = ex.Message,
                        Stop = true
                    };
                    _eventAggregator.GetEvent<RunLogEvent>().Publish(__log);
                }
            }
        }
        private Process _edge;
        private ProcessStartInfo _info;
        private string _file = "edge.exe";
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}
