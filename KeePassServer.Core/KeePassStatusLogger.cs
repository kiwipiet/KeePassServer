using KeePassLib.Interfaces;
using System.Diagnostics;

namespace KeePassServer.Core
{
    public class KeePassStatusLogger : IStatusLogger
    {
        public static IStatusLogger Instance = new KeePassStatusLogger();

        public bool ContinueWork()
        {
            Trace.WriteLine(nameof(ContinueWork));
            return true;
        }

        public void EndLogging()
        {
            Trace.WriteLine(nameof(EndLogging));
        }

        public bool SetProgress(uint uPercent)
        {
            Trace.WriteLine($"{nameof(SetProgress)}:{uPercent}");
            return true;
        }

        public bool SetText(string strNewText, LogStatusType lsType)
        {
            Trace.WriteLine($"{lsType}:{nameof(SetText)}:{strNewText}");
            return true;
        }

        public void StartLogging(string strOperation, bool bWriteOperationToLog)
        {
            Trace.WriteLine($"{nameof(StartLogging)}:{strOperation}:{bWriteOperationToLog}");
        }
    }
}
