using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SKYPE4COMLib;

namespace Growl_for_Skype_Notification
{
    public class SkypeManager
    {
        #region "変数"

        private Skype skype;

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        public SkypeManager()
        {
            skype = new Skype();
        }

        #endregion

        /// <summary>
        /// Skype自体を起動させるためのメソッド
        /// </summary>
        /// <param name="minized">最小化した状態で起動させるか</param>
        /// <param name="nosplash">起動時にスプラッシュ画面を表示させるか</param>
        public void StartingSkype(bool minized = false, bool nosplash = false)
        {
            skype.Client.Start(minized, nosplash);
        }

        /// <summary>
        /// TAttachmentStatusを渡すと該当する簡易メッセージを返すメソッド
        /// </summary>
        /// <param name="status">取得したいTAttachmentStatus</param>
        /// <returns>アタッチ状態の簡易メッセージ</returns>
        public static string GetAttachmentStatusMessage(TAttachmentStatus status)
        {
            switch (status)
            {
                case TAttachmentStatus.apiAttachSuccess:
                    return "Skypeへの接続に成功しています。";
                case TAttachmentStatus.apiAttachAvailable:
                    return "Skypeへ接続できます。";
                case TAttachmentStatus.apiAttachNotAvailable:
                    return "Skype側の接続準備が完了していません。";
                case TAttachmentStatus.apiAttachUnknown:
                    return "原因不明で接続できません。";
                case TAttachmentStatus.apiAttachPendingAuthorization:
                    return "接続許可申請をSkype側にリクエスト済みです。";
                case TAttachmentStatus.apiAttachRefused:
                    return "Skypeとの接続が拒否されました。";
            }
            return "";
        }

        #endregion

        #region "プロパティ"

        /// <summary>
        /// Skype自体が起動しているかどうかのプロパティ
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return skype.Client.IsRunning;
            }
        }

        /// <summary>
        /// Skypeとのアタッチ状況を取得するプロパティ
        /// </summary>
        public TAttachmentStatus AttachmentStatus
        {
            get
            {
                return ((ISkype)skype).AttachmentStatus;
            }
        }

        #endregion
    }
}
