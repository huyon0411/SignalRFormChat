using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{
    public abstract class HubProxyWrapper : IDisposable
    {
        public HubConnection conn { get; set; } = null;
        public IHubProxy proxy { get; set; } = null;
        private bool isParentConn = false;

        public abstract void RegistServerMethod();

        public HubProxyWrapper(string url, string hubName)
        {
            this.conn = new HubConnection(url);
            this.isParentConn = true;
            this.proxy = conn.CreateHubProxy(hubName);
            dp(string.Format("Start hubProxy:{0} / {1}", url, hubName));
            RegistServerMethod();
            conn.Start().Wait();
        }

        public HubProxyWrapper(HubConnection conn, string hubName)
        {
            this.conn = conn;
            this.isParentConn = false;
            this.proxy = conn.CreateHubProxy(hubName);
        }

        public void Dispose()
        {
            if (this.isParentConn && this.conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                dp("Stop hubProxy");
                this.conn.Stop();
            }
        }

        protected IDisposable On<T>(Action<T> eventExecute)
        {
            string eventName = eventExecute.Method.Name;
            dp("On:" + eventName);
            return proxy.On<T>(eventName, eventExecute);
        }

        //public Task Invoke([CallerMemberName] string method = null, params object[] args)
        //{
        //    dp("Invoke:" + method);
        //    return proxy.Invoke(method, args);
        //}

        public Task Invoke<T>(Nullable<T> args = null, bool sendNull = false, [CallerMemberName] string method = null) where T : struct
        {
            dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args.Value);
        }

        public Task Invoke<T>(T args = null, bool sendNull = false, [CallerMemberName] string method = null) where T : class
        {
            dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args);
        }

        public Task Invoke(string args = null, bool sendNull = false, [CallerMemberName] string method = null)
        {
            dp("Invoke:" + method);
            if (args == null && !sendNull)
            {
                return proxy.Invoke(method);
            }
            return proxy.Invoke(method, args);
        }

        private void dp<T>(T o)
        {
            System.Diagnostics.Debug.WriteLine(o);
        }

    }

}
