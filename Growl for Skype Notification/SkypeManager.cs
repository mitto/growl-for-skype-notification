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
