using System;
using Topshelf;

namespace TopShelf.IPO.FP
{
    public class AppServer
    {
        public static void Run(AppConfig config, Action start, Action stop)
        {
            HostFactory.Run(x =>
            {
                x.Service<AppService>(s => new AppService(start, stop));
                //以local system模式运行
                x.RunAsLocalSystem();
                /*
                //启动类型设置
                x.StartAutomatically();//自动
                x.StartAutomaticallyDelayed();// 自动（延迟启动）
                x.StartManually();//手动
                x.Disabled();//禁用

                */
                //常规信息
                x.SetDescription(config.Description); //MyService服务的描述信息
                x.SetDisplayName(config.DisplayName); //MyService服务的显示名称
                x.SetServiceName(config.ServiceName); //MyService服务名称

                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                    rc.SetResetPeriod(1);
                    rc.RestartComputer(1, "System is restarting!");
                });
                //x.UseLog4Net();
                
                //异常捕获
                x.OnException(ex =>
                {
                    AppLogger.Info($"未处理的全局异常：{ex.Message}");
                    AppLogger.Info($"{ex.StackTrace}");
                });
            });
        }
    }
}
