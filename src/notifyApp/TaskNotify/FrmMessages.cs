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

        #region member
        public List<UserInfo> users = new List<UserInfo>();

        public Dictionary<string, TextBox> MessageBoxs = new Dictionary<string, TextBox>();

        #endregion

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
                this.hub.OnReadByUser += Hub_OnReadByUser;
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
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

        private void Hub_OnReadByUser(object sender, HubProxyWrapper.HubProxyOnArgs<long> e)
        {
            //throw new NotImplementedException();
        }

        private void Hub_OnReloadUserList(object sender, HubProxyWrapper.HubProxyOnArgs<List<UserInfo>> e)
        {
            this.users = e.Arg;
            Invoke((MethodInvoker)(() =>
            {
                this.niTask.BalloonTipIcon = ToolTipIcon.Info;
                this.niTask.BalloonTipTitle = "ChangeUsers";
                this.lstmember.Items.Clear();
                if (this.users.Count > 0)
                {
                    this.lstmember.ValueMember = "UserCd";
                    this.lstmember.DisplayMember = "Name";
                    this.lstmember.Items.AddRange(this.users.Select(o => new { o.UserCd, o.Name }).ToArray());
                    this.btnSendMessage.Enabled = true;
                }
                else
                {
                    this.btnSendMessage.Enabled = false;
                }
            }));
        }
        private string FormatNofity(Notify o)
        {
            return string.Format("From[{0}]:{1}\r\n", o.FromUser.Name, o.Message);
        }
        private void Hub_OnReloadNotifies(object sender, HubProxyWrapper.HubProxyOnArgs<List<Notify>> e)
        {
            var lst = e.Arg;
            this.niTask.BalloonTipIcon = ToolTipIcon.Info;
            this.niTask.BalloonTipTitle = "Notify";
            if (lst.Count > 0)
            {
                string rev = string.Join("", lst.Select(o => FormatNofity(o)).ToArray());
                Invoke((MethodInvoker)(() =>
                {
                    this.lblReceive.Text += rev;
                    this.AddTabsByMessage(lst);
                    lst.ForEach(o => this.hub.ReadNotify(o.Seq));
                    if (!this.Visible)
                    {
                        this.niTask.BalloonTipText = lst[0].Message;
                        this.niTask.ShowBalloonTip(1000);
                    }
                }));
            }
            else
            {
                //this.lblReceive.Text = "";
                if (!this.Visible)
                {
                    this.niTask.BalloonTipText = "新着情報はありません。";
                    this.niTask.ShowBalloonTip(1000);
                }
            }

        }

        private void AddTabsByMessage(List<Notify> lst)
        {
            foreach(var n in lst)
            {
                AddTabByMessage(n);
            }
        }

        private void AddTabByMessage(Notify notify)
        {
            var user = this.users.FirstOrDefault(o => o.UserCd == notify.FromUser.UserCd);
            if (user == null)
            {
                return;
            }

            if (!this.MessageBoxs.ContainsKey(notify.FromUser.UserCd))
            {
                this.AddTab(user);
            }
            var msgbox = this.MessageBoxs[user.UserCd];
            msgbox.Text += FormatNofity(notify);
            this.tabmessages.SelectedTab = ((TabPage)(msgbox.Parent));

        }
        #endregion Hub event

        #region Form event

        private void FrmMessages_Load(object sender, EventArgs e)
        {
            Hide();
            ExCommon.Logging += ExCommon_logging;
            this.WriteTrace("Loaded");
            this.Join();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstmember.SelectedItem == null) { return; }
                string userCd = ((dynamic)this.lstmember.SelectedItem).UserCd;
                if (userCd == null) { return; }
                await this.hub.SendMessage(userCd, this.txtSendMsg.Text);
                this.lblReceive.Text += string.Format("\r\nTo[{0}]{1}\r\n", userCd, this.txtSendMsg.Text);
                this.txtSendMsg.Text = "";
                this.txtSendMsg.Focus();
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
            }
        }

        private void FrmMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            this.txtSyslog.Text = "";
        }

        private void btnFntdlg_Click(object sender, EventArgs e)
        {
            DialogResult ret = fntdlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                this.Font = fntdlg.Font;
            }

        }

        private void tabmessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = this.tabmessages.SelectedTab.Tag as UserInfo;
            if (user == null)
            {
                this.lstmember.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i < this.lstmember.Items.Count; i++)
                {
                    if (((dynamic)this.lstmember.Items[i]).UserCd == user.UserCd)
                    {
                        this.lstmember.SelectedIndex = i;
                        break;
                    }
                }
            }
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
            this.Reconnect();
        }

        private void Reconnect()
        {
            this.WriteTrace("再接続します...");
            this.LeaveChat();
            this.Disconnect();
            this.Connect();
            this.Join();
            this.WriteTrace("再接続しました");

        }

        private void LeaveChat()
        {
            this.hub.Leave(Properties.Settings.Default.UserCd);
        }

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMsgForm();
        }

        private void 切断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Disconnect();
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

        private void AddTab(UserInfo user)
        {
            var tab = new TabPage();
            tab.Controls.Add(this.GetMsgTextBox(user.UserCd));
            tab.Location = new System.Drawing.Point(4, 22);
            tab.Name = "tabPage_"+user.UserCd;
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(628, 298);
            //tab.TabIndex = maxNo + 1;
            tab.Text = user.Name;
            tab.UseVisualStyleBackColor = true;
            tab.Tag = user;
            this.tabmessages.TabPages.Add(tab);
        }

        private TextBox GetMsgTextBox(string cd)
        {
            var txt = new TextBox();
            txt.Dock = System.Windows.Forms.DockStyle.Fill;
            txt.Location = new System.Drawing.Point(3, 3);
            txt.Multiline = true;
            txt.Name = "txtlog_"+ cd;
            txt.ReadOnly = true;
            txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txt.Size = new System.Drawing.Size(622, 292);
            txt.TabIndex = 0;
            txt.TabStop = false;
            MessageBoxs[cd] = txt;
            return txt;
        }

        private void Disconnect()
        {
            this.LeaveChat();
            this.hub.Disconnect();
        }

        private void Connect()
        {
            this.hub.Connect();
        }
        #endregion Helper

    }
}
