using System;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Controller.Utils
{
    class Service
    {
        public string serviceName { get; set; }
        private ServiceController serviceController;

        public Service(string serviceName)
        {
            this.serviceName = serviceName;

            foreach (ServiceController sc in ServiceController.GetServices())
            {
                if (sc.DisplayName.Equals(this.serviceName))
                {
                    this.serviceController = sc;
                    break;
                }
            }
        }
    }
}
