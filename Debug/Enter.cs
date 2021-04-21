using System;
using System.Collections.Generic;
using DNS_WindowsServices.Files;
using DNS_WindowsServices.Utils;

namespace Debug
{
    class Enter
    {
        private static List<Instance> _ins;
        private static InstanceFiles _insfiles;
        static void Main(string[] args)
        {
            _ins = new List<Instance>();
=========
>>>>>>>>> Temporary merge branch 2
            _ins = new List<Instance>();
=========
>>>>>>>>> Temporary merge branch 2
            _ins = new List<Instance>();
=========
>>>>>>>>> Temporary merge branch 2
            _insfiles = new InstanceFiles(AppDomain.CurrentDomain.BaseDirectory + @"\ins.json");
            _insfiles.LoadFromFiles();
            _ins = _insfiles.GetInstances();
            foreach (Instance t in _ins)
                t.Start();
            Console.ReadKey();
        }
    }
}
