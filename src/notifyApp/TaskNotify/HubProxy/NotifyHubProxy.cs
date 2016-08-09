﻿using Entities;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNotify.Common;

namespace TaskNotify.HubProxy
{
    public class NotifyHubProxy : HubProxyWrapper
    {
        public static string HubName = "NotifyHub";

        #region event

        public event EventHandler<HubProxyOnArgs<List<Notify>>> OnReloadNotifies;
        public event EventHandler<HubProxyOnArgs<List<UserInfo>>> OnReloadUserList;

        #endregion event

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="hubName"></param>
        public NotifyHubProxy(string url, string hubName) : base(url, hubName) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="hubName"></param>
        public NotifyHubProxy(HubConnection conn, string hubName) : base(conn, hubName) { }

        #endregion

        public override void RegistServerMethod()
        {
            this.On<List<Notify>>(this.ReloadNotifies);
            this.On<List<UserInfo>>(this.ReloadUserList);
        }

        #region method Call from Server

        private void ReloadUserList(List<UserInfo> users)
        {
            OnReloadUserList.Invoke(this, new HubProxyOnArgs<List<UserInfo>>() { Arg = users });
        }

        public void ReloadNotifies(List<Notify> notifies)
        {
            OnReloadNotifies.Invoke(this, new HubProxyOnArgs<List<Notify>>() { Arg = notifies });
        }

        #endregion method Call from Server

        #region server method call

        public Task GetNotifies()
        {
            return this.Invoke();
        }

        public Task Join(string cd, string name)
        {
            var arg = new HubNotifyArgs.JoinArg()
            {
                Cd = cd,
                Name = name
            };
            return this.Invoke(arg);
        }

        public Task SendMessage(string cd, string message)
        {
            var arg = new HubNotifyArgs.SendMessageArg()
            {
                ToCd = cd,
                Message = message
            };
            return this.Invoke(arg);
        }

        public Task GetUsersList()
        {
            return this.Invoke();
        }

        #endregion server method call

    }

}
