using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

using SKYPE4COMLib;
using Growl.Connector;

namespace Growl_for_Skype_Notification
{
    public partial class FormSetting : Form
    {
        private Skype skype;
        private GrowlConnector connector;
        private Growl.Connector.Application application;

        //通知の種類
        private static readonly NotificationType notificationTypeOnline = new NotificationType("Online Status");
        private static readonly NotificationType notificationTypeChat = new NotificationType("Chat Received");
        private static readonly NotificationType notificationTypeMood = new NotificationType("Mood Message");

        //Growlのアプリケーション登録に使う定数
        private readonly static string APPLICATION_NAME = "Skype Notification";
        private readonly static string TRAY_ICON_MESSAGE = String.Format("{0}[{1}]", System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ProductVersion);

        private readonly static string SUBKEY_STARTUP = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private static string LogPath = "";
        private static string FileName = "";

        private bool isOffline = false;

        public FormSetting()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetVisible(false);

            skype = new Skype();
            connector = new GrowlConnector();
            connector.EncryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText;
            application = new Growl.Connector.Application(APPLICATION_NAME);
            application.Icon = (Growl.CoreLibrary.Resource)Properties.Resources.skype.ToBitmap();

            notifyIconTray.Text = TRAY_ICON_MESSAGE;

            labelVersion.Text += System.Windows.Forms.Application.ProductVersion;

            FileName = String.Format("log-{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));

            LoadSettings();

            AttachSkype();
            RegisterGrowlEvent();
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SetVisible(false);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeLogPath_Click(object sender, EventArgs e)
        {
            ChangeLogPath(Properties.Settings.Default.LogPath);
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelHome.Text);
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                SetVisible(!this.Visible);
            }
        }

        private void timerSkypeStatusCheck_Tick(object sender, EventArgs e)
        {
            TAttachmentStatus status = ((ISkype)skype).AttachmentStatus;

            var title = "情報";
            var body = "";
            var icon = ToolTipIcon.Info;

            if (status == TAttachmentStatus.apiAttachSuccess)
            {
                return;
            }

            switch (status)
            {
                case TAttachmentStatus.apiAttachAvailable:
                    body = "Skypeへの連携ができますが接続されていません。\n接続を試みます。";
                    AttachSkype();
                    break;
                case TAttachmentStatus.apiAttachNotAvailable:
                    title = "警告";
                    body = "Skypeにうまく接続できません。";
                    icon = ToolTipIcon.Warning;
                    break;
                case TAttachmentStatus.apiAttachPendingAuthorization:
                    body = "Skype側でアプリ連携を許可してください";
                    icon = ToolTipIcon.Warning;
                    break;
                case TAttachmentStatus.apiAttachRefused:
                    title = "エラー";
                    body = "Skype側でアプリ連携が拒否されているようです。\nSkypeの設定画面を開き\n「詳細」→「詳細設定」と進み\n「他のプログラムからのSkypeへのアクセスを管理」から\nこのアプリケーションの連携を許可するように変更してください。";
                    icon = ToolTipIcon.Error;
                    break;
                case TAttachmentStatus.apiAttachUnknown:
                    title = "エラー";
                    body = "不明なエラー為Skypeへ接続することができませんでした。";
                    icon = ToolTipIcon.Error;
                    break;
            }

            notifyIconTray.BalloonTipTitle = title;
            notifyIconTray.BalloonTipText = body;
            notifyIconTray.BalloonTipIcon = icon;
            notifyIconTray.ShowBalloonTip(10000);
        }

        private void checkBoxStartupRegister_CheckedChanged(object sender, EventArgs e)
        {
            ChangeStartupRegister();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void toolStripMenuItemOpenSetting_Click(object sender, EventArgs e)
        {
            SetVisible(true);
        }

        private void toolStripMenuItemAttachSkype_Click(object sender, EventArgs e)
        {
            AttachSkype();
        }

        private void toolStripMenuItemRegisterGrowl_Click(object sender, EventArgs e)
        {
            RegisterGrowl();
        }

        private void toolStripMenuItemTestNotification_Click(object sender, EventArgs e)
        {
            NotifiGrowl(notificationTypeChat, "Test Title", "Test Message");
        }

        private void toolStripMenuItemGetAttachmentStatus_Click(object sender, EventArgs e)
        {
            TAttachmentStatus status = ((ISkype)skype).AttachmentStatus;
            MessageBox.Show(String.Format("{0}\n{1}", status.ToString(), GetAttachmentStatusMessage(status)));
        }

        private void toolStripMenuItemCheckUpdate_Click(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Boolean updateAvailable = false;
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    updateAvailable = ad.CheckForUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("更新を確認中にエラーが発生しました。\nネットワークに繋がっているかを確認して再度お試しください。\n\nError:" + dde);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("アプリケーションがうまく配置されていない可能性があります。\n再インストールをお試しください。\n\nError: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("すでに更新を確認中です。\n\nError: " + ioe.Message);
                    return;
                }

                if (updateAvailable && MessageBox.Show(this, "最新版が利用できます。更新しますか？", "更新の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        ad.Update();
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        MessageBox.Show("更新をインストールできませんでした。\n更新サーバーがダウンしているかネットワークに接続していない可能性があります。\nネットワークに接続しているか確認して再度お試しください。\n\nError: " + dde.Message);
                    }
                    catch (TrustNotGrantedException tnge)
                    {
                        MessageBox.Show("更新をインストールできませんでした。\n\n\nError: " + tnge.Message);
                    }
                    if ((MessageBox.Show(this, "更新が完了しました。更新を有効にするにはアプリケーションを再起動する必要があります。再起動しますか？", "再起動の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        System.Windows.Forms.Application.Restart();
                    }

                }
            }
        }

        private void toolStripMenuItemMonitoringSkype_Click(object sender, EventArgs e)
        {
            ChangeMonitoringSkype();
        }

        #endregion

        #region "Growl"

        private void RegisterGrowl()
        {
            connector.Register(application, new NotificationType[] { notificationTypeChat, notificationTypeOnline, notificationTypeMood });
            RegisterGrowlEvent();
        }

        private void RegisterGrowlEvent()
        {
            connector.ErrorResponse -= new GrowlConnector.ResponseEventHandler(connector_ErrorResponse);
            connector.NotificationCallback -= new GrowlConnector.CallbackEventHandler(connector_NotificationCallback);
            connector.ErrorResponse += new GrowlConnector.ResponseEventHandler(connector_ErrorResponse);
            connector.NotificationCallback += new GrowlConnector.CallbackEventHandler(connector_NotificationCallback);
        }

        private void connector_NotificationCallback(Response response, CallbackData callbackData, object state)
        {
            Debug.WriteLine("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data);
            Trace.WriteLine(String.Format("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data));
            if (callbackData.Result == Growl.CoreLibrary.CallbackResult.CLICK)
            {
                if (callbackData.Data != "")
                {
                    skype.Chat[callbackData.Data].OpenWindow();
                    skype.Client.Start();
                }
            }
        }

        private void NotifiGrowl(NotificationType type, string title, string message)
        {
            connector.Notify(new Notification(application.Name, type.Name, DateTime.Now.Ticks.ToString(), title, message));
        }

        private void NotifiGrowl(NotificationType type, string title, string message, CallbackContext callbackContext)
        {
            connector.Notify(new Notification(application.Name, type.Name, DateTime.Now.Ticks.ToString(), title, message), callbackContext);
        }

        private void connector_ErrorResponse(Response response, object state)
        {
            MessageBox.Show(response.ErrorDescription, response.ErrorCode.ToString());
        }

        #endregion

        #region "Skype"

        private void AttachSkype()
        {
            skype.Attach(7, false);

            if (((ISkype)skype).AttachmentStatus == TAttachmentStatus.apiAttachSuccess)
            {
                notifyIconTray.Text = String.Format("{0}\nLoggin:{1}", TRAY_ICON_MESSAGE, skype.CurrentUser.Handle);
            }

            //イベントハンドラの多重登録を防ぐため登録解除してから登録し直す
            skype.MessageStatus -= new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            skype.OnlineStatus -= new _ISkypeEvents_OnlineStatusEventHandler(skype_OnlineStatus);
            skype.UserMood -= new _ISkypeEvents_UserMoodEventHandler(skype_UserMood);
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            skype.OnlineStatus += new _ISkypeEvents_OnlineStatusEventHandler(skype_OnlineStatus);
            skype.UserMood += new _ISkypeEvents_UserMoodEventHandler(skype_UserMood);
        }

        private void skype_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            //オンラインとオフラインの状態が切り替わった際に全アカウント分のオンラインステータスが投げられてくる事への対処
            if (pUser.Handle == skype.CurrentUser.Handle)
            {
                isOffline = (Status == TOnlineStatus.olsOffline) ? true : false;
                return;
            }

            if (isOffline) return;

            CallbackContext callbackContext = new CallbackContext(pUser.Handle, "OnlineStatus");
            NotifiGrowl(notificationTypeOnline, "オンラインステータスの変更",
                String.Format("{0}({1})さんが\n「{2}」になりました。", pUser.FullName, pUser.Handle, GetOnlineStatusMessage(Status)), callbackContext);

            AddLog(DateTime.Now, "オンラインステータス", pUser.FullName, pUser.Handle, String.Format("「{0}」になりました。", GetOnlineStatusMessage(Status)));
        }

        private void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            switch (Status)
            {
                case TChatMessageStatus.cmsReceived:
                    CallbackContext callbackContext = new CallbackContext(pMessage.Chat.Name, "MessageStatus");
                    NotifiGrowl(notificationTypeChat, String.Format("{0}({1})さんからのチャット",
                        pMessage.Sender.FullName, pMessage.Sender.Handle), pMessage.Body, callbackContext);
                    AddLog(DateTime.Now, "チャット", pMessage.Sender.FullName, pMessage.Sender.Handle, pMessage.Body);
                    break;
            }
        }

        private void skype_UserMood(User pUser, string MoodText)
        {
            CallbackContext callbackContext = new CallbackContext(pUser.Handle, "Mood Message");
            NotifiGrowl(notificationTypeMood, String.Format("{0}({1})さんのムードメッセージ", pUser.FullName, pUser.Handle),
                MoodText == "" ? "ムードメッセージが削除されました" : MoodText, callbackContext);
            AddLog(DateTime.Now, "ムードメッセージ", pUser.FullName, pUser.Handle, MoodText);
        }

        private string GetOnlineStatusMessage(TOnlineStatus status)
        {
            switch (status)
            {
                case TOnlineStatus.olsAway:
                    return "一時退席中";
                case TOnlineStatus.olsDoNotDisturb:
                    return "取り込み中";
                case TOnlineStatus.olsNotAvailable:
                    return "退席中";
                case TOnlineStatus.olsOffline:
                    return "オフライン";
                case TOnlineStatus.olsOnline:
                    return "オンライン";
                case TOnlineStatus.olsSkypeMe:
                    return "SkypeMe";
                case TOnlineStatus.olsSkypeOut:
                    return "SkypeOut";
                case TOnlineStatus.olsUnknown:
                    return "Unknown";
                default:
                    return "その他";
            }
        }

        private string GetAttachmentStatusMessage(TAttachmentStatus status)
        {
            switch (status)
            {
                case TAttachmentStatus.apiAttachSuccess:
                    return "Skypeに接続成功しています。";
                case TAttachmentStatus.apiAttachAvailable:
                case TAttachmentStatus.apiAttachNotAvailable:
                case TAttachmentStatus.apiAttachUnknown:
                    return "うまく接続できていないようです。\nタスクトレイアイコンのコマンドメニューから「Skypeへ接続」を試してみてください。";
                case TAttachmentStatus.apiAttachPendingAuthorization:
                    return "接続許可申請をSkype側にリクエストしています。\nSkypeで接続を許可してください。";
                case TAttachmentStatus.apiAttachRefused:
                    return "Skypeへの接続が失敗しました。\nSkype側で接続拒否を行っていないか確認してください。";
                default:
                    return "";
            }
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
                RegisterGrowl();
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

            checkBoxStartupRegister.Checked = IsExistsStartupRegistryKey();
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

        private void ChangeStartupRegister()
        {
            if (IsExistsStartupRegistryKey())
            {
                DeleteStartupRegistryKey();
            }
            else
            {
                SetStartupRegistryKey();
            }

            checkBoxStartupRegister.Checked = IsExistsStartupRegistryKey();
        }

        private bool IsExistsStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                var value = regkey.GetValue(System.Windows.Forms.Application.ProductName);
                if (value != null)
                {
                    return true;
                }
                return false;
            }
        }

        private void SetStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                regkey.SetValue(System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ExecutablePath);
            }
        }

        private void DeleteStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                regkey.DeleteValue(System.Windows.Forms.Application.ProductName);
            }
        }

        #endregion
    }
}
