namespace Growl_for_Skype_Notification
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripContainerMain = new System.Windows.Forms.ToolStripContainer();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageOnlineStatus = new System.Windows.Forms.TabPage();
            this.dataGridViewOnlineStatus = new System.Windows.Forms.DataGridView();
            this.tabPageMoodMessage = new System.Windows.Forms.TabPage();
            this.dataGridViewMoodMessage = new System.Windows.Forms.DataGridView();
            this.tabPageChat = new System.Windows.Forms.TabPage();
            this.dataGridViewChat = new System.Windows.Forms.DataGridView();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFileSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWindowToggleVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemHelpAboutSoftware = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpOpenDeveloperSite = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainerMain.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.ContentPanel.SuspendLayout();
            this.toolStripContainerMain.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageOnlineStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnlineStatus)).BeginInit();
            this.tabPageMoodMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoodMessage)).BeginInit();
            this.tabPageChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChat)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.contextMenuStripRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainerMain
            // 
            // 
            // toolStripContainerMain.BottomToolStripPanel
            // 
            this.toolStripContainerMain.BottomToolStripPanel.Controls.Add(this.statusStripMain);
            // 
            // toolStripContainerMain.ContentPanel
            // 
            this.toolStripContainerMain.ContentPanel.Controls.Add(this.tabControlMain);
            this.toolStripContainerMain.ContentPanel.Size = new System.Drawing.Size(471, 346);
            this.toolStripContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainerMain.Name = "toolStripContainerMain";
            this.toolStripContainerMain.Size = new System.Drawing.Size(471, 394);
            this.toolStripContainerMain.TabIndex = 0;
            this.toolStripContainerMain.Text = "toolStripContainer1";
            // 
            // toolStripContainerMain.TopToolStripPanel
            // 
            this.toolStripContainerMain.TopToolStripPanel.Controls.Add(this.menuStripMain);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripMain.Location = new System.Drawing.Point(0, 0);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(471, 22);
            this.statusStripMain.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageOnlineStatus);
            this.tabControlMain.Controls.Add(this.tabPageMoodMessage);
            this.tabControlMain.Controls.Add(this.tabPageChat);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(471, 346);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageOnlineStatus
            // 
            this.tabPageOnlineStatus.Controls.Add(this.dataGridViewOnlineStatus);
            this.tabPageOnlineStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageOnlineStatus.Name = "tabPageOnlineStatus";
            this.tabPageOnlineStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOnlineStatus.Size = new System.Drawing.Size(463, 320);
            this.tabPageOnlineStatus.TabIndex = 0;
            this.tabPageOnlineStatus.Text = "オンラインステータス";
            this.tabPageOnlineStatus.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOnlineStatus
            // 
            this.dataGridViewOnlineStatus.AllowUserToAddRows = false;
            this.dataGridViewOnlineStatus.AllowUserToDeleteRows = false;
            this.dataGridViewOnlineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOnlineStatus.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOnlineStatus.Name = "dataGridViewOnlineStatus";
            this.dataGridViewOnlineStatus.ReadOnly = true;
            this.dataGridViewOnlineStatus.Size = new System.Drawing.Size(457, 314);
            this.dataGridViewOnlineStatus.TabIndex = 0;
            // 
            // tabPageMoodMessage
            // 
            this.tabPageMoodMessage.Controls.Add(this.dataGridViewMoodMessage);
            this.tabPageMoodMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMoodMessage.Name = "tabPageMoodMessage";
            this.tabPageMoodMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMoodMessage.Size = new System.Drawing.Size(463, 320);
            this.tabPageMoodMessage.TabIndex = 1;
            this.tabPageMoodMessage.Text = "ムードメッセージ";
            this.tabPageMoodMessage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMoodMessage
            // 
            this.dataGridViewMoodMessage.AllowUserToAddRows = false;
            this.dataGridViewMoodMessage.AllowUserToDeleteRows = false;
            this.dataGridViewMoodMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMoodMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMoodMessage.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMoodMessage.Name = "dataGridViewMoodMessage";
            this.dataGridViewMoodMessage.ReadOnly = true;
            this.dataGridViewMoodMessage.RowTemplate.Height = 21;
            this.dataGridViewMoodMessage.Size = new System.Drawing.Size(457, 314);
            this.dataGridViewMoodMessage.TabIndex = 0;
            // 
            // tabPageChat
            // 
            this.tabPageChat.Controls.Add(this.dataGridViewChat);
            this.tabPageChat.Location = new System.Drawing.Point(4, 22);
            this.tabPageChat.Name = "tabPageChat";
            this.tabPageChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChat.Size = new System.Drawing.Size(463, 320);
            this.tabPageChat.TabIndex = 2;
            this.tabPageChat.Text = "チャット";
            this.tabPageChat.UseVisualStyleBackColor = true;
            // 
            // dataGridViewChat
            // 
            this.dataGridViewChat.AllowUserToAddRows = false;
            this.dataGridViewChat.AllowUserToDeleteRows = false;
            this.dataGridViewChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewChat.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewChat.Name = "dataGridViewChat";
            this.dataGridViewChat.ReadOnly = true;
            this.dataGridViewChat.RowTemplate.Height = 21;
            this.dataGridViewChat.Size = new System.Drawing.Size(457, 314);
            this.dataGridViewChat.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemWindow,
            this.toolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(471, 26);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFileSetting,
            this.toolStripSeparator1,
            this.toolStripMenuItemFileExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(89, 22);
            this.toolStripMenuItemFile.Text = "ファイル (&F)";
            // 
            // toolStripMenuItemFileSetting
            // 
            this.toolStripMenuItemFileSetting.Name = "toolStripMenuItemFileSetting";
            this.toolStripMenuItemFileSetting.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemFileSetting.Text = "設定 (&S)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItemFileExit
            // 
            this.toolStripMenuItemFileExit.Name = "toolStripMenuItemFileExit";
            this.toolStripMenuItemFileExit.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemFileExit.Text = "終了 (&X)";
            // 
            // toolStripMenuItemWindow
            // 
            this.toolStripMenuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemWindowToggleVisible});
            this.toolStripMenuItemWindow.Name = "toolStripMenuItemWindow";
            this.toolStripMenuItemWindow.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuItemWindow.Text = "ウィンドウ (&W)";
            // 
            // toolStripMenuItemWindowToggleVisible
            // 
            this.toolStripMenuItemWindowToggleVisible.Name = "toolStripMenuItemWindowToggleVisible";
            this.toolStripMenuItemWindowToggleVisible.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemWindowToggleVisible.Text = "通知領域に隠す";
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHelpCheckUpdate,
            this.toolStripSeparator2,
            this.toolStripMenuItemHelpAboutSoftware,
            this.toolStripMenuItemHelpOpenDeveloperSite});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(79, 22);
            this.toolStripMenuItemHelp.Text = "ヘルプ (&H)";
            // 
            // toolStripMenuItemHelpCheckUpdate
            // 
            this.toolStripMenuItemHelpCheckUpdate.Name = "toolStripMenuItemHelpCheckUpdate";
            this.toolStripMenuItemHelpCheckUpdate.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemHelpCheckUpdate.Text = "最新バージョンの確認";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItemHelpAboutSoftware
            // 
            this.toolStripMenuItemHelpAboutSoftware.Name = "toolStripMenuItemHelpAboutSoftware";
            this.toolStripMenuItemHelpAboutSoftware.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemHelpAboutSoftware.Text = "このソフトについて";
            // 
            // toolStripMenuItemHelpOpenDeveloperSite
            // 
            this.toolStripMenuItemHelpOpenDeveloperSite.Name = "toolStripMenuItemHelpOpenDeveloperSite";
            this.toolStripMenuItemHelpOpenDeveloperSite.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemHelpOpenDeveloperSite.Text = "作者のサイトへ";
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
            this.toolStripSeparator4,
            this.toolStripMenuItemMonitoringSkype,
            this.toolStripMenuItemCommands,
            this.toolStripSeparator5,
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
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItemMonitoringSkype
            // 
            this.toolStripMenuItemMonitoringSkype.Name = "toolStripMenuItemMonitoringSkype";
            this.toolStripMenuItemMonitoringSkype.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemMonitoringSkype.Text = "Skypeの状態を監視";
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
            // 
            // toolStripMenuItemGetAttachmentStatus
            // 
            this.toolStripMenuItemGetAttachmentStatus.Name = "toolStripMenuItemGetAttachmentStatus";
            this.toolStripMenuItemGetAttachmentStatus.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemGetAttachmentStatus.Text = "接続状況の確認";
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
            // 
            // toolStripMenuItemTestNotification
            // 
            this.toolStripMenuItemTestNotification.Name = "toolStripMenuItemTestNotification";
            this.toolStripMenuItemTestNotification.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemTestNotification.Text = "テスト通知の送信";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItemCheckUpdate
            // 
            this.toolStripMenuItemCheckUpdate.Name = "toolStripMenuItemCheckUpdate";
            this.toolStripMenuItemCheckUpdate.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemCheckUpdate.Text = "最新バージョンを確認";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItemExit.Text = "終了 (&X)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 394);
            this.Controls.Add(this.toolStripContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormSettingLoad);
            this.toolStripContainerMain.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.BottomToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ContentPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerMain.TopToolStripPanel.PerformLayout();
            this.toolStripContainerMain.ResumeLayout(false);
            this.toolStripContainerMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageOnlineStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnlineStatus)).EndInit();
            this.tabPageMoodMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoodMessage)).EndInit();
            this.tabPageChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChat)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.contextMenuStripRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainerMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageOnlineStatus;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.DataGridView dataGridViewOnlineStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFileSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFileExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpAboutSoftware;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpOpenDeveloperSite;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMonitoringSkype;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCommands;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttachSkype;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGetAttachmentStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegisterGrowl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTestNotification;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWindowToggleVisible;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.TabPage tabPageMoodMessage;
        private System.Windows.Forms.DataGridView dataGridViewMoodMessage;
        private System.Windows.Forms.TabPage tabPageChat;
        private System.Windows.Forms.DataGridView dataGridViewChat;
    }
}