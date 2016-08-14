using Entities;
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
        public event EventHandler<HubProxyOnArgs<long>> OnReadByUser;
        public event EventHandler<HubProxyOnArgs<Notify>> OnSendSuccess;

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
            this.On(this.GetChangeUser);
            this.On<long>(this.ReadByUser);
            this.On<Notify>(this.SendSuccess);
            
        }

        #region method Call from Server

        private async void GetChangeUser()
        {
            await this.GetUsersList();
        }

        private void ReloadUserList(List<UserInfo> users)
        {
            OnReloadUserList.Invoke(this, new HubProxyOnArgs<List<UserInfo>>() { Arg = users });
        }

        public void ReloadNotifies(List<Notify> notifies)
        {
            OnReloadNotifies.Invoke(this, new HubProxyOnArgs<List<Notify>>() { Arg = notifies });
        }
        public void ReadByUser(long seq)
        {
            OnReadByUser.Invoke(this, new HubProxyOnArgs<long>() { Arg = seq });
        }

        public void SendSuccess(Notify notify)
        {
            OnSendSuccess.Invoke(this, new HubProxyOnArgs<Notify>() { Arg = notify });
        }

        #endregion method Call from Server

        #region server method call

        public async Task ReadNotify(long seq)
        {
            var arg = new HubNotifyArgs.ReadNotifyArg()
            {
                Seq = seq
            };
            await this.Invoke(arg);
        }

        public async Task GetNotifies()
        {
            await this.Invoke();
        }

        public async Task Join(string cd, string name)
        {
            var arg = new HubNotifyArgs.JoinArg()
            {
                Cd = cd,
                Name = name
            };
            await this.Invoke(arg);
        }

        public async Task SendMessage(string cd, string message)
        {
            var arg = new HubNotifyArgs.SendMessageArg()
            {
                ToCd = cd,
                Message = message
            };
            await this.Invoke(arg);
        }

        public async Task GetUsersList()
        {
            await this.Invoke();
        }

        public async Task Leave(string userCd)
        {
            var arg = new HubNotifyArgs.LeaveArg()
            {
                UserCd = userCd
            };
            await this.Invoke(arg);
        }
        #endregion server method call

    }

}
