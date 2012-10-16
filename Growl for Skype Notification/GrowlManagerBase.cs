using System;
using System.Drawing;
using System.Globalization;
using Growl.Connector;

namespace Growl_for_Skype_Notification
{
    public class GrowlManagerBase
    {
        #region "変数"

        protected GrowlConnector Connector;
        protected Application Application;

        protected GrowlConnector.CallbackEventHandler CallbackEventHandler = null;
        protected GrowlConnector.ResponseEventHandler ErrorResponseEventHandler = null;

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="encryptionAlgorithm">
        /// 通知メッセージの暗号化タイプを指定。
        /// デフォルトは「plaintext」
        /// </param>
        public GrowlManagerBase(Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
            : this ("", encryptionAlgorithm)
        {
        }

        /// <summary>
        /// Growlへの接続にパスワードを必要とする場合のコンストラクタ
        /// </summary>
        /// <param name="password">Growlへ接続する際に使うパスワード</param>
        /// <param name="encryptionAlgorithm">
        /// 通知メッセージの暗号化タイプを指定。
        /// デフォルトは「plaintext」
        /// </param>
        public GrowlManagerBase(string password, Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
        {
            Connector = new GrowlConnector(password) { EncryptionAlgorithm = encryptionAlgorithm };
        }

        /// <summary>
        /// 接続先を詳細に指定してGrowlに接続する場合のコンストラクタ
        /// </summary>
        /// <param name="password">Growlへ接続をする際に使うパスワード</param>
        /// <param name="hostname">接続ホスト名 or 接続先のIPアドレス</param>
        /// <param name="port">接続するポート番号</param>
        /// <param name="encryptionAlgorithm">
        /// 通知メッセージの暗号化タイプを指定。
        /// デフォルトは「plaintext」
        /// </param>
        public GrowlManagerBase(string password, string hostname, int port, Cryptography.SymmetricAlgorithmType encryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText)
        {
            Connector = new GrowlConnector(password, hostname, port) { EncryptionAlgorithm = encryptionAlgorithm };
        }

        #endregion

        /// <summary>
        /// Growlに登録を行う前の初期化を行うメソッド
        /// </summary>
        /// <param name="name">登録に使いたいアプリケーション名</param>
        /// <param name="image">アプリケーションを表すアイコンビットマップ</param>
        public void Initialize(string name, Bitmap image = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("アプリケーション名が空です。");
            }

            Application = new Application(name);

            if (image != null)
            {
                Application.Icon = image;
            }
        }

        /// <summary>
        /// Growlへアプリケーション登録を行うメソッド
        /// </summary>
        /// <param name="notificationTypeArray">通知の種類を表したNotifcationTypeの配列</param>
        public void Register(NotificationType[] notificationTypeArray)
        {
            if (Application == null)
            {
                throw new NullReferenceException("初期化が完了していません。Initializeメソッドを用いて初期化を行ってください"); 
            }

            Connector.Register(Application, notificationTypeArray);
        }

        /// <summary>
        /// Growl通知の発行を行うメソッド
        /// </summary>
        /// <param name="type">NotificationTypeを指定</param>
        /// <param name="title">通知で表示するタイトルを指定</param>
        /// <param name="message">通知で表示する本文を指定</param>
        /// <param name="context">コールバックで渡される値を指定</param>
        public void RunNotification(NotificationType type, string title, string message, CallbackContext context = null)
        {
            RunNotification(new Notification(ApplicationName, type.Name, DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture), title, message), context);
        }

        /// <summary>
        /// Growl通知の発行を行うメソッド
        /// </summary>
        /// <param name="notification">通知用データ</param>
        /// <param name="context">コールバック処理をしたい場合に指定</param>
        public void RunNotification(Notification notification, CallbackContext context = null)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            Connector.Notify(notification, context);
        }

        /// <summary>
        /// Growl通知のコールバックイベントハンドラーの登録を行うメソッド
        /// </summary>
        /// <param name="callback">登録するコールバックメソッド</param>
        public void CallbackSubscription(GrowlConnector.CallbackEventHandler callback)
        {
            if (IsSubscriptionCallback)
            {
                Connector.NotificationCallback -= CallbackEventHandler;
            }
            CallbackEventHandler = callback;
            Connector.NotificationCallback += CallbackEventHandler;
        }

        /// <summary>
        /// Growl通知のエラーレスポンスイベントハンドラーの登録を行うメソッド
        /// </summary>
        /// <param name="response">登録するエラーレスポンスメソッド</param>
        public void ErrorResponseSubscription(GrowlConnector.ResponseEventHandler response)
        {
            if (IsSubscriptionErrorResponse)
            {
                Connector.ErrorResponse -= ErrorResponseEventHandler;
            }
            ErrorResponseEventHandler = response;
            Connector.ErrorResponse += ErrorResponseEventHandler;
        }

        /// <summary>
        /// CallBackContextオブジェクトを生成するためのメソッド
        /// </summary>
        /// <param name="url">コールバック時に渡されるURLを指定</param>
        /// <returns>引数を元に生成したCallbackContext</returns>
        public static CallbackContext MakeCallbackContext(string url)
        {
            return new CallbackContext(url);
        }

        /// <summary>
        /// CallBackContextオブジェクトを生成するためのメソッド
        /// </summary>
        /// <param name="type">コールバックデータの種別を識別するための文字列を指定</param>
        /// <param name="data">コールバック時に渡されるデータを指定</param>
        /// <returns>引数を元に生成したCallbackContext</returns>
        public static CallbackContext MakeCallbackContext(string type, string data)
        {
            return new CallbackContext(data, type);
        }

        #endregion

        #region "プロパティ"

        /// <summary>
        /// Growlへの登録に使うアプリケーション名取得するためのプロパティ
        /// </summary>
        public string ApplicationName
        {
            get
            {
                if (Application == null)
                {
                    return "アプリケーションの登録が完了していません。"; 
                }
                return Application.Name;
            }
        }

        /// <summary>
        /// コールバックイベントハンドラの登録が完了しているかどうかのプロパティ
        /// </summary>
        public bool IsSubscriptionCallback
        {
            get
            {
                return CallbackEventHandler != null;
            }
        }

        /// <summary>
        /// エラーレスポンスイベントハンドラの登録が完了しているかどうかのプロパティ
        /// </summary>
        public bool IsSubscriptionErrorResponse
        {
            get
            {
                return ErrorResponseEventHandler != null;
            }
        }

        #endregion

    }
}
