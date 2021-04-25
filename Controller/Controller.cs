using Controller.Utils;
using System;
using System.Collections;
using System.IO;
using System.ServiceProcess;

namespace Controller
{
    class Controller
    {
        static void Main(string[] args)
        {
  
            MainInstaller a = new MainInstaller();
            a.Install(new ProDictionary());
        }
    }
}
