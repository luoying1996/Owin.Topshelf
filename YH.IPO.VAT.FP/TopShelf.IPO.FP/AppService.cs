using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Topshelf;

namespace TopShelf.IPO.FP
{
    internal class AppService : ServiceControl
    {
        private Action _start, _stop;

        public AppService(Action start, Action stop)
        {
            _start = start;
            _stop = stop;
        }

        public bool Start(HostControl hostControl)
        {
            AppLogger.Info("服务已启动！");
            //主逻辑服务
            try
            {
                _start?.Invoke();
            }
            catch (Exception ex)
            {
                AppLogger.Info($"未处理的主进程异常: {ex.Message}");
                AppLogger.Info(ex.StackTrace);
            }
            //WebAPI服务
            if (AppConfig.Default.HttpPort > 0)
            {
                //string url = $"http://+:{ AppConfig.Default.HttpPort}";
                //if (System.Diagnostics.Debugger.IsAttached)
                //{
                string url = $"http://127.0.0.1:{AppConfig.Default.HttpPort}";
                //}
                WebApp.Start<WebAPIConfig>(url);
                AppLogger.Info($"WebAPI启动，端口：{AppConfig.Default.HttpPort}");
                //if (System.Diagnostics.Debugger.IsAttached)
                //{
                AppLogger.Info("端口启动");
                Process.Start($"{url}/swagger/ui/index");
                //}
            }
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _stop?.Invoke();
            return true;
        }
    }

}
