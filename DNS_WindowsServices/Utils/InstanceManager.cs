using System.Collections.Generic;

namespace DNS_WindowsServices.Utils
{
    public abstract class InstanceManager
    {
        public abstract bool Modfiy();
        public abstract void Start();
        public abstract void Stop();
    }
}
