using DNS_WindowsServices.Files;
using System.Collections.Generic;
using System.ServiceProcess;

namespace DNS_WindowsServices.Utils
{
    class Service : ServiceBase
    {
        private static List<Instance> _ins;
        private static InstanceFiles _insfiles;

        //服务启动
        protected override void OnStart(string[] args)
        {
            _insfiles = new InstanceFiles();
            _insfiles.LoadFromFiles();

            foreach (var i in _ins)
                i.Start();

            Log.OutLine("服务启动成功!");
            base.OnStart(args);
        }

        //服务停止
        protected override void OnStop()
        {

            foreach (var t in _ins)
            {
                if (t.stats)
                    Log.OutLine("[" + t.instanceName + "]" + "已执行: " + t.GetTimes().ToString() + "次" );
            }

            Log.OutLine("服务已停止!");
            base.OnStop();
        }

        //服务暂停
        protected override void OnPause()
        {
            Log.OutLine("服务已暂停!");
            base.OnPause();
        }
    }
}
