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

        public class TabMembers
        {
            public List<Notify> Messages  = new List<Notify>();
            public BindingSource BsMsg = new BindingSource();
            public List<Notify> MessageSend = new List<Notify>();
            public BindingSource BsSend = new BindingSource();
            public TabMembers()
            {
                this.BsMsg.DataSource = this.Messages;
                this.BsSend.DataSource = this.MessageSend;
            }
        }

        #region member
        public NotifyHubProxy hub = null;
        public SignalrSelfHost svr = null;
        public List<UserInfo> users = new List<UserInfo>();
        public Dictionary<string, TabMembers> MsgDic = new Dictionary<string, TabMembers>();

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
                this.hub.OnSendSuccess += Hub_OnSendSuccess;
            }
            catch (Exception ex)
            {
                ex.WriteExcept();
            }
        }

        #endregion

        #region Hub event

        private void ExCommon_logging(object sender, EventArgs e)
        {
            DoUI(() => {
                this.txtSyslog.Text += ExCommon.Buffer.ToString();
                this.txtSyslog.Text += "\n";
                ExCommon.Buffer.Clear();
            });
        }


        private void Hub_OnSendSuccess(object sender, HubProxyWrapper.HubProxyOnArgs<Notify> e)
        {
            var toCd = e.Arg.ToUser.UserCd;
            if (!this.MsgDic.ContainsKey(toCd))
            {
                this.MsgDic[toCd] = new TabMembers();
                this.AddTab(e.Arg.ToUser);
            }
            var msg = MsgDic[toCd];
            msg.MessageSend.Add(e.Arg);
            DoUI(() =>
            {
                msg.BsSend.ResetBindings(false);
                this.SelectTab(toCd);
            });
        }

        private void Hub_OnReadByUser(object sender, HubProxyWrapper.HubProxyOnArgs<long> e)
        {
            
            var msgObj = MsgDic.Values.FirstOrDefault(msgDat => msgDat.MessageSend.Any(o => o.Seq == e.Arg));
            if (msgObj != null)
            {
                Notify msgRead = msgObj.MessageSend.FirstOrDefault(o => o.Seq == e.Arg);
                msgRead.IsRead = true;
                DoUI(() => msgObj.BsSend.ResetBindings(false));
            }
        }

        private void DoUI(Action act)
        {
            Invoke(act);
            //Invoke((MethodInvoker)(() => act()));
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
                lst.ForEach(async o => await this.hub.ReadNotify(o.Seq));
                Invoke((MethodInvoker)(() =>
                {
                    this.AddTabsByMessage(lst);
                    if (!this.Visible)
                    {
                        this.niTask.BalloonTipText = lst[0].Message;
                        if (string.IsNullOrEmpty(this.niTask.BalloonTipText))
                        {
                            this.niTask.BalloonTipText = " ";
                        }
                        this.niTask.ShowBalloonTip(1000);
                    }
                }));
            }
            else
            {
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

            if (!this.MsgDic.ContainsKey(user.UserCd))
            {
                MsgDic[user.UserCd] = new TabMembers();
                this.AddTab(user);
            }
            var msg = MsgDic[user.UserCd];
            msg.Messages.Add(notify);
            msg.BsMsg.ResetBindings(false);

            this.SelectTab(user.UserCd);
        }

        private void SelectTab(string cd)
        {
            
            foreach(TabPage tab in this.tabmessages.TabPages)
            {
                var user = tab.Tag as UserInfo;
                if (user == null) { continue; }
                if (user.UserCd == cd)
                {
                    this.tabmessages.SelectedTab = tab;
                    break;
                }
            }
        }

        #endregion Hub event

        #region Form event

        private async void FrmMessages_Load(object sender, EventArgs e)
        {
            Hide();
            ExCommon.Logging += ExCommon_logging;
            this.WriteTrace("Loaded");
            await this.Join();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                var sendUsr = this.tabmessages.SelectedTab.Tag as UserInfo;
                
                if (sendUsr == null && this.lstmember.SelectedItem == null) { return; }

                string userCd = null;
                if (sendUsr != null)
                {
                    userCd = sendUsr.UserCd;
                }else
                {
                    userCd = ((dynamic)this.lstmember.SelectedItem).UserCd;
                }
                if (userCd == null) { return; }
                //this.OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing,false));
                await this.hub.SendMessage(userCd, this.txtSendMsg.Text);
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
            this.hub.GetNotifies().ConfigureAwait(false);
        }

        private async void 再接続ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await this.Reconnect();
        }

        private async Task Reconnect()
        {
            this.WriteTrace("再接続します...");
            await this.LeaveChat();
            await this.Disconnect();
            this.Connect();
            await this.Join();
            this.WriteTrace("再接続しました");

        }

        private async Task LeaveChat()
        {
            await this.hub.Leave(Properties.Settings.Default.UserCd);
        }

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMsgForm();
        }

        private async void 切断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await this.Disconnect();
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

        private async Task Join()
        {
            await this.hub.Join(Properties.Settings.Default.UserCd, Properties.Settings.Default.UserName);
        }

        private void AddTab(UserInfo user)
        {
            var tab = new TabPage();
            var grd = this.GetGrid(user.UserCd);
            var grdSend = this.GetSendGrid(user.UserCd);
            var spc = this.GetSplitContainer(user.UserCd, grdSend, grd);
            tab.Controls.Add(spc);
            
            tab.Location = new System.Drawing.Point(4, 22);
            tab.Name = "tabPage_"+user.UserCd;
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(628, 298);
            tab.Text = user.Name;
            tab.UseVisualStyleBackColor = true;
            tab.Tag = user;
            DoUI(()=> this.tabmessages.TabPages.Add(tab));
        }

        private DataGridView GetGrid(string cd)
        {
            var grd = new DataGridView();
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AutoGenerateColumns = false;
            grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                ((DataGridViewColumn)this.seqDataGridViewTextBoxColumn.Clone()),
                ((DataGridViewColumn)this.toUserDataGridViewTextBoxColumn.Clone()),
                ((DataGridViewColumn)this.fromUserDataGridViewTextBoxColumn.Clone()),
                ((DataGridViewColumn)this.messageDataGridViewTextBoxColumn.Clone()),
                ((DataGridViewColumn)this.isReadDataGridViewCheckBoxColumn.Clone())});
            grd.DataSource = this.MsgDic[cd].BsMsg;
            grd.Dock = System.Windows.Forms.DockStyle.Fill;
            grd.Location = new System.Drawing.Point(0, 0);
            grd.Name = "grdMsg_" + cd;
            grd.ReadOnly = true;
            grd.RowTemplate.Height = 21;
            grd.Size = new System.Drawing.Size(749, 150);
            grd.TabIndex = 8;
            grd.TabStop = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            return grd;
        }

        private DataGridView GetSendGrid(string cd)
        {
            var grd = new DataGridView();
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AutoGenerateColumns = false;
            grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            var fromCmn = ((DataGridViewColumn)this.fromUserDataGridViewTextBoxColumn.Clone());
            fromCmn.Visible = false;
            var toCmn = ((DataGridViewColumn)this.toUserDataGridViewTextBoxColumn.Clone());
            toCmn.Visible = false;
            var chkCmn = ((DataGridViewColumn)this.isReadDataGridViewCheckBoxColumn.Clone());
            chkCmn.Visible = true;
            grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                ((DataGridViewColumn)this.seqDataGridViewTextBoxColumn.Clone()),
                toCmn,
                fromCmn,
                ((DataGridViewColumn)this.messageDataGridViewTextBoxColumn.Clone()),
                chkCmn });
            grd.DataSource = this.MsgDic[cd].BsSend;
            grd.Dock = System.Windows.Forms.DockStyle.Fill;
            grd.Location = new System.Drawing.Point(3, 213);
            grd.Name = "grdMsgsend_" + cd;
            grd.ReadOnly = true;
            grd.RowTemplate.Height = 21;
            grd.Size = new System.Drawing.Size(749, 150);
            grd.TabIndex = 8;
            grd.TabStop = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            return grd;
        }
        private SplitContainer GetSplitContainer(string cd, DataGridView sendGrid, DataGridView msgGrid)
        {
            var spc = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(spc)).BeginInit();
            spc.Panel1.SuspendLayout();
            spc.Panel2.SuspendLayout();
            spc.SuspendLayout();

            spc.Dock = System.Windows.Forms.DockStyle.Fill;
            spc.Location = new System.Drawing.Point(3, 3);
            spc.Name = "spcMsg_" + cd;
            spc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            spc.Panel1.Controls.Add(msgGrid);
            spc.Panel2.Controls.Add(sendGrid);
            spc.Size = new System.Drawing.Size(750, 436);
            spc.SplitterDistance = 218;
            spc.TabIndex = 109;
            //spc.TabStop = false;
            spc.Panel1.ResumeLayout(false);
            spc.Panel1.PerformLayout();
            spc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(spc)).EndInit();
            spc.ResumeLayout(false);

            return spc;
        }
        private async Task Disconnect()
        {
            await this.LeaveChat();
            this.hub.Disconnect();
        }

        private void Connect()
        {
            this.hub.Connect();
        }
        #endregion Helper

    }
}
