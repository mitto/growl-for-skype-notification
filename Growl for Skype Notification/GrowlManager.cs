using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Growl.Connector;
using Growl.CoreLibrary;

namespace Growl_for_Skype_Notification
{
    public class GrowlManager : GrowlManagerBase
    {
        #region "変数"

        private static readonly NotificationType typeOnline = new NotificationType("Online Status");
        private static readonly NotificationType typeChat = new NotificationType("Chat Received");
        private static readonly NotificationType typeMood = new NotificationType("Mood Message");

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
            base.Initialize("Skype Notification", Properties.Resources.skype.ToBitmap());
        }

        /// <summary>
        /// Growlへアプリケーションの登録を行うメソッド
        /// </summary>
        public void Register()
        {
            base.Register(AllNotificationType);
        }

        /// <summary>
        /// オンラインステータスの通知を発行するメソッド
        /// </summary>
        /// <param name="user">ステータス変更のあったユーザー</param>
        /// <param name="status">変更後のステータス情報</param>
        public void RunNotificationOnlineStatus(SKYPE4COMLib.User user, SKYPE4COMLib.TOnlineStatus status)
        {
            string title = "オンラインステータスの変更";
            string name = String.IsNullOrEmpty(user.FullName) ? "表示名がありません" : user.FullName;
            string message = String.Format("{0}({1})さんが\n「{2}」になりました。", name, user.Handle, SkypeManager.GetOnlineStatusMessage(status));

            var context = GrowlManager.MakeCallbackContext(GrowlManager.NotificationTypeOnlineStatus.Name, user.Handle);

            RunNotification(GrowlManager.NotificationTypeOnlineStatus, title, message, context);
        }

        /// <summary>
        /// チャットの通知を発行するメソッド
        /// </summary>
        /// <param name="message">変更のあったチャット</param>
        /// <param name="status">変更後のチャットステータス</param>
        public void RunNotificationMessageStatus(SKYPE4COMLib.ChatMessage message, SKYPE4COMLib.TChatMessageStatus status)
        {
            string name = String.IsNullOrEmpty(message.Sender.FullName) ? "表示名がありません" : message.Sender.FullName;
            string title = String.Format("{0}({1})さんからのチャット", name, message.Sender.Handle); 

            var context = GrowlManager.MakeCallbackContext(GrowlManager.NotificationTypeChatReceived.Name, message.Chat.Name);

            RunNotification(GrowlManager.NotificationTypeChatReceived, title, message.Body, context);
        }

        /// <summary>
        /// ムードメッセージの通知を発行するメソッド
        /// </summary>
        /// <param name="user">ムードメッセージを変更したユーザー</param>
        /// <param name="moodtext">変更されたムードメッセージの内容</param>
        public void RunNotificationUserMood(SKYPE4COMLib.User user, string moodtext)
        {
            string name = String.IsNullOrEmpty(user.FullName) ? "表示名がありません" : user.FullName;
            string title = String.Format("{0}({1})さんのムードメッセージ", name, user.Handle);
            string body = String.IsNullOrEmpty(moodtext) ? "ムードメッセージが削除されました" : moodtext;

            var context = GrowlManager.MakeCallbackContext(GrowlManager.NotificationTypeMoodMessage.Name, user.Handle);

            RunNotification(GrowlManager.NotificationTypeMoodMessage, title, body, context);
        }

        public void RunNotificationChangeChat(SKYPE4COMLib.ChatMessage chat, string from, string to)
        {
            string name = String.IsNullOrEmpty(chat.Sender.FullName) ? "表示名がありません" : chat.Sender.FullName;
            string title = String.Format("{0}({1})さんがチャット内容を変更しました", name, chat.Sender.Handle);
            string body = String.Format("{0}\n\n↓\n\n{1}", from, to);

            var context = GrowlManager.MakeCallbackContext(GrowlManager.NotificationTypeChatReceived.Name, chat.Chat.Name);
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
                return typeOnline;
            }
        }

        /// <summary>
        /// Growlへチャットの通知をする際に使う通知タイプ
        /// </summary>
        public static NotificationType NotificationTypeChatReceived
        {
            get
            {
                return typeChat;
            }
        }

        /// <summary>
        /// Growlへムードメッセージの通知をする際に使う通知タイプ
        /// </summary>
        public static NotificationType NotificationTypeMoodMessage
        {
            get
            {
                return typeMood;
            }
        }

        /// <summary>
        /// 定義してあるNotificationTypeを配列で渡してくれるプロパティ
        /// </summary>
        public static NotificationType[] AllNotificationType
        {
            get
            {
                return new NotificationType[] { 
                    NotificationTypeChatReceived,
                    NotificationTypeMoodMessage,
                    NotificationTypeOnlineStatus
                };
            }
        }

        #endregion
    }
}
