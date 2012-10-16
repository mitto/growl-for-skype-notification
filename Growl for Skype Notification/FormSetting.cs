using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Growl_for_Skype_Notification
{
    public partial class FormSetting : Form
    {
        private readonly SkypeManager _skypeManager = new SkypeManager();

        public FormSetting()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSettingLoad(object sender, EventArgs e)
        {
            SetVisible(false);

            _skypeManager.Initialize();
            _skypeManager.GrowlRegister();

            notifyIconTray.Text = String.Format("{0}[{1}]", Application.ProductName, Application.ProductVersion);

            labelVersion.Text += Application.ProductVersion;

            SettingManager.LoadSettings();

            textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;

            RegisterEventHandler();
        }

        /// <summary>
        /// 簡単なイベントハンドラーを登録するメソッド
        /// </summary>
        private void RegisterEventHandler()
        {
            buttonClose.Click += (sender, e) => Close();
            buttonChangeLogPath.Click +=
                (sender, e) =>
                    {
                        SettingManager.ChangeLogFilesPath();
                        textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
                    };

            checkBoxStartupRegister.CheckedChanged += (sender, e) => SettingManager.ToggleRegistryStartupRun();

            linkLabelHome.LinkClicked += (sender, e) => Process.Start(linkLabelHome.Text);

            toolStripMenuItemExit.Click += (sender, e) => Application.Exit();
            toolStripMenuItemCheckUpdate.Click += (sender, e) => Utilities.CheckNewDeployment();

            toolStripMenuItemAttachSkype.Click += (sender, e) => _skypeManager.AttachSkype();
            toolStripMenuItemRegisterGrowl.Click += (sender, e) => _skypeManager.GrowlRegister();
            toolStripMenuItemTestNotification.Click += (sender,e) => _skypeManager.TestNotification();
        }

        private void FormSettingFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SetVisible(false);
            }
        }

        private void NotifyIconTrayMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetVisible(!Visible);
            }
        }

        private void TimerSkypeStatusCheckTick(object sender, EventArgs e)
        {
            //var title = "情報";
            //var body = "";
            //var icon = ToolTipIcon.Info;

            //if (skypeManager.IsAttached)
            //{
            //    return;
            //}

            //switch (skypeManager.AttachmentStatus)
            //{
            //    case TAttachmentStatus.apiAttachAvailable:
            //        body = "Skypeへの連携ができますが接続されていません。\n接続を試みます。";
            //        AttachSkype();
            //        break;
            //    case TAttachmentStatus.apiAttachNotAvailable:
            //        title = "警告";
            //        body = "Skypeにうまく接続できません。";
            //        icon = ToolTipIcon.Warning;
            //        break;
            //    case TAttachmentStatus.apiAttachPendingAuthorization:
            //        body = "Skype側でアプリ連携を許可してください";
            //        icon = ToolTipIcon.Warning;
            //        break;
            //    case TAttachmentStatus.apiAttachRefused:
            //        title = "エラー";
            //        body = "Skype側でアプリ連携が拒否されているようです。\nSkypeの設定画面を開き\n「詳細」→「詳細設定」と進み\n「他のプログラムからのSkypeへのアクセスを管理」から\nこのアプリケーションの連携を許可するように変更してください。";
            //        icon = ToolTipIcon.Error;
            //        break;
            //    case TAttachmentStatus.apiAttachUnknown:
            //        title = "エラー";
            //        body = "不明なエラー為Skypeへ接続することができませんでした。";
            //        icon = ToolTipIcon.Error;
            //        break;
            //}

            //notifyIconTray.BalloonTipTitle = title;
            //notifyIconTray.BalloonTipText = body;
            //notifyIconTray.BalloonTipIcon = icon;
            //notifyIconTray.ShowBalloonTip(10000);
        }

        private void ToolStripMenuItemOpenSettingClick(object sender, EventArgs e)
        {
            SetVisible(true);
        }

        private void ToolStripMenuItemGetAttachmentStatusClick(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0}\n{1}", _skypeManager.AttachmentStatus.ToString(), SkypeManagerBase.GetAttachmentStatusMessage(_skypeManager.AttachmentStatus)));
        }

        private void ToolStripMenuItemMonitoringSkypeClick(object sender, EventArgs e)
        {
            //ChangeMonitoringSkype();
        }

        #endregion

        #region "Other"

        private void SetVisible(Boolean isVisible)
        {
            ShowInTaskbar = isVisible;
            Visible = isVisible;
            if (isVisible)
            {
                Focus();
            }
        }

        #endregion
    }
}
