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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstmember = new System.Windows.Forms.ListBox();
            this.lblReceive = new System.Windows.Forms.Label();
            this.cmsTasks.SuspendLayout();
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
            // 
            // cmsTasks
            // 
            this.cmsTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.確認ToolStripMenuItem,
            this.再接続ToolStripMenuItem});
            this.cmsTasks.Name = "cmsTasks";
            this.cmsTasks.Size = new System.Drawing.Size(111, 70);
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox1.Location = new System.Drawing.Point(0, 240);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(636, 85);
            this.textBox1.TabIndex = 2;
            // 
            // lstmember
            // 
            this.lstmember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstmember.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstmember.ItemHeight = 23;
            this.lstmember.Location = new System.Drawing.Point(0, 1);
            this.lstmember.Name = "lstmember";
            this.lstmember.ScrollAlwaysVisible = true;
            this.lstmember.Size = new System.Drawing.Size(636, 96);
            this.lstmember.TabIndex = 1;
            // 
            // lblReceive
            // 
            this.lblReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceive.Location = new System.Drawing.Point(7, 102);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(618, 121);
            this.lblReceive.TabIndex = 4;
            this.lblReceive.Text = "label1";
            // 
            // FrmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 387);
            this.Controls.Add(this.lblReceive);
            this.Controls.Add(this.lstmember);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmMessages";
            this.Text = "＊";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessages_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessages_Load);
            this.cmsTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niTask;
        private System.Windows.Forms.ContextMenuStrip cmsTasks;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 確認ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再接続ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstmember;
        private System.Windows.Forms.Label lblReceive;
    }
}

