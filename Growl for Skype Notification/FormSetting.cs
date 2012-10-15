using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Growl_for_Skype_Notification
{
    public partial class FormSetting : Form
    {
        private SkypeManager skypeManager = new SkypeManager();

        private readonly static string TRAY_ICON_MESSAGE = String.Format("{0}[{1}]", System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ProductVersion);

        private static string LogPath = "";
        private static string FileName = "";

        public FormSetting()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetVisible(false);

            skypeManager.Initialize();

            notifyIconTray.Text = TRAY_ICON_MESSAGE;

            labelVersion.Text += System.Windows.Forms.Application.ProductVersion;

            FileName = String.Format("log-{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));

            LoadSettings();

            RegisterEventHandler();
        }

        /// <summary>
        /// 簡単なイベントハンドラーを登録するメソッド
        /// </summary>
        private void RegisterEventHandler()
        {
            buttonClose.Click += (sender, e) => this.Close();

            checkBoxStartupRegister.CheckedChanged += (sender, e) => SettingManager.ChangeStartupRegister();

            linkLabelHome.LinkClicked += (sender, e) => Process.Start(linkLabelHome.Text);

            toolStripMenuItemExit.Click += (sender, e) => Application.Exit();
            toolStripMenuItemCheckUpdate.Click += (sender, e) => Utilities.CheckNewDeployment();

            toolStripMenuItemAttachSkype.Click += (sender, e) => skypeManager.AttachSkype();
            toolStripMenuItemRegisterGrowl.Click += (sender, e) => skypeManager.GrowlRegister();
            toolStripMenuItemTestNotification.Click += (sender,e) => skypeManager.TestNotification();
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SetVisible(false);
            }
        }

        private void buttonChangeLogPath_Click(object sender, EventArgs e)
        {
            ChangeLogPath(Properties.Settings.Default.LogPath);
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetVisible(!this.Visible);
            }
        }

        private void timerSkypeStatusCheck_Tick(object sender, EventArgs e)
        {
            //var status = skypeManager.AttachmentStatus;

            //var title = "情報";
            //var body = "";
            //var icon = ToolTipIcon.Info;

            //if (skypeManager.IsAttached)
            //{
            //    return;
            //}

            //switch (status)
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

        private void toolStripMenuItemOpenSetting_Click(object sender, EventArgs e)
        {
            SetVisible(true);
        }

        private void toolStripMenuItemGetAttachmentStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0}\n{1}", skypeManager.AttachmentStatus.ToString(), SkypeManager.GetAttachmentStatusMessage(skypeManager.AttachmentStatus)));
        }

        private void toolStripMenuItemMonitoringSkype_Click(object sender, EventArgs e)
        {
            ChangeMonitoringSkype();
        }

        #endregion

        #region "Other"

        private void AddLog(DateTime time, string type, string name, string id, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string[] item = { date, type, name, id, message };
            listViewLog.Items.Add(new ListViewItem(item));

            using (var writer = File.AppendText(LogPath))
            {
                writer.WriteLine("{0}\t{1}\t{2}\t{3}", date, type, name, message);
            }
        }

        private void LoadSettings()
        {
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
            }

            if (!Properties.Settings.Default.IsFirstRun)
            {
                MessageBox.Show("初回起動です。\nGrowlへの登録とSkypeへの接続を行います。", "確認");
                skypeManager.GrowlRegister();
                Properties.Settings.Default.IsFirstRun = true;
                string message = "続けてログの保存場所を決定します。\nデフォルト値はアプリケーションの実行ファイルがある場所です。\n[" + System.Windows.Forms.Application.StartupPath + "]\n\n変更しますか？\n変更する場合は：OK\nデフォルト設定を利用する場合は：Cancel\n\n*後で設定画面から変更することも可能です。";
                if (MessageBox.Show(message, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    ChangeLogPath(System.Windows.Forms.Application.StartupPath);
                }
                else
                {
                    ChangeLogPath();
                }
            }

            UpdateLogPath();

            timerSkypeStatusCheck.Enabled = Properties.Settings.Default.IsMonitoringSkype;
            toolStripMenuItemMonitoringSkype.Checked = Properties.Settings.Default.IsMonitoringSkype;

            checkBoxStartupRegister.Checked = SettingManager.IsExistsStartupRegistryKey();
        }

        private void ChangeLogPath()
        {
            Properties.Settings.Default.LogPath = Properties.Settings.Default.LogPath == "" ? AppendBackSlash(System.Windows.Forms.Application.StartupPath) : Properties.Settings.Default.LogPath;
            Properties.Settings.Default.Save();
        }

        private void ChangeLogPath(string oldpath)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = oldpath;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.LogPath = AppendBackSlash(dialog.SelectedPath);
                }
                else
                {
                    ChangeLogPath();
                }
            }
            Properties.Settings.Default.Save();
            UpdateLogPath();
        }

        private void ChangeMonitoringSkype()
        {
            Properties.Settings.Default.IsMonitoringSkype = !Properties.Settings.Default.IsMonitoringSkype;
            Properties.Settings.Default.Save();
            timerSkypeStatusCheck.Enabled = Properties.Settings.Default.IsMonitoringSkype;
            toolStripMenuItemMonitoringSkype.Checked = Properties.Settings.Default.IsMonitoringSkype;
        }

        private string AppendBackSlash(string path)
        {
            path += path.EndsWith("\\") ? "" : "\\";
            return path;
        }

        private void UpdateLogPath()
        {
            if (Properties.Settings.Default.LogPath == "")
            {
                ChangeLogPath();
            }
            LogPath = Properties.Settings.Default.LogPath + FileName;
            textBoxLogPath.Text = Properties.Settings.Default.LogPath;
        }

        private void SetVisible(Boolean isVisible)
        {
            this.ShowInTaskbar = isVisible;
            this.Visible = isVisible;
            if (isVisible)
            {
                this.Focus();
            }
        }

        #endregion
    }
}
