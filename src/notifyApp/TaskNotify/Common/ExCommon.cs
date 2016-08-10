using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{
    /// <summary>
    /// Extend Debug Output
    /// </summary>
    public static class ExCommon
    {
        public static StringBuilder Buffer = new StringBuilder();
        public static event EventHandler<EventArgs> Logging;
        public static void dp<T>(this object anyClass, T o)
        {
#if DEBUG
            try
            {
                System.Diagnostics.Debug.WriteLine(o);
                //System.Windows.Forms.MessageBox.Show(o.ToString());
                Buffer.Append(o.ToString());
                Buffer.Append("\r\n");
                if (Logging != null)
                {
                    Logging(null, new EventArgs());
                }
            }
            catch (Exception) { }
#endif
        }
    }
}
