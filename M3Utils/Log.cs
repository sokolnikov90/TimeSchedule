using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Threading;
using System.Text;

using NLog;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace M3Utils
{
    public static class Log
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                if (instance != null) return instance;

                ConfigureNlog();

                Logger tempLog = LogManager.GetCurrentClassLogger();

                Interlocked.CompareExchange(ref instance, tempLog, null);

                return instance;
            }
        }
         
        private static void ConfigureNlog()
        {
            FileTarget target = new FileTarget
                                    {
                                        FileName =
                                            Directory.GetCurrentDirectory()
                                            + "\\Logs\\CardReader.Log_${date:format=ddMMyyyy}.txt",
                                        KeepFileOpen = false,
                                        Encoding = Encoding.GetEncoding("windows-1251"),
                                        Layout =
                                            "${date:format=HH\\:mm\\:ss.fff}|${level:padding=5:uppercase=true}|${message}"
                                    };


            AsyncTargetWrapper wrapper = new AsyncTargetWrapper
                                             {
                                                 WrappedTarget = target,
                                                 QueueLimit = 5000,
                                                 OverflowAction =
                                                     AsyncTargetWrapperOverflowAction.Block
                                             };

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(wrapper, LogLevel.Info);
        }
    }
}