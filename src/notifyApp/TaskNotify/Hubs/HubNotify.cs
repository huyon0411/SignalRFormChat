using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Entities;
using Microsoft.AspNet.SignalR.Hubs;
using static Entities.HubNotifyArgs;
using System.Threading.Tasks;

namespace TaskNotify.Hubs
{
    [HubName("NotifyHub")]
    public class HubNotify : Hub
    {
        public static List<UserInfo> users = new List<UserInfo>();
        public static List<Notify> notifies = new List<Notify>();
        public void Hello()
        {
            Clients.All.hello();
        }



        public void Join(JoinArg arg)
        {
            string cd = arg.Cd;
            string name = arg.Name;
            var user = new UserInfo()
            {
                SignalRId = this.GetCallerId(),
                UserCd = cd,
                Name = name
            };
            users.Add(user);
            notifies.Add(new Notify() {
                FromId = user.UserCd,
                ToId = user.SignalRId,
                FromCd = user.UserCd,
                ToCd = user.SignalRId,
                IsRead = false,
                Message = "追加しました"
            });
            this.GetNotifies().Wait();
            this.GetUsersList().Wait();
        }

        public void SendMessage(SendMessageArg arg)
        {
            var caller = this.GetUserByCurrentId();
            if (caller == null) { return; }
            var touser = this.GetUserByCd(arg.ToCd);
            if (touser == null) { return; }

            notifies.Add(new Notify()
            {
                FromId = caller.SignalRId,
                ToId = touser.SignalRId,
                FromCd = caller.UserCd,
                ToCd = touser.UserCd,
                IsRead = false,
                Message = arg.Message
            });
            this.SendNotifiesToUser(touser.SignalRId).Wait();
        }

        private UserInfo GetUserByCurrentId()
        {
            return users.FirstOrDefault(o => o.SignalRId == this.GetCallerId());
        }
        private UserInfo GetUserByCd(string cd)
        {
            return users.FirstOrDefault(o => o.UserCd == cd);
        }

        private string GetCallerId()
        {
            var signalrId = Context.ConnectionId;
            return signalrId;
        }

        public async Task SendNotifiesToUser(string userId)
        {
            var ret = notifies.Where(o => o.ToId == userId && !o.IsRead).ToList();
            await Clients.Client(userId).ReloadNotifies(ret);
        }

        public async Task GetUsersList()
        {
            string userId = this.GetCallerId();
            await Clients.Client(userId).ReloadUserList(users);
        }


        public async Task GetNotifies()
        {
            var id = this.GetCallerId();
            
            await this.SendNotifiesToUser(id);
        }

        public List<Notify> PushNotify(string toId, string msg)
        {
            return notifies.Where(o => o.ToId == this.GetCallerId()).ToList();
        }



    }
    
}