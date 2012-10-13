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

        #endregion
    }
}
