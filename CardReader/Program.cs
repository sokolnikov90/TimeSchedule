using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CardReader
{
    using SQLite;

    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            M3Utils.Log.Instance.Info("Main 0");
            ServicesToRun = new ServiceBase[] 
            { 
                new CardReader() 
            };
            M3Utils.Log.Instance.Info("Main 1");
            ServiceBase.Run(ServicesToRun);
        }
    }
}
