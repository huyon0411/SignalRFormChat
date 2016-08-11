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
        public static long seq = 0;
        public static object seqlock = new object();
        public long GetNextSeq()
        {
            lock (seqlock)
            {
                seq += 1;
                return seq;
            }
        }

        /// <summary>
        /// connect users List
        /// </summary>
        public static List<UserInfo> users = new List<UserInfo>();

        /// <summary>
        /// message List. 
        /// Todo: remove it.
        /// </summary>
        public static List<Notify> notifies = new List<Notify>();
        public void Hello()
        {
            Clients.All.hello();
        }

        /// <summary>
        /// [Call]Join
        /// </summary>
        /// <param name="arg"></param>
        /// <remarks>
        /// Call when User Login.
        /// </remarks>
        public void Join(JoinArg arg)
        {
            string cd = arg.Cd;
            string name = arg.Name;
            string id = this.GetCallerId();
            var user = new UserInfo()
            {
                SignalRId = this.GetCallerId(),
                UserCd = cd,
                Name = name
            };
            if (!users.Any(o=>o.SignalRId == id))
            {
                users.Add(user);
                notifies.Add(new Notify()
                {
                    Seq = GetNextSeq(),
                    FromUser = user,
                    ToUser = user,
                    IsRead = false,
                    Message = "追加しました"
                });
            }else
            {
                notifies.Add(new Notify()
                {
                    Seq = GetNextSeq(),
                    FromUser = user,
                    ToUser = user,
                    IsRead = false,
                    Message = "追加しました"
                });
            }
            this.GetNotifies().Wait();
            this.GetUsersList().Wait();
            this.SendChangeUsers().Wait();
        }

        public void SendMessage(SendMessageArg arg)
        {
            var caller = this.GetUserByCurrentId();
            if (caller == null) { return; }
            var touser = this.GetUserByCd(arg.ToCd);
            if (touser == null) { return; }

            notifies.Add(new Notify()
            {
                Seq = GetNextSeq(),
                FromUser = caller,
                ToUser  = touser,
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
            var ret = notifies.Where(o => o.ToUser.SignalRId == userId && !o.IsRead).ToList();
            await Clients.Client(userId).ReloadNotifies(ret);
        }

        public async Task GetUsersList()
        {
            string userId = this.GetCallerId();
            await Clients.Client(userId).ReloadUserList(users);
        }

        public async Task ReadNotify(long seq)
        {
            string userId = this.GetCallerId();
            var msg = notifies.FirstOrDefault(o => o.Seq == seq);
            if (msg == null)
            {
                return;
            }
            msg.IsRead = true;
            await SendRead(msg);
        }

        public async Task SendRead(Notify msg)
        {
            await Clients.Client(msg.FromUser.SignalRId).ReadByUser(msg.Seq);
        }

        public async Task GetNotifies()
        {
            var id = this.GetCallerId();
            
            await this.SendNotifiesToUser(id);
        }

        public List<Notify> PushNotify(string toId, string msg)
        {
            return notifies.Where(o => o.ToUser.SignalRId == this.GetCallerId()).ToList();
        }

        public async Task SendChangeUsers()
        {
            await Clients.All.GetChangeUser();
        }


    }
    
}