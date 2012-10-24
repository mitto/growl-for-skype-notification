using System;
using System.Deployment.Application;
using System.Windows.Forms;
using Growl_for_Skype_Notification.Properties;

namespace Growl_for_Skype_Notification
{
    public static class Utilities
    {
        /// <summary>
        /// 最新バージョンが発行されているかを調べ可能であれば更新を行うメソッド
        /// 
        /// * 現状はClickOnce版のみの対応
        /// </summary>
        public static void CheckNewDeployment()
        {
            //TODO: 最新版の確認もフォームを用意するなりしてわかりやすく状況を表示できるようにする
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                bool updateAvailable;
                var ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    updateAvailable = ad.CheckForUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show(Resources.DeploymentDownloadExceptionMessage + dde, Resources.Error);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show(Resources.InvalidDeploymentExceptionMessage + ide.Message, Resources.Error);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(Resources.InvalidOperationExceptionMessage + ioe.Message, Resources.Error);
                    return;
                }

                if (updateAvailable && MessageBox.Show(Resources.UpdateConfirmMessage, Resources.Error, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ad.Update();
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        MessageBox.Show(Resources.DeploymentDownloadExceptionMessage + dde.Message, Resources.Error);
                    }
                    catch (TrustNotGrantedException tnge)
                    {
                        MessageBox.Show(Resources.TrustNotGrantedExceptionMessage + tnge.Message, Resources.Error);
                    }
                    if ((MessageBox.Show(Resources.CompleteAndRestartRequestMessage, Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }

                }
                else
                {
                    MessageBox.Show("利用可能な更新はありません。", Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void AboutSoftware()
        {
            var body = Application.ProductName + "\n\n";
            body += "Version: " + Application.ProductVersion + "\n";
            body += "Developer: mitto\n";

            MessageBox.Show(body, Resources.ThisApplication, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
