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

        private bool _isInitialized = false;

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

            if (!IsInitialized)
            {
                growl.CallbackSubscription(connector_NotificationCallback);
                growl.ErrorResponseSubscription(connector_ErrorResponse);
                _isInitialized = true;
            }

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
        /// Growlが通知を終えた際に呼び出されるコールバックを処理するイベントハンドラ
        /// </summary>
        /// <param name="response"></param>
        /// <param name="callbackData"></param>
        /// <param name="state"></param>
        private void connector_NotificationCallback(Growl.Connector.Response response, Growl.Connector.CallbackData callbackData, object state)
        {
            Debug.WriteLine("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data);
            Trace.WriteLine(String.Format("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data));
            if (callbackData.Result == Growl.CoreLibrary.CallbackResult.CLICK)
            {
                if (callbackData.Data != "")
                {
                    OpenChatWindow(callbackData.Data);
                }
            }
        }

        /// <summary>
        /// Growlにエラーがあった場合に発生するイベントを処理するイベントハンドラ
        /// </summary>
        /// <param name="response"></param>
        /// <param name="state"></param>
        private void connector_ErrorResponse(Growl.Connector.Response response, object state)
        {
            System.Windows.Forms.MessageBox.Show(response.ErrorDescription, response.ErrorCode.ToString());
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

        /// <summary>
        /// Initializeメソッドを一度でも呼び出しているかのプロパティ
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }
        }

        #endregion
   }
}
