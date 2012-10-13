using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Growl.Connector;

namespace Growl_for_Skype_Notification
{
    public class GrowlManagerBase
    {
        #region "変数"

        private GrowlConnector connector;
        private Application application;

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
        /// <param name="name"></param>
        public void Initialize(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("アプリケーション名が空です。");
            }

            application = new Application(ApplicationName);
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

        #endregion

    }
}
