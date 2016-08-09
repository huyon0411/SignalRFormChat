using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{
    /// <summary>
    /// Extend Debug Output
    /// </summary>
    public static class ExCommon
    {
        public static void dp<T>(this object anyClass, T o)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(o);
#endif
        }
    }

    /// <summary>
    /// IHubProxy's Wrapper.
    /// it have a HubConnection ... but not checked some Proxy doing.
    /// </summary>
    public abstract class HubProxyWrapper : IDisposable
    {
        public class HubProxyOnArgs<T> : EventArgs
        {
            public T Arg { get; set; }
        }
        /// <summary>
        /// HubConnection
        /// </summary>
        public HubConnection conn { get; set; } = null;

        /// <summary>
        /// inner IHubProxy 
        /// </summary>
        public IHubProxy proxy { get; set; } = null;

        /// <summary>
        /// is Parent HubConnection
        /// </summary>
        private bool isParentConn = false;

        /// <summary>
        /// Regist Server method 
        /// </summary>
        public abstract void RegistServerMethod();

        /// <summary>
        /// Constructor for Parent HubConnection 
        /// </summary>
        /// <param name="url">Signalr Url ex. http://128.0.0.1:8080/</param>
        /// <param name="hubName">access hubName</param>
        public HubProxyWrapper(string url, string hubName)
        {
            this.conn = new HubConnection(url);
            this.isParentConn = true;
            this.proxy = conn.CreateHubProxy(hubName);
            this.dp(string.Format("Start hubProxy:{0} /:/ {1}", url, hubName));
            RegistServerMethod();
            conn.Start().Wait();
        }

        /// <summary>
        /// Constructor for not Parent HubConnection 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="hubName"></param>
        public HubProxyWrapper(HubConnection conn, string hubName)
        {
            this.conn = conn;
            this.isParentConn = false;
            this.proxy = conn.CreateHubProxy(hubName);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (this.isParentConn && this.conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                this.dp("Stop hubProxy");
                this.conn.Stop();
            }
        }

        /// <summary>
        /// Regist the event that call from server.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventExecute"></param>
        /// <returns></returns>
        protected IDisposable On<T>(Action<T> eventExecute)
        {
            string eventName = eventExecute.Method.Name;
            this.dp("On:" + eventName);
            return proxy.On<T>(eventName, eventExecute);
        }

        // It did not work (´・ω・｀)
        //public Task Invoke([CallerMemberName] string method = null, params object[] args)
        //{
        //    dp("Invoke:" + method);
        //    return proxy.Invoke(method, args);
        //}

        // I have more than one argument not assume.
        // To prepare the argument class you were it.
        // Because it is beautiful better of over there.

        /// <summary>
        /// call server method. that has "struct" args.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public Task Invoke<T>(Nullable<T> args = null, bool sendNull = false, [CallerMemberName] string method = null) where T : struct
        {
            this.dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args.Value);
        }

        /// <summary>
        /// call server method. that has "class" args. Please use this!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public Task Invoke<T>(T args = null, bool sendNull = false, [CallerMemberName] string method = null) where T : class
        {
            this.dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args);
        }

        /// <summary>
        /// call server method. that has "string" args.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public Task Invoke(string args = null, bool sendNull = false, [CallerMemberName] string method = null)
        {
            this.dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args);
        }
    }
}
