namespace Skype_to_Growl_Notification
{
    partial class FormSetting
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttachSkype = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRegisterGrowl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTestNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSendTestMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGetAttachmentStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripRightClick;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Visible = true;
            // 
            // contextMenuStripRightClick
            // 
            this.contextMenuStripRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenSetting,
            this.toolStripMenuItemCommands,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.contextMenuStripRightClick.Name = "contextMenuStripRightClick";
            this.contextMenuStripRightClick.Size = new System.Drawing.Size(161, 98);
            // 
            // toolStripMenuItemOpenSetting
            // 
            this.toolStripMenuItemOpenSetting.Name = "toolStripMenuItemOpenSetting";
            this.toolStripMenuItemOpenSetting.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemOpenSetting.Text = "設定画面を表示";
            this.toolStripMenuItemOpenSetting.Click += new System.EventHandler(this.toolStripMenuItemOpenSetting_Click);
            // 
            // toolStripMenuItemCommands
            // 
            this.toolStripMenuItemCommands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAttachSkype,
            this.toolStripMenuItemGetAttachmentStatus,
            this.toolStripSeparator3,
            this.toolStripMenuItemRegisterGrowl,
            this.toolStripMenuItemTestNotification});
            this.toolStripMenuItemCommands.Name = "toolStripMenuItemCommands";
            this.toolStripMenuItemCommands.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemCommands.Text = "コマンド";
            // 
            // toolStripMenuItemAttachSkype
            // 
            this.toolStripMenuItemAttachSkype.Name = "toolStripMenuItemAttachSkype";
            this.toolStripMenuItemAttachSkype.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemAttachSkype.Text = "Skypeへ接続";
            this.toolStripMenuItemAttachSkype.Click += new System.EventHandler(this.toolStripMenuItemAttachSkype_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItemRegisterGrowl
            // 
            this.toolStripMenuItemRegisterGrowl.Name = "toolStripMenuItemRegisterGrowl";
            this.toolStripMenuItemRegisterGrowl.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemRegisterGrowl.Text = "Growlへ登録";
            this.toolStripMenuItemRegisterGrowl.Click += new System.EventHandler(this.toolStripMenuItemRegisterGrowl_Click);
            // 
            // toolStripMenuItemTestNotification
            // 
            this.toolStripMenuItemTestNotification.Name = "toolStripMenuItemTestNotification";
            this.toolStripMenuItemTestNotification.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemTestNotification.Text = "テスト通知の送信";
            this.toolStripMenuItemTestNotification.Click += new System.EventHandler(this.toolStripMenuItemTestNotification_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemExit.Text = "終了 (&X)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItemSendTestMessage
            // 
            this.toolStripMenuItemSendTestMessage.Name = "toolStripMenuItemSendTestMessage";
            this.toolStripMenuItemSendTestMessage.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemSendTestMessage.Text = "テスト通知を送信";
            // 
            // toolStripMenuItemGetAttachmentStatus
            // 
            this.toolStripMenuItemGetAttachmentStatus.Name = "toolStripMenuItemGetAttachmentStatus";
            this.toolStripMenuItemGetAttachmentStatus.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemGetAttachmentStatus.Text = "接続状況の確認";
            this.toolStripMenuItemGetAttachmentStatus.Click += new System.EventHandler(this.toolStripMenuItemGetAttachmentStatus_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormSetting";
            this.Text = "設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.contextMenuStripRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCommands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSendTestMessage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttachSkype;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegisterGrowl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTestNotification;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGetAttachmentStatus;
    }
}

