using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{

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
