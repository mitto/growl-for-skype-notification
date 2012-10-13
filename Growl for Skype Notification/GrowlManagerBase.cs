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

        #endregion

        #region "プロパティ"

        #endregion

    }
}
