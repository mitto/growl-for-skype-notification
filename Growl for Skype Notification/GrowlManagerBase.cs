﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Growl.Connector;
using Growl.CoreLibrary;

namespace Growl_for_Skype_Notification
{
    public class GrowlManagerBase
    {
        #region "変数"

        private GrowlConnector connector;
        private Application application;

        private bool _isSubscription = false;

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
        {
            connector = new GrowlConnector();
            connector.EncryptionAlgorithm = encryptionAlgorithm;
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
            connector = new GrowlConnector(password);
            connector.EncryptionAlgorithm = encryptionAlgorithm;
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
            connector = new GrowlConnector(password, hostname, port);
            connector.EncryptionAlgorithm = encryptionAlgorithm;
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

            application = new Application(ApplicationName);

            if (image != null)
            {
                application.Icon = (Resource)image;
            }
        }

        /// <summary>
        /// Growlへアプリケーション登録を行うメソッド
        /// </summary>
        /// <param name="notificationTypeArray">通知の種類を表したNotifcationTypeの配列</param>
        public void Register(NotificationType[] notificationTypeArray)
        {
            if (application == null)
            {
                throw new NullReferenceException("初期化が完了していません。Initializeメソッドを用いて初期化を行ってください"); 
            }

            connector.Register(application, notificationTypeArray);
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
                throw new ArgumentNullException("notificationがnullです。");
            }

            connector.Notify(notification, context);
        }

        /// <summary>
        /// Growl通知のコールバックイベントハンドラーの登録を行うメソッド
        /// </summary>
        /// <param name="callbackEventHandler"></param>
        public void CallbackSubscription(GrowlConnector.CallbackEventHandler callbackEventHandler)
        {
            if (!IsSubscription)
            {
                connector.NotificationCallback += callbackEventHandler;
            }
            IsSubscription = true;
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
                if (application == null)
                {
                    return "アプリケーションの登録が完了していません。"; 
                }
                return application.Name;
            }
        }

        /// <summary>
        /// イベントハンドラメソッドの登録が完了しているかどうかのプロパティ
        /// </summary>
        public bool IsSubscription
        {
            get
            {
                return _isSubscription;
            }
            private set
            {
                _isSubscription = value;
            }
        }

        #endregion

    }
}
