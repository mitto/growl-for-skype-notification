using System;
using System.Collections.Generic;
using System.Globalization;
using SKYPE4COMLib;
using System.Diagnostics;

namespace Growl_for_Skype_Notification
{
    public class SkypeManager : SkypeManagerBase
    {
        #region "変数"

        private readonly GrowlManager _growl = new GrowlManager();

        private readonly Dictionary<int, ChatMessage> _chatChangeHistoryDictionary = new Dictionary<int, ChatMessage>();
        private readonly Dictionary<int, string> _chatChangeMessageDictonary = new Dictionary<int, string>();

        private bool _isInitialized;

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SkypeManager()
        {
            skype.MessageStatus += SkypeMessageStatus;
            skype.OnlineStatus += SkypeOnlineStatus;
            skype.Reply += SkypeReply;
            skype.UserMood += SkypeUserMood;
        }

        #endregion

        /// <summary>
        /// GrowlManagerの初期化および登録、Skypeへの接続をまとめて行うメソッド
        /// </summary>
        public void Initialize()
        {
            _growl.Initialize();
            _growl.Register();

            if (!IsInitialized)
            {
                _growl.CallbackSubscription(ConnectorNotificationCallback);
                _growl.ErrorResponseSubscription(connector_ErrorResponse);
                _isInitialized = true;
            }

            AttachSkype();
        }

        /// <summary>
        /// GrowlManagerのRegisterへの中継メソッド
        /// </summary>
        public void GrowlRegister()
        {
            _growl.Register();
        }

        /// <summary>
        /// Growlが通知を終えた際に呼び出されるコールバックを処理するイベントハンドラ
        /// </summary>
        /// <param name="response"></param>
        /// <param name="callbackData"></param>
        /// <param name="state"></param>
        private void ConnectorNotificationCallback(Growl.Connector.Response response, Growl.Connector.CallbackData callbackData, object state)
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
            System.Windows.Forms.MessageBox.Show(response.ErrorDescription, response.ErrorCode.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GrowlManagerのTestNotificationへの中継メソッド
        /// </summary>
        public void TestNotification()
        {
            _growl.TestNotification();
        }
 
        /// <summary>
        /// チャットが飛んできたときに発生するイベントを処理するイベントハンドラ
        /// </summary>
        /// <param name="pMessage">イベントを発生させたチャットの詳細データ</param>
        /// <param name="status">イベントを発生させたチャットの状態</param>
        private void SkypeMessageStatus(ChatMessage pMessage, TChatMessageStatus status)
        {
            switch (status)
            {
                case TChatMessageStatus.cmsRead:
                    break;
                case TChatMessageStatus.cmsReceived:
                    _chatChangeHistoryDictionary.Add(pMessage.Id, pMessage);
                    _growl.RunNotificationMessageStatus(pMessage, status, GetUserAvatar(pMessage.Sender.Handle));
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
        /// <param name="status">変更後のオンラインステータス</param>
        private void SkypeOnlineStatus(User pUser, TOnlineStatus status)
        {
            //オンラインとオフラインの状態が切り替わった際に
            //全アカウント分(?)くらいの通知が投げられてくるので
            //処理しないようにする
            if (IsOffline)
            {
                return;
            }

            _growl.RunNotificationOnlineStatus(pUser, status, GetUserAvatar(pUser.Handle));
        }

        /// <summary>
        /// Skypeから飛んでくる生のコマンドを処理するイベントハンドラー
        /// </summary>
        /// <param name="pCommand">受け取るコマンド</param>
        private void SkypeReply(Command pCommand)
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
        /// <param name="moodText"></param>
        private void SkypeUserMood(User pUser, string moodText)
        {
            _growl.RunNotificationUserMood(pUser, moodText, GetUserAvatar(pUser.Handle));
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
                    if (_chatChangeHistoryDictionary.ContainsKey(id))
                    {
                        var chat = _chatChangeHistoryDictionary[id];
                        string from = chat.Body;
                        string to = commands[3];
                        if (_chatChangeMessageDictonary.ContainsKey(id))
                        {
                            from = _chatChangeMessageDictonary[id]; 
                        }
                        _growl.RunNotificationChangeChat(chat, from, to, GetUserAvatar(chat.Sender.Handle));
                        _chatChangeMessageDictonary[id] = to;
                    }
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
