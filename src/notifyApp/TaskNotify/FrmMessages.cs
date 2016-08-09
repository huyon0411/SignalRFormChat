using Entities;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskNotify.Common;
using static Entities.HubNotifyArgs;

namespace TaskNotify
{
    public partial class FrmMessages : Form
    {
        public NotifyHub hub = null;
        string hubName = "NotifyHub";

        public static SignalrSelfHost svr = null;

        ///// <summary>
        ///// フォームのCreateParamsプロパティをオーバーライドする
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    [System.Security.Permissions.SecurityPermission(
        //        System.Security.Permissions.SecurityAction.LinkDemand,
        //        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        //    get
        //    {
        //        const int WS_EX_TOOLWINDOW = 0x80;
        //        const long WS_POPUP = 0x80000000L;
        //        const int WS_VISIBLE = 0x10000000;
        //        const int WS_SYSMENU = 0x80000;
        //        const int WS_MAXIMIZEBOX = 0x10000;

        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle = WS_EX_TOOLWINDOW;
        //        cp.Style = unchecked((int)WS_POPUP) |
        //            WS_VISIBLE | WS_SYSMENU | WS_MAXIMIZEBOX;
        //        cp.Width = 0;
        //        cp.Height = 0;

        //        return cp;
        //    }
        //}
        #region MyRegion

        public FrmMessages()
        {
            InitializeComponent();

            if (Properties.Settings.Default.IsServer)
            {
                svr = new SignalrSelfHost();
                svr.Start();
            }

            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.hub = new NotifyHub(Properties.Settings.Default.ServerUrl, hubName);
            this.hub.OnReloadNotifies += Hub_OnReloadNotifies;
            this.hub.OnReloadUserList += Hub_OnReloadUserList;
            this.Join();
        }

        private void Hub_OnReloadUserList(object sender, NotifyHub.ReloadArgs<UserInfo> e)
        {
            var lst = e.lst;
            this.niTask.BalloonTipIcon = ToolTipIcon.Info;
            this.niTask.BalloonTipTitle = "ChangeUsers";
                Invoke((MethodInvoker)(() =>
                {
                    if (lst.Count > 0)
                    {
                        this.lstmember.ValueMember = "UserCd";
                        this.lstmember.DisplayMember = "Name";
                        this.lstmember.Items.AddRange(lst.Select(o => new { o.UserCd, o.Name }).ToArray());
                        //this.lstmember.DisplayMember = "Name";
                        this.button1.Enabled = true;
                    }
                    else
                    {
                        this.button1.Enabled = false;
                    }
                }));
        }

        private void Hub_OnReloadNotifies(object sender, NotifyHub.ReloadNotifiesArgs e)
        {
            var lst = e.lst;
            this.niTask.BalloonTipIcon = ToolTipIcon.Info;
            this.niTask.BalloonTipTitle = "Notify";
            if (lst.Count > 0)
            {
                string rev = string.Join("\n", lst.Select(o => string.Format("{0} :{1}", o.FromCd, o.Message)).ToArray());
                Invoke((MethodInvoker)(()=>
                {
                    this.lblReceive.Text = rev;
                    this.niTask.BalloonTipText = lst[0].Message;
                    this.niTask.ShowBalloonTip(1000);
                }));
            }
            else
            {
                this.lblReceive.Text = "";
                this.niTask.BalloonTipText = "新着情報はありません。";
                this.niTask.ShowBalloonTip(1000);
            }

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.niTask.Visible = false;
            Application.Exit();
        }

        private void FrmMessages_Load(object sender, EventArgs e)
        {
            Hide();

        }

        #endregion

        private void 確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hub.GetNotifies();
        }

        private void 再接続ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Join();
        }

        private Task Join()
        {
            return this.hub.Join(Properties.Settings.Default.UserCd, Properties.Settings.Default.UserName);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await this.hub.SendMessage(((dynamic)this.lstmember.SelectedItem).UserCd, this.textBox1.Text);
            this.textBox1.Text = "";
        }

        private void niTask_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
            this.ShowInTaskbar = true;
        }

        private void FrmMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }
    }

    public class NotifyHub : HubProxyWrapper
    {
        public class ReloadArgs<T> : EventArgs
        {
            public List<T> lst { get; set; }
        }

        public class ReloadNotifiesArgs : EventArgs
        {
            public List<Notify> lst { get; set; }
        }
        public event EventHandler<ReloadNotifiesArgs> OnReloadNotifies;
        public event EventHandler<ReloadArgs<UserInfo>> OnReloadUserList;
        public NotifyHub(string url, string hubName) : base(url, hubName) { }
        public NotifyHub(HubConnection conn, string hubName) : base(conn, hubName) { }

        public override void RegistServerMethod()
        {
            this.On<List<Notify>>(this.ReloadNotifies);
            this.On<List<UserInfo>>(this.ReloadUserList);
        }

        private void ReloadUserList(List<UserInfo> obj)
        {
            OnReloadUserList(this, new ReloadArgs<UserInfo>() { lst = obj });
        }

        public void ReloadNotifies(List<Notify> a)
        {
            OnReloadNotifies(this, new ReloadNotifiesArgs() { lst = a });
        }
        public void GetNotifies()
        {
            this.Invoke();
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

    }
}
