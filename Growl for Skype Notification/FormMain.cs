﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Growl_for_Skype_Notification.Properties;

namespace Growl_for_Skype_Notification
{
    public partial class FormMain : Form
    {
        private readonly SkypeManager _skypeManager = new SkypeManager();

        public FormMain()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSettingLoad(object sender, EventArgs e)
        {
            SetVisible(false);
            Text = Application.ProductName;
            RegisterEventHandler();

            SettingManager.LoadSettings();
            _skypeManager.Initialize();

            RefreshSettingForm();
        }

        /// <summary>
        /// 簡単なイベントハンドラーを登録するメソッド
        /// </summary>
        private void RegisterEventHandler()
        {
            _skypeManager.ChangeAttachmentStatus += SkypeAttachmentStatusCheck;

            SettingManager.ChangeIsMonitoringSkype += (sender, e) => toolStripMenuItemMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;

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

            toolStripMenuItemFileSetting.Click +=
                (sender, e) =>
                    {
                        using(var dialog = new FormSetting())
                        {
                            dialog.ShowDialog(this);
                        }
                    };
            toolStripMenuItemFileExit.Click += (sender, e) => Application.Exit();

            toolStripMenuItemWindowToggleVisible.Click += (sender, e) => SetVisible(false);

            toolStripMenuItemHelpAboutSoftware.Click += (sender, e) => Utilities.AboutSoftware();
            toolStripMenuItemHelpCheckUpdate.Click += (sender, e) => Utilities.CheckNewDeployment();
            toolStripMenuItemHelpOpenDeveloperSite.Click += (sender, e) => Process.Start(Resources.HomepageUri);

            toolStripMenuItemExit.Click += (sender, e) => Application.Exit();
            toolStripMenuItemCheckUpdate.Click += (sender, e) => Utilities.CheckNewDeployment();
            toolStripMenuItemOpenSetting.Click += (sender, e) => SetVisible(true);

            toolStripMenuItemAttachSkype.Click += (sender, e) => _skypeManager.AttachSkype();
            toolStripMenuItemRegisterGrowl.Click += (sender, e) => _skypeManager.GrowlRegister();
            toolStripMenuItemTestNotification.Click += (sender, e) => _skypeManager.TestNotification();
            toolStripMenuItemGetAttachmentStatus.Click += (sender, e) => _skypeManager.ShowAttachmentStatus();
            toolStripMenuItemMonitoringSkype.Click += (sender, e) => _skypeManager.ToggleMonitorSkypeTimerEnable();
        }

        private void SkypeAttachmentStatusCheck(object sender, ChangeAttachmentStatusEventArgs e)
        {
            var title = Resources.Information;
            var body = SkypeManager.GetAttachmentStatusMessage(e.AfterAttachmentStatus);
            var icon = ToolTipIcon.Info;

            //標準提供のメッセージは表示用などに向かないため独自の物を表示するようにする
            switch (e.AfterAttachmentStatus)
            {
                case SKYPE4COMLib.TAttachmentStatus.apiAttachSuccess:
                    body = "Skypeへの接続に成功しました";
                    break;
                case SKYPE4COMLib.TAttachmentStatus.apiAttachAvailable:
                    body = "Skypeへの連携ができますが接続されていません";
                    break;
                case SKYPE4COMLib.TAttachmentStatus.apiAttachNotAvailable:
                    title = Resources.Warning;
                    icon = ToolTipIcon.Warning;
                    break;
                case SKYPE4COMLib.TAttachmentStatus.apiAttachPendingAuthorization:
                    body += "\nSkype側でアプリ連携を許可してください";
                    icon = ToolTipIcon.Warning;
                    break;
                case SKYPE4COMLib.TAttachmentStatus.apiAttachRefused:
                    title = Resources.Error;
                    body = "Skype側でアプリ連携が拒否されているようです。\n\n" +
                        "Skypeの設定画面を開き\n「詳細」→「詳細設定」と進み\n" +
                        "「他のプログラムからのSkypeへのアクセスを管理」から\n" +
                        "このアプリケーションの連携を許可するように変更してください。";
                    icon = ToolTipIcon.Error;
                    break;
                case SKYPE4COMLib.TAttachmentStatus.apiAttachUnknown:
                    title = Resources.Error;
                    body = "不明なエラー為Skypeへ接続することができません。";
                    icon = ToolTipIcon.Error;
                    break;
            }

            //いずれの場合においてもとりあえずアタッチを仕掛ける方針で
            //設定として自動的に再接続しないようにする場合はここをいじることとする
            if (e.AfterAttachmentStatus != SKYPE4COMLib.TAttachmentStatus.apiAttachSuccess)
            {
                body += "\n\n再接続を試みます。";
                _skypeManager.AttachSkype();
            }

            ShowBalloonTip(title, body, icon);
        }

        #endregion

        #region "Other"

        private void RefreshSettingForm()
        {
            notifyIconTray.Text = String.Format("{0}[{1}]", Application.ProductName, Application.ProductVersion);

            toolStripMenuItemMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;
        }

        private void ShowBalloonTip(string title, string body, ToolTipIcon icon)
        {
            notifyIconTray.ShowBalloonTip(10000, title, body, icon);
        }

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
