using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Growl_for_Skype_Notification
{
    public partial class FormSetting : Form
    {
        private SkypeManager skypeManager = new SkypeManager();

        private readonly static string TRAY_ICON_MESSAGE = String.Format("{0}[{1}]", System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ProductVersion);

        private readonly static string SUBKEY_STARTUP = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private static string LogPath = "";
        private static string FileName = "";

        public FormSetting()
        {
            InitializeComponent();
        }

        #region "Form Event Handler"

        private void FormSetting_Load(object sender, EventArgs e)
        {
            SetVisible(false);

            skypeManager.Initialize();
            skypeManager.CallbackSubscription(connector_NotificationCallback);
            skypeManager.ErrorResponseSubscription(connector_ErrorResponse);


            notifyIconTray.Text = TRAY_ICON_MESSAGE;

            labelVersion.Text += System.Windows.Forms.Application.ProductVersion;

            FileName = String.Format("log-{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));

            LoadSettings();
        }

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                SetVisible(false);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangeLogPath_Click(object sender, EventArgs e)
        {
            ChangeLogPath(Properties.Settings.Default.LogPath);
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelHome.Text);
        }

        private void notifyIconTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                SetVisible(!this.Visible);
            }
        }

        private void timerSkypeStatusCheck_Tick(object sender, EventArgs e)
        {
            //var status = skypeManager.AttachmentStatus;

            //var title = "情報";
            //var body = "";
            //var icon = ToolTipIcon.Info;

            //if (skypeManager.IsAttached)
            //{
            //    return;
            //}

            //switch (status)
            //{
            //    case TAttachmentStatus.apiAttachAvailable:
            //        body = "Skypeへの連携ができますが接続されていません。\n接続を試みます。";
            //        AttachSkype();
            //        break;
            //    case TAttachmentStatus.apiAttachNotAvailable:
            //        title = "警告";
            //        body = "Skypeにうまく接続できません。";
            //        icon = ToolTipIcon.Warning;
            //        break;
            //    case TAttachmentStatus.apiAttachPendingAuthorization:
            //        body = "Skype側でアプリ連携を許可してください";
            //        icon = ToolTipIcon.Warning;
            //        break;
            //    case TAttachmentStatus.apiAttachRefused:
            //        title = "エラー";
            //        body = "Skype側でアプリ連携が拒否されているようです。\nSkypeの設定画面を開き\n「詳細」→「詳細設定」と進み\n「他のプログラムからのSkypeへのアクセスを管理」から\nこのアプリケーションの連携を許可するように変更してください。";
            //        icon = ToolTipIcon.Error;
            //        break;
            //    case TAttachmentStatus.apiAttachUnknown:
            //        title = "エラー";
            //        body = "不明なエラー為Skypeへ接続することができませんでした。";
            //        icon = ToolTipIcon.Error;
            //        break;
            //}

            //notifyIconTray.BalloonTipTitle = title;
            //notifyIconTray.BalloonTipText = body;
            //notifyIconTray.BalloonTipIcon = icon;
            //notifyIconTray.ShowBalloonTip(10000);
        }

        private void checkBoxStartupRegister_CheckedChanged(object sender, EventArgs e)
        {
            ChangeStartupRegister();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void toolStripMenuItemOpenSetting_Click(object sender, EventArgs e)
        {
            SetVisible(true);
        }

        private void toolStripMenuItemAttachSkype_Click(object sender, EventArgs e)
        {
            skypeManager.AttachSkype();
        }

        private void toolStripMenuItemRegisterGrowl_Click(object sender, EventArgs e)
        {
            skypeManager.GrowlRegister();
        }

        private void toolStripMenuItemTestNotification_Click(object sender, EventArgs e)
        {
            skypeManager.TestNotification();
        }

        private void toolStripMenuItemGetAttachmentStatus_Click(object sender, EventArgs e)
        {
            var status = skypeManager.AttachmentStatus;
            MessageBox.Show(String.Format("{0}\n{1}", status.ToString(), SkypeManager.GetAttachmentStatusMessage(status)));
        }

        private void toolStripMenuItemCheckUpdate_Click(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Boolean updateAvailable = false;
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    updateAvailable = ad.CheckForUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("更新を確認中にエラーが発生しました。\nネットワークに繋がっているかを確認して再度お試しください。\n\nError:" + dde);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("アプリケーションがうまく配置されていない可能性があります。\n再インストールをお試しください。\n\nError: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("すでに更新を確認中です。\n\nError: " + ioe.Message);
                    return;
                }

                if (updateAvailable && MessageBox.Show(this, "最新版が利用できます。更新しますか？", "更新の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        ad.Update();
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        MessageBox.Show("更新をインストールできませんでした。\n更新サーバーがダウンしているかネットワークに接続していない可能性があります。\nネットワークに接続しているか確認して再度お試しください。\n\nError: " + dde.Message);
                    }
                    catch (TrustNotGrantedException tnge)
                    {
                        MessageBox.Show("更新をインストールできませんでした。\n\n\nError: " + tnge.Message);
                    }
                    if ((MessageBox.Show(this, "更新が完了しました。更新を有効にするにはアプリケーションを再起動する必要があります。再起動しますか？", "再起動の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        System.Windows.Forms.Application.Restart();
                    }

                }
            }
        }

        private void toolStripMenuItemMonitoringSkype_Click(object sender, EventArgs e)
        {
            ChangeMonitoringSkype();
        }

        #endregion

        #region "Growl"

        private void connector_NotificationCallback(Growl.Connector.Response response, Growl.Connector.CallbackData callbackData, object state)
        {
            Debug.WriteLine("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data);
            Trace.WriteLine(String.Format("{0}:{1}", DateTime.Now.ToLongTimeString(), callbackData.Data));
            if (callbackData.Result == Growl.CoreLibrary.CallbackResult.CLICK)
            {
                if (callbackData.Data != "")
                {
                    skypeManager.OpenChatWindow(callbackData.Data);
                }
            }
        }

        private void connector_ErrorResponse(Growl.Connector.Response response, object state)
        {
            MessageBox.Show(response.ErrorDescription, response.ErrorCode.ToString());
        }

        #endregion

        #region "Other"

        private void AddLog(DateTime time, string type, string name, string id, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string[] item = { date, type, name, id, message };
            listViewLog.Items.Add(new ListViewItem(item));

            using (var writer = File.AppendText(LogPath))
            {
                writer.WriteLine("{0}\t{1}\t{2}\t{3}", date, type, name, message);
            }
        }

        private void LoadSettings()
        {
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
            }

            if (!Properties.Settings.Default.IsFirstRun)
            {
                MessageBox.Show("初回起動です。\nGrowlへの登録とSkypeへの接続を行います。", "確認");
                skypeManager.GrowlRegister();
                Properties.Settings.Default.IsFirstRun = true;
                string message = "続けてログの保存場所を決定します。\nデフォルト値はアプリケーションの実行ファイルがある場所です。\n[" + System.Windows.Forms.Application.StartupPath + "]\n\n変更しますか？\n変更する場合は：OK\nデフォルト設定を利用する場合は：Cancel\n\n*後で設定画面から変更することも可能です。";
                if (MessageBox.Show(message, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    ChangeLogPath(System.Windows.Forms.Application.StartupPath);
                }
                else
                {
                    ChangeLogPath();
                }
            }

            UpdateLogPath();

            timerSkypeStatusCheck.Enabled = Properties.Settings.Default.IsMonitoringSkype;
            toolStripMenuItemMonitoringSkype.Checked = Properties.Settings.Default.IsMonitoringSkype;

            checkBoxStartupRegister.Checked = IsExistsStartupRegistryKey();
        }

        private void ChangeLogPath()
        {
            Properties.Settings.Default.LogPath = Properties.Settings.Default.LogPath == "" ? AppendBackSlash(System.Windows.Forms.Application.StartupPath) : Properties.Settings.Default.LogPath;
            Properties.Settings.Default.Save();
        }

        private void ChangeLogPath(string oldpath)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = oldpath;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.LogPath = AppendBackSlash(dialog.SelectedPath);
                }
                else
                {
                    ChangeLogPath();
                }
            }
            Properties.Settings.Default.Save();
            UpdateLogPath();
        }

        private void ChangeMonitoringSkype()
        {
            Properties.Settings.Default.IsMonitoringSkype = !Properties.Settings.Default.IsMonitoringSkype;
            Properties.Settings.Default.Save();
            timerSkypeStatusCheck.Enabled = Properties.Settings.Default.IsMonitoringSkype;
            toolStripMenuItemMonitoringSkype.Checked = Properties.Settings.Default.IsMonitoringSkype;
        }

        private string AppendBackSlash(string path)
        {
            path += path.EndsWith("\\") ? "" : "\\";
            return path;
        }

        private void UpdateLogPath()
        {
            if (Properties.Settings.Default.LogPath == "")
            {
                ChangeLogPath();
            }
            LogPath = Properties.Settings.Default.LogPath + FileName;
            textBoxLogPath.Text = Properties.Settings.Default.LogPath;
        }

        private void SetVisible(Boolean isVisible)
        {
            this.ShowInTaskbar = isVisible;
            this.Visible = isVisible;
            if (isVisible)
            {
                this.Focus();
            }
        }

        private void ChangeStartupRegister()
        {
            if (IsExistsStartupRegistryKey())
            {
                DeleteStartupRegistryKey();
            }
            else
            {
                SetStartupRegistryKey();
            }

            checkBoxStartupRegister.Checked = IsExistsStartupRegistryKey();
        }

        private bool IsExistsStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                var value = regkey.GetValue(System.Windows.Forms.Application.ProductName);
                if (value != null)
                {
                    return true;
                }
                return false;
            }
        }

        private void SetStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                regkey.SetValue(System.Windows.Forms.Application.ProductName, System.Windows.Forms.Application.ExecutablePath);
            }
        }

        private void DeleteStartupRegistryKey()
        {
            using (var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SUBKEY_STARTUP))
            {
                regkey.DeleteValue(System.Windows.Forms.Application.ProductName);
            }
        }

        #endregion
    }
}
