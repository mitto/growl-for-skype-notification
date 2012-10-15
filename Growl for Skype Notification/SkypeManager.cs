using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using SKYPE4COMLib;
using System.Diagnostics;

namespace Growl_for_Skype_Notification
{
    public class SkypeManager : SkypeManagerBase
    {
        #region "変数"

        private GrowlManager growl = new GrowlManager();

        private Dictionary<int, ChatMessage> chatChangeHistoryDictionary = new Dictionary<int, ChatMessage>();
        private Dictionary<int, string> chatChangeMessageDictonary = new Dictionary<int, string>();

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

        /// <summary>
        /// GrowlManagerの初期化および登録、Skypeへの接続をまとめて行うメソッド
        /// </summary>
        public void Initialize()
        {
            growl.Initialize();
            growl.Register();
            AttachSkype();
        }

        /// <summary>
        /// GrowlManagerのRegisterへの中継メソッド
        /// </summary>
        public void GrowlRegister()
        {
            growl.Register();
        }

        /// <summary>
        /// GrowlManagerのCallbackSubscriptionへの中継メソッド
        /// </summary>
        /// <param name="callback">登録するコールバックメソッド</param>
        public void CallbackSubscription(Growl.Connector.GrowlConnector.CallbackEventHandler callback)
        {
            growl.CallbackSubscription(callback);
        }

        /// <summary>
        /// GrowlManagerのErrorResponseSubscriptionへの中継メソッド
        /// </summary>
        /// <param name="response">登録するエラーレスポンス処理用のメソッド</param>
        public void ErrorResponseSubscription(Growl.Connector.GrowlConnector.ResponseEventHandler response)
        {
            growl.ErrorResponseSubscription(response);
        }

        /// <summary>
        /// GrowlManagerのTestNotificationへの中継メソッド
        /// </summary>
        public void TestNotification()
        {
            growl.TestNotification();
        }
 
        /// <summary>
        /// チャットが飛んできたときに発生するイベントを処理するイベントハンドラ
        /// </summary>
        /// <param name="pMessage">イベントを発生させたチャットの詳細データ</param>
        /// <param name="Status">イベントを発生させたチャットの状態</param>
        private void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            switch (Status)
            {
                case TChatMessageStatus.cmsRead:
                    break;
                case TChatMessageStatus.cmsReceived:
                    chatChangeHistoryDictionary.Add(pMessage.Id, pMessage);
                    growl.RunNotificationMessageStatus(pMessage, Status, GetUserAvatar(pMessage.Sender.Handle));
                    break;
                case TChatMessageStatus.cmsSending:
                    break;
                case TChatMessageStatus.cmsSent:
                    break;
                case TChatMessageStatus.cmsUnknown:
                    break;
            }
        }

        /// <summary>
        /// オンラインステータスに変更があったときに発生するイベントを処理するイベントハンドラ
        /// </summary>
        /// <param name="pUser">オンラインステータスに変更があったユーザーの詳細データ</param>
        /// <param name="Status">変更後のオンラインステータス</param>
        private void skype_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            //オンラインとオフラインの状態が切り替わった際に
            //全アカウント分(?)くらいの通知が投げられてくるので
            //処理しないようにする
            if (IsOffline)
            {
                return;
            }

            growl.RunNotificationOnlineStatus(pUser, Status, GetUserAvatar(pUser.Handle));
        }

        /// <summary>
        /// Skypeから飛んでくる生のコマンドを処理するイベントハンドラー
        /// </summary>
        /// <param name="pCommand">受け取るコマンド</param>
        private void skype_Reply(Command pCommand)
        {
            var splitCommands = pCommand.Reply.Split(' ');

            switch (splitCommands[0].ToLower())
            {
                case "chatmessage":
                    ParseChatMessageCommand(splitCommands);
                    break;
            }

        }

        /// <summary>
        /// ムードメッセージに変更があった場合に発生するイベントを処理するイベントハンドラ
        /// </summary>
        /// <param name="pUser"></param>
        /// <param name="MoodText"></param>
        private void skype_UserMood(User pUser, string MoodText)
        {
            growl.RunNotificationUserMood(pUser, MoodText, GetUserAvatar(pUser.Handle));
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
                        string from = chat.Body;
                        string to = commands[3];
                        if (chatChangeMessageDictonary.ContainsKey(id))
                        {
                            from = chatChangeMessageDictonary[id]; 
                        }
                        growl.RunNotificationChangeChat(chat, from, to, GetUserAvatar(chat.Sender.Handle));
                        chatChangeMessageDictonary[id] = to;
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
