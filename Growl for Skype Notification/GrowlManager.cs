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

        #endregion

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
