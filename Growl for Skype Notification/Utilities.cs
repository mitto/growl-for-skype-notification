using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                bool updateAvailable = false;
                var ad = ApplicationDeployment.CurrentDeployment;

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

                if (updateAvailable && MessageBox.Show("最新版が利用できます。更新しますか？", "更新の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                    if ((MessageBox.Show("更新が完了しました。更新を有効にするにはアプリケーションを再起動する必要があります。再起動しますか？", "再起動の確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }

                }
            }
        }
    }
}
