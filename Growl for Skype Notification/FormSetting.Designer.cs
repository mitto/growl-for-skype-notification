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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSendTestMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlSetting = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxMonitoringSkype = new System.Windows.Forms.CheckBox();
            this.checkBoxStartupRegister = new System.Windows.Forms.CheckBox();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.groupBoxLogSavePath = new System.Windows.Forms.GroupBox();
            this.textBoxLogPath = new System.Windows.Forms.TextBox();
            this.buttonChangeLogPath = new System.Windows.Forms.Button();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlSetting.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.groupBoxLogSavePath.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControlSetting.Controls.Add(this.tabPageGeneral);
            this.tabControlSetting.Controls.Add(this.tabPageLog);
            this.tabControlSetting.Controls.Add(this.tabPageAbout);
            this.tabControlSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSetting.Location = new System.Drawing.Point(0, 0);
            this.tabControlSetting.Name = "tabControlSetting";
            this.tabControlSetting.SelectedIndex = 0;
            this.tabControlSetting.Size = new System.Drawing.Size(384, 262);
            this.tabControlSetting.TabIndex = 1;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxMonitoringSkype);
            this.tabPageGeneral.Controls.Add(this.checkBoxStartupRegister);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(376, 236);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "全般";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonitoringSkype
            // 
            this.checkBoxMonitoringSkype.AutoSize = true;
            this.checkBoxMonitoringSkype.Location = new System.Drawing.Point(13, 34);
            this.checkBoxMonitoringSkype.Name = "checkBoxMonitoringSkype";
            this.checkBoxMonitoringSkype.Size = new System.Drawing.Size(215, 16);
            this.checkBoxMonitoringSkype.TabIndex = 4;
            this.checkBoxMonitoringSkype.Text = "Skypeとの接続状況を監視して通知する";
            this.checkBoxMonitoringSkype.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartupRegister
            // 
            this.checkBoxStartupRegister.AutoSize = true;
            this.checkBoxStartupRegister.Location = new System.Drawing.Point(13, 12);
            this.checkBoxStartupRegister.Name = "checkBoxStartupRegister";
            this.checkBoxStartupRegister.Size = new System.Drawing.Size(216, 16);
            this.checkBoxStartupRegister.TabIndex = 3;
            this.checkBoxStartupRegister.Text = "OS起動時に自動的に起動するようにする";
            this.checkBoxStartupRegister.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.groupBoxLogSavePath);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(376, 236);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "ログ";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogSavePath
            // 
            this.groupBoxLogSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLogSavePath.Controls.Add(this.textBoxLogPath);
            this.groupBoxLogSavePath.Controls.Add(this.buttonChangeLogPath);
            this.groupBoxLogSavePath.Location = new System.Drawing.Point(8, 6);
            this.groupBoxLogSavePath.Name = "groupBoxLogSavePath";
            this.groupBoxLogSavePath.Size = new System.Drawing.Size(360, 51);
            this.groupBoxLogSavePath.TabIndex = 0;
            this.groupBoxLogSavePath.TabStop = false;
            this.groupBoxLogSavePath.Text = "ログの保存ディレクトリ";
            // 
            // textBoxLogPath
            // 
            this.textBoxLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogPath.Location = new System.Drawing.Point(6, 18);
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.Size = new System.Drawing.Size(263, 19);
            this.textBoxLogPath.TabIndex = 1;
            // 
            // buttonChangeLogPath
            // 
            this.buttonChangeLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeLogPath.Location = new System.Drawing.Point(275, 16);
            this.buttonChangeLogPath.Name = "buttonChangeLogPath";
            this.buttonChangeLogPath.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeLogPath.TabIndex = 2;
            this.buttonChangeLogPath.Text = "変更";
            this.buttonChangeLogPath.UseVisualStyleBackColor = true;
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
            this.tabPageAbout.Size = new System.Drawing.Size(376, 236);
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
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.tabControlSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormSetting";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.FormSettingLoad);
            this.tabControlSetting.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.groupBoxLogSavePath.ResumeLayout(false);
            this.groupBoxLogSavePath.PerformLayout();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSendTestMessage;
        private System.Windows.Forms.TabControl tabControlSetting;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonChangeLogPath;
        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.CheckBox checkBoxStartupRegister;
        private System.Windows.Forms.CheckBox checkBoxMonitoringSkype;
        private System.Windows.Forms.GroupBox groupBoxLogSavePath;
    }
}

