using System;
using System.Windows.Forms;

using Growl_for_Skype_Notification.Properties;

namespace Growl_for_Skype_Notification
{
    public partial class FormFirstRun : Form
    {
        public FormFirstRun()
        {
            InitializeComponent();
        }

        private void FormFirstRunLoad(object sender, EventArgs e)
        {
            textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
            checkBoxMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;
            checkBoxStartup.Checked = SettingManager.IsExistsStartupRunRegistryKey;

            buttonLogPathChange.Click +=
                (obj, args) => 
                    {
                        SettingManager.ChangeLogFilesPath();
                        textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
                    };
            buttonClose.Click +=
                (obj, args) =>
                    {
                        Close();
                    };

            checkBoxMonitoringSkype.CheckedChanged +=
                (obj, args) =>
                    {
                        SettingManager.ToggleIsMonitoringSkype();
                    };
            checkBoxStartup.CheckedChanged +=
                (obj, args) =>
                    {
                        SettingManager.ToggleRegistryStartupRun();
                    };
        }
    }
}
