namespace Growl_for_Skype_Notification
{
    partial class FormFirstRun
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
            this.textBoxLogPath = new System.Windows.Forms.TextBox();
            this.buttonLogPathChange = new System.Windows.Forms.Button();
            this.toolTipFirstRun = new System.Windows.Forms.ToolTip(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxMonitoringSkype = new System.Windows.Forms.CheckBox();
            this.checkBoxStartup = new System.Windows.Forms.CheckBox();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLogPath
            // 
            this.textBoxLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogPath.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxLogPath.Location = new System.Drawing.Point(6, 20);
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.Size = new System.Drawing.Size(217, 19);
            this.textBoxLogPath.TabIndex = 1;
            this.toolTipFirstRun.SetToolTip(this.textBoxLogPath, "初期値ではアプリケーションの起動ディレクトリとなっています。\r\nこの値は後から変更可能です。");
            // 
            // buttonLogPathChange
            // 
            this.buttonLogPathChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogPathChange.Location = new System.Drawing.Point(229, 18);
            this.buttonLogPathChange.Name = "buttonLogPathChange";
            this.buttonLogPathChange.Size = new System.Drawing.Size(75, 23);
            this.buttonLogPathChange.TabIndex = 2;
            this.buttonLogPathChange.Text = "変更 (&C)";
            this.buttonLogPathChange.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(12, 128);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(310, 50);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "設定終了";
            this.toolTipFirstRun.SetToolTip(this.buttonClose, "このボタンを押すと設定を終了して\r\nGrowlとSkypeへアプリケーション登録を行います。");
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonitoringSkype
            // 
            this.checkBoxMonitoringSkype.AutoSize = true;
            this.checkBoxMonitoringSkype.Location = new System.Drawing.Point(23, 96);
            this.checkBoxMonitoringSkype.Name = "checkBoxMonitoringSkype";
            this.checkBoxMonitoringSkype.Size = new System.Drawing.Size(216, 16);
            this.checkBoxMonitoringSkype.TabIndex = 3;
            this.checkBoxMonitoringSkype.Text = "Skypeの動作状態を監視して通知を行う";
            this.checkBoxMonitoringSkype.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartup
            // 
            this.checkBoxStartup.AutoSize = true;
            this.checkBoxStartup.Location = new System.Drawing.Point(23, 74);
            this.checkBoxStartup.Name = "checkBoxStartup";
            this.checkBoxStartup.Size = new System.Drawing.Size(232, 16);
            this.checkBoxStartup.TabIndex = 4;
            this.checkBoxStartup.Text = "このアプリケーションをスタートアップに登録する";
            this.checkBoxStartup.UseVisualStyleBackColor = true;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLog.Controls.Add(this.buttonLogPathChange);
            this.groupBoxLog.Controls.Add(this.textBoxLogPath);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(310, 48);
            this.groupBoxLog.TabIndex = 5;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "ログの保存ディレクトリ";
            // 
            // FormFirstRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 190);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.checkBoxStartup);
            this.Controls.Add(this.checkBoxMonitoringSkype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(350, 1000);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormFirstRun";
            this.Text = "初回起動";
            this.Load += new System.EventHandler(this.FormFirstRunLoad);
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.Button buttonLogPathChange;
        private System.Windows.Forms.ToolTip toolTipFirstRun;
        private System.Windows.Forms.CheckBox checkBoxMonitoringSkype;
        private System.Windows.Forms.CheckBox checkBoxStartup;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.Button buttonClose;
    }
}