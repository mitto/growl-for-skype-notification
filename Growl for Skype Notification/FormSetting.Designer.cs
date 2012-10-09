namespace Growl_for_Skype_Notification
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
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemMonitoringSkype = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttachSkype = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGetAttachmentStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRegisterGrowl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTestNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSendTestMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlSetting = new System.Windows.Forms.TabControl();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.checkBoxStartupRegister = new System.Windows.Forms.CheckBox();
            this.buttonChangeLogPath = new System.Windows.Forms.Button();
            this.textBoxLogPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerSkypeStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripRightClick.SuspendLayout();
            this.tabControlSetting.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripRightClick;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseClick);
            // 
            // contextMenuStripRightClick
            // 
            this.contextMenuStripRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenSetting,
            this.toolStripSeparator4,
            this.toolStripMenuItemMonitoringSkype,
            this.toolStripMenuItemCommands,
            this.toolStripSeparator1,
            this.toolStripMenuItemCheckUpdate,
            this.toolStripMenuItemExit});
            this.contextMenuStripRightClick.Name = "contextMenuStripRightClick";
            this.contextMenuStripRightClick.Size = new System.Drawing.Size(197, 126);
            // 
            // toolStripMenuItemOpenSetting
            // 
            this.toolStripMenuItemOpenSetting.Name = "toolStripMenuItemOpenSetting";
            this.toolStripMenuItemOpenSetting.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemOpenSetting.Text = "設定画面を表示";
            this.toolStripMenuItemOpenSetting.Click += new System.EventHandler(this.toolStripMenuItemOpenSetting_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItemMonitoringSkype
            // 
            this.toolStripMenuItemMonitoringSkype.Checked = true;
            this.toolStripMenuItemMonitoringSkype.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemMonitoringSkype.Name = "toolStripMenuItemMonitoringSkype";
            this.toolStripMenuItemMonitoringSkype.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemMonitoringSkype.Text = "Skypeの状態を監視";
            this.toolStripMenuItemMonitoringSkype.Click += new System.EventHandler(this.toolStripMenuItemMonitoringSkype_Click);
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
            this.toolStripMenuItemCommands.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemCommands.Text = "コマンド";
            // 
            // toolStripMenuItemAttachSkype
            // 
            this.toolStripMenuItemAttachSkype.Name = "toolStripMenuItemAttachSkype";
            this.toolStripMenuItemAttachSkype.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemAttachSkype.Text = "Skypeへ接続";
            this.toolStripMenuItemAttachSkype.Click += new System.EventHandler(this.toolStripMenuItemAttachSkype_Click);
            // 
            // toolStripMenuItemGetAttachmentStatus
            // 
            this.toolStripMenuItemGetAttachmentStatus.Name = "toolStripMenuItemGetAttachmentStatus";
            this.toolStripMenuItemGetAttachmentStatus.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemGetAttachmentStatus.Text = "接続状況の確認";
            this.toolStripMenuItemGetAttachmentStatus.Click += new System.EventHandler(this.toolStripMenuItemGetAttachmentStatus_Click);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItemCheckUpdate
            // 
            this.toolStripMenuItemCheckUpdate.Name = "toolStripMenuItemCheckUpdate";
            this.toolStripMenuItemCheckUpdate.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemCheckUpdate.Text = "最新バージョンを確認";
            this.toolStripMenuItemCheckUpdate.Click += new System.EventHandler(this.toolStripMenuItemCheckUpdate_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(196, 22);
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
            // tabControlSetting
            // 
            this.tabControlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSetting.Controls.Add(this.tabPageSetting);
            this.tabControlSetting.Controls.Add(this.tabPageLog);
            this.tabControlSetting.Controls.Add(this.tabPageAbout);
            this.tabControlSetting.Location = new System.Drawing.Point(12, 12);
            this.tabControlSetting.Name = "tabControlSetting";
            this.tabControlSetting.SelectedIndex = 0;
            this.tabControlSetting.Size = new System.Drawing.Size(260, 209);
            this.tabControlSetting.TabIndex = 1;
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.checkBoxStartupRegister);
            this.tabPageSetting.Controls.Add(this.buttonChangeLogPath);
            this.tabPageSetting.Controls.Add(this.textBoxLogPath);
            this.tabPageSetting.Controls.Add(this.label4);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(252, 183);
            this.tabPageSetting.TabIndex = 0;
            this.tabPageSetting.Text = "設定";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartupRegister
            // 
            this.checkBoxStartupRegister.AutoSize = true;
            this.checkBoxStartupRegister.Location = new System.Drawing.Point(17, 67);
            this.checkBoxStartupRegister.Name = "checkBoxStartupRegister";
            this.checkBoxStartupRegister.Size = new System.Drawing.Size(216, 16);
            this.checkBoxStartupRegister.TabIndex = 3;
            this.checkBoxStartupRegister.Text = "OS起動時に自動的に起動するようにする";
            this.checkBoxStartupRegister.UseVisualStyleBackColor = true;
            this.checkBoxStartupRegister.CheckedChanged += new System.EventHandler(this.checkBoxStartupRegister_CheckedChanged);
            // 
            // buttonChangeLogPath
            // 
            this.buttonChangeLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeLogPath.Location = new System.Drawing.Point(162, 25);
            this.buttonChangeLogPath.Name = "buttonChangeLogPath";
            this.buttonChangeLogPath.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeLogPath.TabIndex = 2;
            this.buttonChangeLogPath.Text = "変更";
            this.buttonChangeLogPath.UseVisualStyleBackColor = true;
            this.buttonChangeLogPath.Click += new System.EventHandler(this.buttonChangeLogPath_Click);
            // 
            // textBoxLogPath
            // 
            this.textBoxLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogPath.Location = new System.Drawing.Point(17, 27);
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.Size = new System.Drawing.Size(139, 19);
            this.textBoxLogPath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ログの保存フォルダ";
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.listViewLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(252, 183);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "ログ";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listViewLog
            // 
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderType,
            this.columnHeaderName,
            this.columnHeaderId,
            this.columnHeaderEvent});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.Location = new System.Drawing.Point(3, 3);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(246, 177);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "時間";
            this.columnHeaderTime.Width = 80;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "種類";
            this.columnHeaderType.Width = 80;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "名前";
            this.columnHeaderName.Width = 80;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Skype ID";
            // 
            // columnHeaderEvent
            // 
            this.columnHeaderEvent.Text = "内容";
            this.columnHeaderEvent.Width = 100;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.labelVersion);
            this.tabPageAbout.Controls.Add(this.linkLabelHome);
            this.tabPageAbout.Controls.Add(this.label3);
            this.tabPageAbout.Controls.Add(this.label2);
            this.tabPageAbout.Controls.Add(this.label1);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(252, 183);
            this.tabPageAbout.TabIndex = 2;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(16, 38);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(54, 12);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "Version : ";
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.AutoSize = true;
            this.linkLabelHome.Location = new System.Drawing.Point(80, 88);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(112, 12);
            this.linkLabelHome.TabIndex = 3;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "http://mittostar.info/";
            this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "homepage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "mitto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Growl for Skype Notification";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(16, 227);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(252, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timerSkypeStatusCheck
            // 
            this.timerSkypeStatusCheck.Interval = 30000;
            this.timerSkypeStatusCheck.Tick += new System.EventHandler(this.timerSkypeStatusCheck_Tick);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControlSetting);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormSetting";
            this.Text = "設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.contextMenuStripRightClick.ResumeLayout(false);
            this.tabControlSetting.ResumeLayout(false);
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControlSetting;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderEvent;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.Button buttonChangeLogPath;
        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckUpdate;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.Timer timerSkypeStatusCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMonitoringSkype;
        private System.Windows.Forms.CheckBox checkBoxStartupRegister;
    }
}

