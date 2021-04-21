using DNS_WindowsServices.Utils;
using System.ServiceProcess;

namespace DNS_WindowsServices
{
    class MainEn
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new Service());
        }
    }
}
