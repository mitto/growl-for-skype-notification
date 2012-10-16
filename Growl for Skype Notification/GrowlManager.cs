using System;
using System.Drawing;
using System.Globalization;
using Growl.Connector;
using Growl.CoreLibrary;

namespace Growl_for_Skype_Notification
{
    public class GrowlManager : GrowlManagerBase
    {
        #region "変数"

        private static readonly NotificationType TypeOnline = new NotificationType("Online Status");
        private static readonly NotificationType TypeChat = new NotificationType("Chat Received");
        private static readonly NotificationType TypeMood = new NotificationType("Mood Message");

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        public GrowlManager(Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
            : base(encryptionAlgorithm)
        {
        }

        public GrowlManager(string password, Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
            : base(password, encryptionAlgorithm) 
        {
        }

        public GrowlManager(string password, string hostname, int port, Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
            : base(password, hostname, port, encryptionAlgorithm)
        { 
        }

        #endregion

        /// <summary>
        /// GrowlManagerの初期化を行うメソッド
        /// </summary>
        public void Initialize()
        {
            Initialize("Skype Notification", Properties.Resources.skype.ToBitmap());
        }

        /// <summary>
        /// Growlへアプリケーションの登録を行うメソッド
        /// </summary>
        public void Register()
        {
            Register(AllNotificationType);
        }

        /// <summary>
        /// オンラインステータスの通知を発行するメソッド
        /// </summary>
        /// <param name="user">ステータス変更のあったユーザー</param>
        /// <param name="status">変更後のステータス情報</param>
        /// <param name="image">通知に使うビットマップイメージ</param>
        public void RunNotificationOnlineStatus(SKYPE4COMLib.User user, SKYPE4COMLib.TOnlineStatus status, Bitmap image = null)
        {
            const string title = "オンラインステータスの変更";
            string name = String.IsNullOrEmpty(user.FullName) ? "表示名がありません" : user.FullName;
            string message = String.Format("{0}({1})さんが\n「{2}」になりました。", name, user.Handle, SkypeManagerBase.GetOnlineStatusMessage(status));

            var context = MakeCallbackContext(NotificationTypeOnlineStatus.Name, user.Handle);

            var notification = new Notification(ApplicationName, NotificationTypeOnlineStatus.Name, DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture), title, message);
            if (image != null)
            {
                notification.Icon = image;
            }

            RunNotification(notification, context);
        }

        /// <summary>
        /// チャットの通知を発行するメソッド
        /// </summary>
        /// <param name="message">変更のあったチャット</param>
        /// <param name="status">変更後のチャットステータス</param>
        /// <param name="image">通知に使うビットマップイメージ</param>
        public void RunNotificationMessageStatus(SKYPE4COMLib.ChatMessage message, SKYPE4COMLib.TChatMessageStatus status, Bitmap image = null)
        {
            string name = String.IsNullOrEmpty(message.Sender.FullName) ? "表示名がありません" : message.Sender.FullName;
            string title = String.Format("{0}({1})さんからのチャット", name, message.Sender.Handle); 

            var context = MakeCallbackContext(NotificationTypeChatReceived.Name, message.Chat.Name);

            var notification = new Notification(ApplicationName, NotificationTypeChatReceived.Name, DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture), title, message.Body);
            if (image != null)
            {
                notification.Icon = image;
            }

            RunNotification(notification, context);
        }

        /// <summary>
        /// ムードメッセージの通知を発行するメソッド
        /// </summary>
        /// <param name="user">ムードメッセージを変更したユーザー</param>
        /// <param name="moodtext">変更されたムードメッセージの内容</param>
        /// <param name="image">通知に使うビットマップイメージ</param>
        public void RunNotificationUserMood(SKYPE4COMLib.User user, string moodtext, Bitmap image = null)
        {
            string name = String.IsNullOrEmpty(user.FullName) ? "表示名がありません" : user.FullName;
            string title = String.Format("{0}({1})さんのムードメッセージ", name, user.Handle);
            string body = String.IsNullOrEmpty(moodtext) ? "ムードメッセージが削除されました" : moodtext;

            var context = MakeCallbackContext(NotificationTypeMoodMessage.Name, user.Handle);

            var notification = new Notification(ApplicationName, NotificationTypeMoodMessage.Name, DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture), title, body);
            if (image != null)
            {
                notification.Icon = image;
            }

            RunNotification(notification, context);
        }

        /// <summary>
        /// チャットに変更があった場合の通知を発行するメソッド
        /// </summary>
        /// <param name="chat">大元の詳細なチャット情報</param>
        /// <param name="from">変更前のチャット本文</param>
        /// <param name="to">変更後のチャット本文</param>
        /// <param name="image">通知に使うビットマップイメージ</param>
        public void RunNotificationChangeChat(SKYPE4COMLib.ChatMessage chat, string from, string to, Bitmap image = null)
        {
            string name = String.IsNullOrEmpty(chat.Sender.FullName) ? "表示名がありません" : chat.Sender.FullName;
            string title = String.Format("{0}({1})さんがチャット内容を変更しました", name, chat.Sender.Handle);
            string body = String.Format("{0}\n\n↓\n\n{1}", from, string.IsNullOrEmpty(to) ? "メッセージが削除されました" : to);

            var context = MakeCallbackContext(NotificationTypeChatReceived.Name, chat.Chat.Name);

            var notification = new Notification(ApplicationName, NotificationTypeChatReceived.Name, DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture), title, body);
            if (image != null)
            {
                notification.Icon = image; 
            }

            RunNotification(notification, context);
        }

        /// <summary>
        /// テスト用の通知を発行するメソッド
        /// </summary>
        public void TestNotification()
        {
            RunNotification(NotificationTypeChatReceived, "Test Title", "Test Message");
        }

        #endregion

        #region "プロパティ"

        /// <summary>
        /// Growlへオンライン状況を通知する際に使う通知タイプ
        /// </summary>
        public static NotificationType NotificationTypeOnlineStatus
        {
            get
            {
                return TypeOnline;
            }
        }

        /// <summary>
        /// Growlへチャットの通知をする際に使う通知タイプ
        /// </summary>
        public static NotificationType NotificationTypeChatReceived
        {
            get
            {
                return TypeChat;
            }
        }

        /// <summary>
        /// Growlへムードメッセージの通知をする際に使う通知タイプ
        /// </summary>
        public static NotificationType NotificationTypeMoodMessage
        {
            get
            {
                return TypeMood;
            }
        }

        /// <summary>
        /// 定義してあるNotificationTypeを配列で渡してくれるプロパティ
        /// </summary>
        public static NotificationType[] AllNotificationType
        {
            get
            {
                return new[] { 
                    NotificationTypeChatReceived,
                    NotificationTypeMoodMessage,
                    NotificationTypeOnlineStatus
                };
            }
        }

        #endregion
    }
}
