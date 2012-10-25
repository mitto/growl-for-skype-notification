using System;
using System.Diagnostics;
using System.Windows.Forms;

using Growl_for_Skype_Notification.Properties;

namespace Growl_for_Skype_Notification
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSettingLoad(object sender, EventArgs e)
        {
            RegisterEventHandler();
            RefreshSettingForm();
        }

        /// <summary>
        /// 簡単なイベントハンドラーを登録するメソッド
        /// </summary>
        private void RegisterEventHandler()
        {
            SettingManager.ChangeIsMonitoringSkype += (sender, e) => checkBoxMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;;
            SettingManager.ChangeRegistryStartupRun += (sender, e) => checkBoxStartupRegister.Checked = SettingManager.IsExistsStartupRunRegistryKey;

            buttonChangeLogPath.Click +=
                (sender, e) =>
                    {
                        SettingManager.ChangeLogFilesPath();
                        textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
                    };

            checkBoxStartupRegister.Click += (sender, e) => SettingManager.ToggleRegistryStartupRun();

            linkLabelHome.LinkClicked += (sender, e) => Process.Start(linkLabelHome.Text);
        }

        #endregion

        #region "Other"

        private void RefreshSettingForm()
        {
            labelVersion.Text += Application.ProductVersion;
            textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;

            checkBoxMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;
        }

        #endregion
    }
}
