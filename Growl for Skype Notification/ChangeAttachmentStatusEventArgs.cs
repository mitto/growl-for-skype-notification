using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SKYPE4COMLib;

namespace Growl_for_Skype_Notification
{
    /// <summary>
    /// Attachmentステータスを監視するイベント発生時に使われるクラス
    /// </summary>
    public class ChangeAttachmentStatusEventArgs : EventArgs
    {
        private TAttachmentStatus _beforeAttachmentStatus;
        private TAttachmentStatus _afterAttachmentStatus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="before">変更前のAttachmentStatus</param>
        /// <param name="now">変更後のAttachmentStatus</param>
        public ChangeAttachmentStatusEventArgs(TAttachmentStatus before, TAttachmentStatus after)
        {
            _beforeAttachmentStatus = before;
            _afterAttachmentStatus = after;
        }

        /// <summary>
        /// 変更前のアタッチメントステータスを表すプロパティ
        /// </summary>
        public TAttachmentStatus BeforeAttachmentStatus
        {
            get
            {
                return _beforeAttachmentStatus;
            }
        }

        /// <summary>
        /// 変更後のアタッチメントステータスを表すプロパティ
        /// </summary>
        public TAttachmentStatus AfterAttachmentStatus
        {
            get
            {
                return _afterAttachmentStatus;
            }
        }
    }
}
