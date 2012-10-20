using System.Diagnostics;
using System.Windows.Forms;

using Microsoft.Win32;

using Growl_for_Skype_Notification.Properties;

namespace Growl_for_Skype_Notification
{
    public static class SettingManager
    {
        private const string RegistryStartupRunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private static readonly Settings SettingsDefault = Settings.Default;

        #region "メソッド"

        public static void LoadSettings()
        {
            if (!IsUpgrade)
            {
                SettingUpgrade();
            }

            if (IsFirstRun)
            {
                FirstRunSetting();
            }

            //timerSkypeStatusCheck.Enabled = Settings.Default.IsMonitoringSkype;
            //toolStripMenuItemMonitoringSkype.Checked = Settings.Default.IsMonitoringSkype;

            //checkBoxStartupRegister.Checked = SettingManager.IsExistsStartupRunRegistryKey;
        }

        /// <summary>
        /// 設定のアップグレードを行うメソッド
        /// </summary>
        private static void SettingUpgrade()
        {
            SettingsDefault.Upgrade();
            SettingsDefault.IsUpgrade = true;
            SettingsDefault.Save();
        }

        /// <summary>
        /// 初回起動の際の設定を行うメソッド
        /// </summary>
        private static void FirstRunSetting()
        {
            //TODO: 初回起動処理をウィザードのようなフォームを用意して実装する
            MessageBox.Show("初回起動です。\nGrowlへの登録とSkypeへの接続を行います。", Resources.Confirm);
            Settings.Default.IsFirstRun = true;
            string message = "続けてログの保存場所を決定します。\nデフォルト値はアプリケーションの実行ファイルがある場所です。\n[" + Application.StartupPath + "]\n\n変更しますか？\n変更する場合は：OK\nデフォルト設定を利用する場合は：Cancel\n\n*後で設定画面から変更することも可能です。";
            if (MessageBox.Show(message, Resources.Confirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                ChangeLogFilesPath();
            }

            SettingsDefault.IsFirstRun = false;
            SettingsDefault.Save();
        }

        /// <summary>
        /// ログファイルを保存するディレクトリを変更するメソッド
        /// </summary>
        public static void ChangeLogFilesPath()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = LogFileDirectoryPath;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsDefault.LogPath = dialog.SelectedPath;
                    SettingsDefault.Save();
                }
            }
        }

        //private static void ChangeMonitoringSkype()
        //{
            //Settings.Default.IsMonitoringSkype = !Settings.Default.IsMonitoringSkype;
            //Settings.Default.Save();
            //timerSkypeStatusCheck.Enabled = Settings.Default.IsMonitoringSkype;
            //toolStripMenuItemMonitoringSkype.Checked = Settings.Default.IsMonitoringSkype;
        //}

        #region "レジストリ操作系"

        /// <summary>
        /// レジストリのスタートアップ設定を反転させるメソッド
        /// </summary>
        public static void ToggleRegistryStartupRun()
        {
            if (IsExistsStartupRunRegistryKey)
            {
                DeleteStartupRunRegistryKey();
            }
            else
            {
                SetStartupRunRegistryKey();
            }
        }

        /// <summary>
        /// レジストリにスタートアップキーを設定するメソッド
        /// </summary>
        private static void SetStartupRunRegistryKey()
        {
            using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupRunKeyPath))
            {
                Debug.Assert(regkey != null, "SetStartupRunRegistryKey: regkey != null");
                regkey.SetValue(Application.ProductName, Application.ExecutablePath);
            }
        }

        /// <summary>
        /// レジストリに登録したスタートアップキーを削除するメソッド
        /// </summary>
        private static void DeleteStartupRunRegistryKey()
        {
            using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupRunKeyPath))
            {
                Debug.Assert(regkey != null, "DeleteStartupRunRegistryKey: regkey != null");
                regkey.DeleteValue(Application.ProductName);
            }
        }

        #endregion

        #endregion

        #region "プロパティ"

        /// <summary>
        /// レジストリにスタートアップの登録ができているかどうかを返すプロパティ
        /// </summary>
        public static bool IsExistsStartupRunRegistryKey
        {
            get
            {
                using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupRunKeyPath))
                {
                    Debug.Assert(regkey != null, "IsExistsStartupRunRegistryKey: regkey != null");
                    return (regkey.GetValue(Application.ProductName) != null);
                }
            }
        }

        /// <summary>
        /// アプリケーションが更新されているかどうかを返すプロパティ
        /// </summary>
        public static bool IsUpgrade
        {
            get { return SettingsDefault.IsUpgrade; }
        }

        /// <summary>
        /// 初回起動かどうかを返すプロパティ
        /// </summary>
        public static bool IsFirstRun
        {
            get { return SettingsDefault.IsFirstRun; }
        }

        /// <summary>
        /// アタッチ状況を監視するかの設定を表すプロパティ
        /// </summary>
        public static bool IsMonitoringSkype
        {
            get
            {
                return SettingsDefault.IsMonitoringSkype;
            }
            set
            {
                SettingsDefault.IsMonitoringSkype = value;
                SettingsDefault.Save();
            }
        }

        public static string LogFileDirectoryPath
        {
            get
            {
                return string.IsNullOrEmpty(SettingsDefault.LogPath)
                           ? Application.ExecutablePath
                           : SettingsDefault.LogPath;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) SettingsDefault.LogPath = value;
                SettingsDefault.Save();
            }
        }

        #endregion
    }
}
