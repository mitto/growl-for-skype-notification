using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using SKYPE4COMLib;
using Growl.Connector;
using System.IO;

namespace Skype_to_Growl_Notification
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

        private static string LogPath = System.Windows.Forms.Application.StartupPath;

        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            skype = new Skype();
            connector = new GrowlConnector();
            connector.EncryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText;
            application = new Growl.Connector.Application(APPLICATION_NAME);
            application.Icon = (Growl.CoreLibrary.Resource)Properties.Resources.skype.ToBitmap();

            labelVersion.Text += System.Windows.Forms.Application.ProductVersion;

            LogPath += LogPath.EndsWith("\\") ? "log.txt" : "\\log.txt";

            if (!Properties.Settings.Default.IsFirstRun)
            {
                MessageBox.Show("初回起動です。\nGrowlへの登録とSkypeへの接続を行います。", "確認");
                RegisterGrowl();
                Properties.Settings.Default.IsFirstRun = true;
                Properties.Settings.Default.Save();
            }
            AttachSkype();
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelHome.Text);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void toolStripMenuItemOpenSetting_Click(object sender, EventArgs e)
        {
            this.Visible = true;
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
            MessageBox.Show(((ISkype)skype).AttachmentStatus.ToString());
        }

        #region "Growl"

        private void RegisterGrowl()
        {
            connector.Register(application, new NotificationType[] { notificationTypeChat, notificationTypeOnline, notificationTypeMood });
            connector.ErrorResponse -= new GrowlConnector.ResponseEventHandler(connector_ErrorResponse);
            connector.NotificationCallback -= new GrowlConnector.CallbackEventHandler(connector_NotificationCallback);
            connector.ErrorResponse += new GrowlConnector.ResponseEventHandler(connector_ErrorResponse);
            connector.NotificationCallback += new GrowlConnector.CallbackEventHandler(connector_NotificationCallback);
        }

        private void connector_NotificationCallback(Response response, CallbackData callbackData, object state)
        {
            if (callbackData.Result == Growl.CoreLibrary.CallbackResult.CLICK)
            {
                if (callbackData.Data != "")
                {
                    skype.Chat[callbackData.Data].OpenWindow();
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
            skype.MessageStatus -= new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            skype.OnlineStatus -= new _ISkypeEvents_OnlineStatusEventHandler(skype_OnlineStatus);
            skype.UserMood -= new _ISkypeEvents_UserMoodEventHandler(skype_UserMood);
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            skype.OnlineStatus += new _ISkypeEvents_OnlineStatusEventHandler(skype_OnlineStatus);
            skype.UserMood += new _ISkypeEvents_UserMoodEventHandler(skype_UserMood);
        }

        private void skype_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            CallbackContext callbackContext = new CallbackContext(pUser.Handle, "OnlineStatus");
            string message = pUser.FullName + "(" + pUser.Handle + ")" + "さんが\n「";
            switch (Status)
            {
                case TOnlineStatus.olsAway:
                    message += "退席中";
                    break;
                case TOnlineStatus.olsDoNotDisturb:
                    message += "取り込み中";
                    break;
                case TOnlineStatus.olsNotAvailable:
                    message += "NotAvailable";
                    break;
                case TOnlineStatus.olsOffline:
                    message += "オフライン";
                    break;
                case TOnlineStatus.olsOnline:
                    message += "オンライン";
                    break;
                case TOnlineStatus.olsSkypeMe:
                    message += "SkypeMe";
                    break;
                case TOnlineStatus.olsSkypeOut:
                    message += "SkypeOut";
                    break;
                case TOnlineStatus.olsUnknown:
                    message += "Unknown";
                    break;
            }
            message += "」になりました。";
            NotifiGrowl(notificationTypeOnline, "オンラインステータスの変更", message, callbackContext);

            AddLog(DateTime.Now, "オンラインステータス", pUser.FullName + "(" + pUser.Handle + ")", message);
        }

        private void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            
            string title = pMessage.Sender.FullName + "(" + pMessage.Sender.Handle + ")" + "さんからのチャット";
            switch (Status)
            {
                case TChatMessageStatus.cmsReceived:
                    CallbackContext callbackContext = new CallbackContext(pMessage.Chat.Name, "MessageStatus");
                    NotifiGrowl(notificationTypeChat, title , pMessage.Body, callbackContext);
                    AddLog(DateTime.Now, "チャット", pMessage.Sender.FullName + "(" + pMessage.Sender.Handle + ")", pMessage.Body);
                    break;
            }
        }

        private void skype_UserMood(User pUser, string MoodText)
        {
            string message = MoodText == "" ? "ムードメッセージが削除されました" : MoodText;
            CallbackContext callbackContext = new CallbackContext(pUser.Handle, "Mood Message");
            NotifiGrowl(notificationTypeMood, pUser.FullName + "(" + pUser.Handle + ")さんのムードメッセージ", message, callbackContext);
            AddLog(DateTime.Now, "ムードメッセージ", pUser.FullName + "(" + pUser.Handle + ")", MoodText);
        }

        #endregion

        #region "Other"

        private void AddLog(DateTime time, string type, string name, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string[] item = { date, type, name, message};
            listViewLog.Items.Add(new ListViewItem(item));

            using (var writer = File.AppendText(LogPath))
            {
                writer.WriteLine("{0}\t{1}\t{2}\t{3}", date, type, name, message);
            }
        }

        #endregion

        private void notifyIconTray_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            this.Focus();
        }
    }
}
