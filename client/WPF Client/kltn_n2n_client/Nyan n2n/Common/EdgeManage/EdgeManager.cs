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
        private bool _disposed = false;
        public bool Disposed
        {
            get { return _disposed; }
            set { _disposed = value; }
        }
        public EdgeManager(string args, IEventAggregator ea)
        {
            _eventAggregator = ea;
            _info = new ProcessStartInfo()
            {
                FileName = _file,
                UseShellExecute= false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = args
            };
        }
        public void Start()
        {
            if (_disposed) return;
            _disposed = true;
            Task.Run(() =>
            {
                _edge = new Process();
                _edge.StartInfo = _info;
                _edge.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    // Prepend line numbers to each line of the output.
                    if (!String.IsNullOrEmpty(e.Data))
                    {
                        RunLog _log = new RunLog()
                        {
                            Message = e.Data,
                            Stop = false
                        };
                        _eventAggregator.GetEvent<RunLogEvent>().Publish(_log);
                    }
                });
                _edge.Start();
                _edge.BeginOutputReadLine();
            });
        }
        public void Stop()
        {
            if (_disposed)
            {
                _disposed = true;
                try
                {
                    _edge.Kill();
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
