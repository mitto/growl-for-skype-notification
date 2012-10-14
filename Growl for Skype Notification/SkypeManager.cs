using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SKYPE4COMLib;

namespace Growl_for_Skype_Notification
{
    public class SkypeManager : SkypeManagerBase
    {
        #region "変数"

        private GrowlManager growl = new GrowlManager();

        private Dictionary<int, ChatMessage> chatChangeHistoryDictionary = new Dictionary<int, ChatMessage>();

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SkypeManager()
            : base()
        {
            skype.MessageStatus += skype_MessageStatus;
            skype.OnlineStatus += skype_OnlineStatus;
            skype.Reply += skype_Reply;
            skype.UserMood += skype_UserMood;
        }

        #endregion

        private void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            switch (Status)
            {
                case TChatMessageStatus.cmsRead:
                    break;
                case TChatMessageStatus.cmsReceived:
                    chatChangeHistoryDictionary.Add(pMessage.Id, pMessage);
                    growl.RunNotificationMessageStatus(pMessage, Status);
                    break;
                case TChatMessageStatus.cmsSending:
                    break;
                case TChatMessageStatus.cmsSent:
                    break;
                case TChatMessageStatus.cmsUnknown:
                    break;
            }
        }

        private void skype_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            //オンラインとオフラインの状態が切り替わった際に
            //全アカウント分(?)くらいの通知が投げられてくるので
            //処理しないようにする
            if (IsOffline)
            {
                return;
            }

            growl.RunNotificationOnlineStatus(pUser, Status);
        }

        private void skype_Reply(Command pCommand)
        {
            var splitCommands = pCommand.Reply.Split(' ');

            switch (splitCommands[0].ToLower())
            {
                case "chatmessage":
                    ParseChatMessageCommand(splitCommands);
                    break;
                default:
                    break;
            }
        }

        private void skype_UserMood(User pUser, string MoodText)
        {
            growl.RunNotificationUserMood(pUser, MoodText);
        }

        /// <summary>
        /// CHATMESSAGEコマンドの解析を行い処理を行うメソッド
        /// </summary>
        /// <param name="commands"></param>
        private void ParseChatMessageCommand(string[] commands)
        {
            int id;
            int.TryParse(commands[1], out id);
            switch (commands[2].ToLower())
            {
                case "body":
                    if (chatChangeHistoryDictionary.ContainsKey(id))
                    {
                        var chat = chatChangeHistoryDictionary[id];
                        growl.RunNotificationChangeChat(chat, chat.Body, commands[3]);
                        chat.Body = commands[3];
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region "プロパティ"

        #endregion


    }
}
