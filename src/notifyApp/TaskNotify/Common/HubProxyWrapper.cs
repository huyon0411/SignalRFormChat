﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskNotify.Common
{
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
            try
            {
                this.conn = new HubConnection(url);
                this.isParentConn = true;
                this.proxy = conn.CreateHubProxy(hubName);
                RegistServerMethod();
                this.Connect();
                this.WriteTrace(string.Format("Start hubProxy:{0} /:/ {1}", url, hubName));
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
            }
        }

        public void Connect()
        {
            this.WriteTrace("Start Connection start");
            conn.Start().Wait();
            this.WriteTrace("End Connection start");
        }

        /// <summary>
        /// Constructor for not Parent HubConnection 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="hubName"></param>
        public HubProxyWrapper(HubConnection conn, string hubName)
        {
            try
            {
                this.conn = conn;
                this.isParentConn = false;
                this.proxy = conn.CreateHubProxy(hubName);
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
            }
        }
        public void Disconnect()
        {
            if (this.isParentConn && this.conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                this.WriteTrace("Disconnect Stop hubProxy");
                try
                {
                    this.conn.Stop();
                }
                catch (Exception ex)
                {
                    ex.WriteExcept();
                }

            }
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Disconnect();
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
            this.WriteTrace("On:" + eventName);
            return proxy.On<T>(eventName, (arg) =>
            {
                this.WriteTrace("Call:" + eventName);
                eventExecute(arg);
            });
        }

        protected IDisposable On(Action eventExecute)
        {
            string eventName = eventExecute.Method.Name;
            this.WriteTrace("On:" + eventName);
            return proxy.On(eventName, ()=> {
                this.WriteTrace("Call:" + eventName);
                eventExecute();
            });
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

        public async Task Invoke(bool sendNull = false, [CallerMemberName] string method = null)
        {
            if (this.conn.State != ConnectionState.Connected) { return; }
            this.WriteTrace("Invoke:" + method);
            await proxy.Invoke(method);
        }


        /// <summary>
        /// call server method. that has "struct" args.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public async Task Invoke<T>(Nullable<T> args, bool sendNull = false, [CallerMemberName] string method = null) where T : struct
        {
            if (this.conn.State != ConnectionState.Connected) { return; }
            this.WriteTrace("Invoke:" + method);
            if (args == null && !sendNull)
            {
                await proxy.Invoke(method);
                return;
            }
            await proxy.Invoke(method, args.Value);
        }

        /// <summary>
        /// call server method. that has "class" args. Please use this!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public async Task Invoke<T>(T args, bool sendNull = false, [CallerMemberName] string method = null) where T : class
        {
            if (this.conn.State != ConnectionState.Connected) { return; }
            this.WriteTrace("Invoke:" + method);
            if (args == null && !sendNull)
            {
                await proxy.Invoke(method);
                return;
            }
            await proxy.Invoke(method, args);
        }

        /// <summary>
        /// call server method. that has "string" args.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="sendNull"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public async Task Invoke(string args, bool sendNull = false, [CallerMemberName] string method = null)
        {
            if (this.conn.State != ConnectionState.Connected) { return; }
            this.WriteTrace("Invoke:" + method);
            if (args == null && !sendNull)
            {
                await proxy.Invoke(method);
                return;
            }
            await proxy.Invoke(method, args);
        }
    }
}
