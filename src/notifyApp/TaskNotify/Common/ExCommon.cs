using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{

    public class PrivateLogger
    {
        /// <summary>
        /// Singlton Constructor
        /// </summary>
        private PrivateLogger() { }

        public static PrivateLogger Instance = new PrivateLogger();

        public StringBuilder Buffer = new StringBuilder();
        public enum OutputLevelType
        {
            Normal = 1,
            Trace = 2,
            Debug = 3,
        }
        public OutputLevelType OutputLevel { get; set; } = OutputLevelType.Trace;

        /// <summary>
        /// Trace Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public bool Trace<T>(T o)
        {
            if ((int)this.OutputLevel < (int)OutputLevelType.Trace) { return false; }
            this.dpNotNewLine("[Trace]");
            this.dp(o);
            return true;
        }
        /// <summary>
        /// Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public bool Normal<T>(T o)
        {
            if ((int)this.OutputLevel < (int)OutputLevelType.Normal) { return true; }
            this.dpNotNewLine("[Normal]");
            this.dp(o);
            return true;
        }
        /// <summary>
        /// Trace Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public bool Debug<T>(T o)
        {
            if ((int)this.OutputLevel < (int)OutputLevelType.Debug) { return true; }
            this.dpNotNewLine("[Debug]");
            this.dp(o);
            return true;
        }

        public void dpNotNewLine<T>(T o)
        {
            try
            {
                System.Diagnostics.Debug.Write(o);
                Buffer.Append(o.ToString());
            }
            catch (Exception) { }
        }

        public void dp<T>(T o)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(o);
                Buffer.Append(o.ToString());
                Buffer.Append("\r\n");
            }
            catch (Exception) { }
        }
    }

    public class LoggingEventArgs : EventArgs
    {
        public string LogStr { get; set; }
        public LoggingEventArgs(string logStr)
        {
            this.LogStr = LogStr;
        }
    }

    /// <summary>
    /// Extend Debug Output
    /// </summary>
    public static class ExCommon
    {
        public static StringBuilder Buffer { get { return PrivateLogger.Instance.Buffer; } }
        public static event EventHandler<LoggingEventArgs> Logging;
        
        private static void ExecLogging<T>(T o)
        {
            try
            {
                if (Logging != null)
                {
                    var logStr = o.ToString();
                    Logging(null, new LoggingEventArgs(logStr));
                }
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
            }

        }

        /// <summary>
        /// Trace Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public static void WriteTrace<T>(this object anyClass, T o)
        {
            if (PrivateLogger.Instance.Trace(o)) { ExecLogging(o); }
        }

        /// <summary>
        /// Debug Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public static void WriteDebug<T>(this object anyClass, T o)
        {
            if (PrivateLogger.Instance.Debug(o)) { ExecLogging(o); }
        }

        /// <summary>
        /// Trace Logging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyClass"></param>
        /// <param name="o"></param>
        public static void WriteLog<T>(this object anyClass, T o)
        {
            if (PrivateLogger.Instance.Normal(o)) { ExecLogging(o); }
        }

        /// <summary>
        /// Exception Logging
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteExcept(this Exception ex)
        {
            var logstr = LogUtil.GetExceptionLogStr(ex);
            if (PrivateLogger.Instance.Normal(logstr)) { ExecLogging(logstr); }
        }
    }
}
