using System;
using System.Collections.Generic;
using System.Text;

namespace DNS_WindowsServices.Utils
{
    interface IInstanceManager
    {
        bool Modfiy();
        void Start();
        void Stop();
    }
}
