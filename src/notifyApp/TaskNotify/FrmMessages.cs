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
using TaskNotify.HubProxy;
using static Entities.HubNotifyArgs;

namespace TaskNotify
{
    public partial class FrmMessages : Form
    {
        public NotifyHubProxy hub = null;

        public SignalrSelfHost svr = null;

        #region Constructor

        public FrmMessages()
        {
            InitializeComponent();
            try
            {
                if (Properties.Settings.Default.IsServer)
                {
                    svr = new SignalrSelfHost();
                    svr.Start();
                }

                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;

                this.hub = new NotifyHubProxy(Properties.Settings.Default.ServerUrl, NotifyHubProxy.HubName);
                this.hub.OnReloadNotifies += Hub_OnReloadNotifies;
                this.hub.OnReloadUserList += Hub_OnReloadUserList;

                this.Join();
            }
            catch (Exception e)
            {
                this.dp(LogUtil.GetExceptionLogStr(e));
            }
        }

        private void ExCommon_logging(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)(()=>{
                this.txtSyslog.Text += ExCommon.Buffer.ToString();
                this.txtSyslog.Text += "\n";
                ExCommon.Buffer.Clear();
            }));
        }

        #endregion

        #region Hub event

        private void Hub_OnReloadUserList(object sender, HubProxyWrapper.HubProxyOnArgs<List<UserInfo>> e)
        {
            var lst = e.Arg;
            Invoke((MethodInvoker)(() =>
            {
                this.niTask.BalloonTipIcon = ToolTipIcon.Info;
                this.niTask.BalloonTipTitle = "ChangeUsers";
                this.lstmember.Items.Clear();
                if (lst.Count > 0)
                {
                    this.lstmember.ValueMember = "UserCd";
                    this.lstmember.DisplayMember = "Name";
                    this.lstmember.Items.AddRange(lst.Select(o => new { o.UserCd, o.Name }).ToArray());
                    this.button1.Enabled = true;
                }
                else
                {
                    this.button1.Enabled = false;
                }
            }));
        }

        private void Hub_OnReloadNotifies(object sender, HubProxyWrapper.HubProxyOnArgs<List<Notify>> e)
        {
            var lst = e.Arg;
            this.niTask.BalloonTipIcon = ToolTipIcon.Info;
            this.niTask.BalloonTipTitle = "Notify";
            if (lst.Count > 0)
            {
                string rev = string.Join("\n", lst.Select(o => string.Format("{0} :{1}", o.FromCd, o.Message)).ToArray());
                Invoke((MethodInvoker)(() =>
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

        #endregion Hub event

        #region Form event

        private void FrmMessages_Load(object sender, EventArgs e)
        {
            Hide();
            ExCommon.Logging += ExCommon_logging;
            this.dp("Loaded");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstmember.SelectedItem == null) { return; }
                string userCd = ((dynamic)this.lstmember.SelectedItem).UserCd;
                if (userCd == null) { return; }
                await this.hub.SendMessage(userCd, this.textBox1.Text);
                this.textBox1.Text = "";
            }
            catch (Exception ex)
            {
                this.dp(LogUtil.GetExceptionLogStr(ex));
            }
        }

        private void FrmMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }

        #endregion Form event

        #region ToolStripMenu event

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.niTask.Visible = false;
            Application.Exit();
        }

        private void 確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hub.GetNotifies();
        }

        private void 再接続ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Join();
        }

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMsgForm();
        }

        private void niTask_BalloonTipClicked(object sender, EventArgs e)
        {
            this.ShowMsgForm();
        }

        private void niTask_DoubleClick(object sender, EventArgs e)
        {
            this.ShowMsgForm();
        }
        #endregion ToolStripMenu event

        #region Helper

        private void ShowMsgForm()
        {
            this.Show();
            this.Activate();
            this.ShowInTaskbar = true;
        }

        private Task Join()
        {
            return this.hub.Join(Properties.Settings.Default.UserCd, Properties.Settings.Default.UserName);
        }

        #endregion Helper

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            this.txtSyslog.Text = "";
        }
    }
}
