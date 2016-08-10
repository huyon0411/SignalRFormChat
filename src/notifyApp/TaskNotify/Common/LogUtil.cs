using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{
    public class LogUtil
    {
        public static string GetExceptionLogStr(Exception e)
        {
            string ret = "";
            ret += e.Message;
            ret += "\n((StackTrace))\n";
            ret += e.StackTrace;
            if(e.InnerException != null)
            {
                var e2 = e.InnerException;
                ret += "\n(InnerException)\n";
                ret += GetExceptionLogStr(e2);
            }
            return ret;
        }
    }
}
