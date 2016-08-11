namespace TaskNotify
{
    partial class FrmMessages
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessages));
            this.niTask = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再接続ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.lstmember = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSyslog = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.tabmessages = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblReceive = new System.Windows.Forms.TextBox();
            this.fntdlg = new System.Windows.Forms.FontDialog();
            this.btnFntdlg = new System.Windows.Forms.Button();
            this.cmsTasks.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabmessages.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // niTask
            // 
            this.niTask.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.niTask.ContextMenuStrip = this.cmsTasks;
            this.niTask.Icon = ((System.Drawing.Icon)(resources.GetObject("niTask.Icon")));
            this.niTask.Text = "notifyIcon1";
            this.niTask.Visible = true;
            this.niTask.BalloonTipClicked += new System.EventHandler(this.niTask_BalloonTipClicked);
            this.niTask.DoubleClick += new System.EventHandler(this.niTask_DoubleClick);
            // 
            // cmsTasks
            // 
            this.cmsTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.確認ToolStripMenuItem,
            this.再接続ToolStripMenuItem,
            this.表示ToolStripMenuItem});
            this.cmsTasks.Name = "cmsTasks";
            this.cmsTasks.Size = new System.Drawing.Size(111, 92);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 確認ToolStripMenuItem
            // 
            this.確認ToolStripMenuItem.Name = "確認ToolStripMenuItem";
            this.確認ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.確認ToolStripMenuItem.Text = "確認";
            this.確認ToolStripMenuItem.Click += new System.EventHandler(this.確認ToolStripMenuItem_Click);
            // 
            // 再接続ToolStripMenuItem
            // 
            this.再接続ToolStripMenuItem.Name = "再接続ToolStripMenuItem";
            this.再接続ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.再接続ToolStripMenuItem.Text = "再接続";
            this.再接続ToolStripMenuItem.Click += new System.EventHandler(this.再接続ToolStripMenuItem_Click);
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.表示ToolStripMenuItem.Text = "表示";
            this.表示ToolStripMenuItem.Click += new System.EventHandler(this.表示ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(0, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(636, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 324);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabmessages);
            this.tabPage1.Controls.Add(this.txtSendMsg);
            this.tabPage1.Controls.Add(this.lstmember);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendMsg.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendMsg.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSendMsg.Location = new System.Drawing.Point(3, 188);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(622, 107);
            this.txtSendMsg.TabIndex = 5;
            // 
            // lstmember
            // 
            this.lstmember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstmember.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstmember.ItemHeight = 23;
            this.lstmember.Location = new System.Drawing.Point(3, 3);
            this.lstmember.Name = "lstmember";
            this.lstmember.ScrollAlwaysVisible = true;
            this.lstmember.Size = new System.Drawing.Size(622, 73);
            this.lstmember.TabIndex = 2;
            this.lstmember.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtSyslog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "syslog";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSyslog
            // 
            this.txtSyslog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSyslog.Location = new System.Drawing.Point(3, 3);
            this.txtSyslog.Multiline = true;
            this.txtSyslog.Name = "txtSyslog";
            this.txtSyslog.ReadOnly = true;
            this.txtSyslog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSyslog.Size = new System.Drawing.Size(622, 292);
            this.txtSyslog.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnFntdlg);
            this.tabPage3.Controls.Add(this.btnLogClear);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(628, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnLogClear
            // 
            this.btnLogClear.Location = new System.Drawing.Point(6, 6);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(96, 35);
            this.btnLogClear.TabIndex = 0;
            this.btnLogClear.Text = "Clear syslog";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // tabmessages
            // 
            this.tabmessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabmessages.Controls.Add(this.tabPage4);
            this.tabmessages.Location = new System.Drawing.Point(0, 76);
            this.tabmessages.Name = "tabmessages";
            this.tabmessages.SelectedIndex = 0;
            this.tabmessages.Size = new System.Drawing.Size(621, 106);
            this.tabmessages.TabIndex = 7;
            this.tabmessages.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lblReceive);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(613, 80);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "all";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblReceive
            // 
            this.lblReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceive.Location = new System.Drawing.Point(3, 3);
            this.lblReceive.Multiline = true;
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lblReceive.Size = new System.Drawing.Size(607, 74);
            this.lblReceive.TabIndex = 7;
            this.lblReceive.TabStop = false;
            // 
            // btnFntdlg
            // 
            this.btnFntdlg.Location = new System.Drawing.Point(8, 47);
            this.btnFntdlg.Name = "btnFntdlg";
            this.btnFntdlg.Size = new System.Drawing.Size(96, 35);
            this.btnFntdlg.TabIndex = 1;
            this.btnFntdlg.Text = "font setting";
            this.btnFntdlg.UseVisualStyleBackColor = true;
            this.btnFntdlg.Click += new System.EventHandler(this.btnFntdlg_Click);
            // 
            // FrmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 387);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "FrmMessages";
            this.Text = "＊";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessages_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessages_Load);
            this.cmsTasks.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabmessages.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niTask;
        private System.Windows.Forms.ContextMenuStrip cmsTasks;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 確認ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再接続ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstmember;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSyslog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnLogClear;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.TabControl tabmessages;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox lblReceive;
        private System.Windows.Forms.Button btnFntdlg;
        private System.Windows.Forms.FontDialog fntdlg;
    }
}

