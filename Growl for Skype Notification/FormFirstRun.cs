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

            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            buttonLogPathChange.Click +=
                (sender, e) => 
                    {
                        SettingManager.ChangeLogFilesPath();
                        textBoxLogPath.Text = SettingManager.LogFileDirectoryPath;
                    };
            buttonClose.Click += (sender, e) => Close();

            checkBoxMonitoringSkype.Click += (sender, e) => SettingManager.ToggleIsMonitoringSkype();
            checkBoxStartup.Click += (sender, e) => SettingManager.ToggleRegistryStartupRun();

            SettingManager.ChangeIsMonitoringSkype += (sender, e) => checkBoxMonitoringSkype.Checked = SettingManager.IsMonitoringSkype;
            SettingManager.ChangeRegistryStartupRun += (sender, e) => checkBoxStartup.Checked = SettingManager.IsExistsStartupRunRegistryKey;
        }
    }
}
