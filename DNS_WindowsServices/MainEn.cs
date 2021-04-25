using DNS_WindowsServices.Utils;
using System.ServiceProcess;

namespace DNS_WindowsServices
{
    class MainEn
    {
        public Language defaultLanguage { get; set; }
        static void Main(string[] args)
        {
            ServiceBase.Run(new Service());
        }
    }
}
