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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.再接続ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切断ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.確認ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tabmessages = new System.Windows.Forms.TabControl();
            this.tpSendLst = new System.Windows.Forms.TabPage();
            this.lstmember = new System.Windows.Forms.ListBox();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.tpSyslog = new System.Windows.Forms.TabPage();
            this.txtSyslog = new System.Windows.Forms.TextBox();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsMessage = new System.Windows.Forms.BindingSource(this.components);
            this.btnFntdlg = new System.Windows.Forms.Button();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.fntdlg = new System.Windows.Forms.FontDialog();
            this.cmsTasks.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tabmessages.SuspendLayout();
            this.tpSendLst.SuspendLayout();
            this.tpSyslog.SuspendLayout();
            this.tpConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMessage)).BeginInit();
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
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.表示ToolStripMenuItem,
            this.toolStripSeparator1,
            this.確認ToolStripMenuItem});
            this.cmsTasks.Name = "cmsTasks";
            this.cmsTasks.Size = new System.Drawing.Size(123, 110);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.再接続ToolStripMenuItem,
            this.切断ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "Connect";
            // 
            // 再接続ToolStripMenuItem
            // 
            this.再接続ToolStripMenuItem.Name = "再接続ToolStripMenuItem";
            this.再接続ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.再接続ToolStripMenuItem.Text = "再接続";
            this.再接続ToolStripMenuItem.Click += new System.EventHandler(this.再接続ToolStripMenuItem_Click);
            // 
            // 切断ToolStripMenuItem
            // 
            this.切断ToolStripMenuItem.Name = "切断ToolStripMenuItem";
            this.切断ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.切断ToolStripMenuItem.Text = "切断";
            this.切断ToolStripMenuItem.Click += new System.EventHandler(this.切断ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.表示ToolStripMenuItem.Text = "画面表示";
            this.表示ToolStripMenuItem.Click += new System.EventHandler(this.表示ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // 確認ToolStripMenuItem
            // 
            this.確認ToolStripMenuItem.Name = "確認ToolStripMenuItem";
            this.確認ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.確認ToolStripMenuItem.Text = "確認";
            this.確認ToolStripMenuItem.Click += new System.EventHandler(this.確認ToolStripMenuItem_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(0, 617);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(778, 54);
            this.btnSendMessage.TabIndex = 200;
            this.btnSendMessage.Text = "送信";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpMain);
            this.tabControl1.Controls.Add(this.tpSyslog);
            this.tabControl1.Controls.Add(this.tpConfig);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 610);
            this.tabControl1.TabIndex = 5;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tabmessages);
            this.tpMain.Controls.Add(this.txtSendMsg);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(770, 584);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "main";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tabmessages
            // 
            this.tabmessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabmessages.Controls.Add(this.tpSendLst);
            this.tabmessages.Location = new System.Drawing.Point(3, 3);
            this.tabmessages.Name = "tabmessages";
            this.tabmessages.SelectedIndex = 0;
            this.tabmessages.Size = new System.Drawing.Size(764, 468);
            this.tabmessages.TabIndex = 7;
            this.tabmessages.TabStop = false;
            this.tabmessages.SelectedIndexChanged += new System.EventHandler(this.tabmessages_SelectedIndexChanged);
            // 
            // tpSendLst
            // 
            this.tpSendLst.Controls.Add(this.lstmember);
            this.tpSendLst.Location = new System.Drawing.Point(4, 22);
            this.tpSendLst.Name = "tpSendLst";
            this.tpSendLst.Padding = new System.Windows.Forms.Padding(3);
            this.tpSendLst.Size = new System.Drawing.Size(756, 442);
            this.tpSendLst.TabIndex = 0;
            this.tpSendLst.Text = "send";
            this.tpSendLst.UseVisualStyleBackColor = true;
            // 
            // lstmember
            // 
            this.lstmember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstmember.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstmember.ItemHeight = 23;
            this.lstmember.Location = new System.Drawing.Point(3, 3);
            this.lstmember.Name = "lstmember";
            this.lstmember.ScrollAlwaysVisible = true;
            this.lstmember.Size = new System.Drawing.Size(750, 436);
            this.lstmember.TabIndex = 2;
            this.lstmember.TabStop = false;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendMsg.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSendMsg.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSendMsg.Location = new System.Drawing.Point(3, 474);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(764, 107);
            this.txtSendMsg.TabIndex = 100;
            // 
            // tpSyslog
            // 
            this.tpSyslog.Controls.Add(this.txtSyslog);
            this.tpSyslog.Location = new System.Drawing.Point(4, 22);
            this.tpSyslog.Name = "tpSyslog";
            this.tpSyslog.Padding = new System.Windows.Forms.Padding(3);
            this.tpSyslog.Size = new System.Drawing.Size(770, 584);
            this.tpSyslog.TabIndex = 1;
            this.tpSyslog.Text = "syslog";
            this.tpSyslog.UseVisualStyleBackColor = true;
            // 
            // txtSyslog
            // 
            this.txtSyslog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSyslog.Location = new System.Drawing.Point(3, 3);
            this.txtSyslog.Multiline = true;
            this.txtSyslog.Name = "txtSyslog";
            this.txtSyslog.ReadOnly = true;
            this.txtSyslog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSyslog.Size = new System.Drawing.Size(764, 578);
            this.txtSyslog.TabIndex = 0;
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.dataGridView1);
            this.tpConfig.Controls.Add(this.btnFntdlg);
            this.tpConfig.Controls.Add(this.btnLogClear);
            this.tpConfig.Location = new System.Drawing.Point(4, 22);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfig.Size = new System.Drawing.Size(770, 584);
            this.tpConfig.TabIndex = 2;
            this.tpConfig.Text = "config";
            this.tpConfig.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seqDataGridViewTextBoxColumn,
            this.toUserDataGridViewTextBoxColumn,
            this.fromUserDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.isReadDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.bsMessage;
            this.dataGridView1.Location = new System.Drawing.Point(8, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(383, 147);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.Visible = false;
            // 
            // seqDataGridViewTextBoxColumn
            // 
            this.seqDataGridViewTextBoxColumn.DataPropertyName = "Seq";
            this.seqDataGridViewTextBoxColumn.HeaderText = "Seq";
            this.seqDataGridViewTextBoxColumn.Name = "seqDataGridViewTextBoxColumn";
            this.seqDataGridViewTextBoxColumn.ReadOnly = true;
            this.seqDataGridViewTextBoxColumn.Width = 40;
            // 
            // toUserDataGridViewTextBoxColumn
            // 
            this.toUserDataGridViewTextBoxColumn.DataPropertyName = "ToUser";
            this.toUserDataGridViewTextBoxColumn.HeaderText = "ToUser";
            this.toUserDataGridViewTextBoxColumn.Name = "toUserDataGridViewTextBoxColumn";
            this.toUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.toUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // fromUserDataGridViewTextBoxColumn
            // 
            this.fromUserDataGridViewTextBoxColumn.DataPropertyName = "FromUser";
            this.fromUserDataGridViewTextBoxColumn.HeaderText = "FromUser";
            this.fromUserDataGridViewTextBoxColumn.Name = "fromUserDataGridViewTextBoxColumn";
            this.fromUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            this.messageDataGridViewTextBoxColumn.Width = 300;
            // 
            // isReadDataGridViewCheckBoxColumn
            // 
            this.isReadDataGridViewCheckBoxColumn.DataPropertyName = "IsRead";
            this.isReadDataGridViewCheckBoxColumn.HeaderText = "IsRead";
            this.isReadDataGridViewCheckBoxColumn.Name = "isReadDataGridViewCheckBoxColumn";
            this.isReadDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isReadDataGridViewCheckBoxColumn.Visible = false;
            // 
            // bsMessage
            // 
            this.bsMessage.DataSource = typeof(Entities.Notify);
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
            // FrmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSendMessage);
            this.Name = "FrmMessages";
            this.Text = "＊";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessages_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessages_Load);
            this.cmsTasks.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.tabmessages.ResumeLayout(false);
            this.tpSendLst.ResumeLayout(false);
            this.tpSyslog.ResumeLayout(false);
            this.tpSyslog.PerformLayout();
            this.tpConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niTask;
        private System.Windows.Forms.ContextMenuStrip cmsTasks;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 確認ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再接続ToolStripMenuItem;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.ListBox lstmember;
        private System.Windows.Forms.TabPage tpSyslog;
        private System.Windows.Forms.TextBox txtSyslog;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.Button btnLogClear;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.TabControl tabmessages;
        private System.Windows.Forms.TabPage tpSendLst;
        private System.Windows.Forms.Button btnFntdlg;
        private System.Windows.Forms.FontDialog fntdlg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 切断ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn seqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadDataGridViewCheckBoxColumn;
    }
}

