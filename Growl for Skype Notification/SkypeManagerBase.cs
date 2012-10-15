using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using SKYPE4COMLib;

namespace Growl_for_Skype_Notification
{
    public class SkypeManagerBase
    {
        #region "変数"

        protected Skype skype;

        private Dictionary<string, Bitmap> userAvatarDictonary = new Dictionary<string, Bitmap>();

        #endregion

        #region "定数"

        #endregion

        #region "メソッド"

        #region "コンストラクタ"

        public SkypeManagerBase()
        {
            skype = new Skype();
        }

        #endregion

        #region "Skype操作系"

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
        /// Skypeへ接続する
        /// </summary>
        /// <param name="protocol">接続する際に使うプロトコルバージョン</param>
        /// <param name="wait">接続が完了するまで処理を待つか待たないか</param>
        public void AttachSkype(int protocol = 7, bool wait = false)
        {
            skype.Attach(protocol, wait);
            InitializeUserAvatars();
        }

        /// <summary>
        /// 特定のチャットウィンドウを開くためのメソッド
        /// </summary>
        /// <param name="chatId">skypeIDまたはchatIdを指定</param>
        public void OpenChatWindow(string chatId)
        {
            skype.Chat[chatId].OpenWindow();
        }

        /// <summary>
        /// 指定したユーザーのアバター画像を指定したパスに出力するようSkype側にコマンドを送るメソッド
        /// </summary>
        /// <param name="userId">取得したいユーザーのSkypeId</param>
        /// <param name="path">
        /// アバター画像の一時保存先(ディレクトリ名)
        /// 
        /// * 何も指定しなければシステムの一時保存領域へ画像を出力させます。
        /// </param>
        public void PublicationGetUserAvatarCommand(string userId, string path = "")
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Path.GetTempPath();
            }

            path = Path.Combine(path, "avatarimage");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = userId + ".jpg";

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                    //TODO: エラーログなどへの出力
                    return;
                }
            }
            string commandline = String.Format("GET USER {0} AVATAR 1 {1}", userId, path);
            var command = skype.get_Command(DateTime.Now.Millisecond, commandline);
            skype.SendCommand(command);
        }

        #endregion

        #region "メッセージ生成系"

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

        /// <summary>
        /// TOnlineStatusを渡すと該当する状態メッセージを返すメソッド
        /// </summary>
        /// <param name="status">取得したいTOnlineStatus</param>
        /// <returns>ユーザーオンライン状態の状態メッセージ</returns>
        public static string GetOnlineStatusMessage(TOnlineStatus status)
        {
            switch (status)
            {
                case TOnlineStatus.olsAway:
                    return "一時退席中";
                case TOnlineStatus.olsDoNotDisturb:
                    return "取り込み中";
                case TOnlineStatus.olsNotAvailable:
                    return "退席中";
                case TOnlineStatus.olsOffline:
                    return "オフライン";
                case TOnlineStatus.olsOnline:
                    return "オンライン";
                case TOnlineStatus.olsSkypeMe:
                    return "SkypeMe";
                case TOnlineStatus.olsSkypeOut:
                    return "SkypeOut";
                case TOnlineStatus.olsUnknown:
                    return "不明 or 未知";
            }
            return "";
        }

        #endregion

        #region "アバター系"

        /// <summary>
        /// 指定されたユーザーのアバター画像を返すメソッド
        /// </summary>
        /// <param name="userId">アバターを取得したいユーザーのSkypeID</param>
        /// <returns>見つかった場合はアバター画像が、見つからなかった場合はnullが返ります。</returns>
        public Image GetUserAvatar(string userId)
        {
            if (userAvatarDictonary.ContainsKey(userId))
            {
                return userAvatarDictonary[userId];
            }
            return null;
        }

        /// <summary>
        /// 指定したユーザーのアバター画像が存在しているかいないかを返すメソッド
        /// </summary>
        /// <param name="userId">存在を確認したいSkypeID</param>
        /// <returns>利用可能な場合はtrue、不可能の場合はfalseを返します</returns>
        public bool ExistsUserAvatar(string userId)
        {
            return userAvatarDictonary.ContainsKey(userId);
        }

        private void UserAvatarImageRegister(string userId, string path)
        {
            if (ExistsUserAvatar(userId))
            {
                userAvatarDictonary.Remove(userId);
        	}

            try
            {
                using (var image = Image.FromFile(path))
                {
                    userAvatarDictonary.Add(userId, new Bitmap(image));
                }
            }
            catch (OutOfMemoryException)
            {
                //TODO: エラーログなどへの出力
            }
            catch (FileNotFoundException)
            {
                //TODO: エラーログなどへの出力
            }
            catch (ArgumentException)
            {
                //TODO: エラーログなどへの出力
            }
        }

        public void InitializeUserAvatars()
        {
            if (!IsAttached)
            {
                return;
            }

            foreach (User user in skype.Friends)
            {
                PublicationGetUserAvatarCommand(user.Handle); 
            }
        }

        #endregion

        #region "イベントハンドラ系"

        private void skype_Reply(Command pCommand)
        {
            Debug.WriteLine("{0}:{1}", "Command", pCommand.Command);
            Debug.WriteLine("{0}:{1}", "Reply", pCommand.Reply);

            var splitReply = pCommand.Reply.Split(' ');

            switch (splitReply[1].ToLower())
            {
                case "user":
                    switch (splitReply[3].ToLower())
                   	{
                        case "avatar":
                            var id = splitReply[2];
                            var path = splitReply[5];
                            UserAvatarImageRegister(id, path);
                            break;
	                }
                    break;
            }
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

        /// <summary>
        /// Skypeとのアタッチが完了しているかどうかのプロパティ
        /// </summary>
        public bool IsAttached
        {
            get
            {
                return ((ISkype)skype).AttachmentStatus == TAttachmentStatus.apiAttachSuccess;
            }
        }

        /// <summary>
        /// 現在SkypeにログインしているSkype IDを返すプロパティ
        /// アタッチが済んでいない場合は空の文字列を返す
        /// </summary>
        public string CurrentUserHandle
        {
            get
            {
                return IsAttached ? skype.CurrentUserHandle : "";
            }
        }

        /// <summary>
        /// 現在ログインしているユーザーがオフラインかどうかを返すプロパティ
        /// </summary>
        public bool IsOffline
        {
            get
            {
                return skype.CurrentUser.OnlineStatus == TOnlineStatus.olsOffline;
            }
        }

        #endregion
    }
}
