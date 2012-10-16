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

            SettingManager.LoadSettings();
            _skypeManager.Initialize();
            RegisterEventHandler();

            notifyIconTray.Text = String.Format("{0}[{1}]", Application.ProductName, Application.ProductVersion);
            labelVersion.Text += Application.ProductVersion;
            textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
        }

        /// <summary>
        /// 簡単なイベントハンドラーを登録するメソッド
        /// </summary>
        private void RegisterEventHandler()
        {
            Shown += (sender, e) => SetVisible(false);
            FormClosing +=
                (sender, e) =>
                    {
                        if (e.CloseReason == CloseReason.UserClosing)
                        {
                            e.Cancel = true;
                            SetVisible(false);
                        }
                    };

            notifyIconTray.MouseClick +=
                (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            SetVisible(!Visible);
                        }
                    };

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
            toolStripMenuItemOpenSetting.Click += (sender, e) => SetVisible(true);

            toolStripMenuItemAttachSkype.Click += (sender, e) => _skypeManager.AttachSkype();
            toolStripMenuItemRegisterGrowl.Click += (sender, e) => _skypeManager.GrowlRegister();
            toolStripMenuItemTestNotification.Click += (sender,e) => _skypeManager.TestNotification();
            toolStripMenuItemGetAttachmentStatus.Click += (sender, e) => _skypeManager.ShowAttachmentStatus();
            //toolStripMenuItemMonitoringSkype.Click += (sender, e) => ChangeMonitoringSkype();
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

        #endregion

        #region "Other"

        private void SetVisible(Boolean isVisible)
        {
            if (isVisible)
            {
                ShowInTaskbar = true;
                Visible = true;
                Focus();
            }
            else
            {
                Visible = false;
                ShowInTaskbar = false;
            }
        }

        #endregion
    }
}
