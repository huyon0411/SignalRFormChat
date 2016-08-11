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

}
