using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace Growl_for_Skype_Notification
{
    public static class SettingManager
    {
        private readonly static string RegistryStartupKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void ChangeStartupRegister()
        {
            if (IsExistsStartupRegistryKey())
            {
                DeleteStartupRegistryKey();
            }
            else
            {
                SetStartupRegistryKey();
            }
        }

        public static bool IsExistsStartupRegistryKey()
        {
            using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupKeyPath))
            {
                var value = regkey.GetValue(Application.ProductName);
                if (value != null)
                {
                    return true;
                }
                return false;
            }
        }

        public static void SetStartupRegistryKey()
        {
            using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupKeyPath))
            {
                regkey.SetValue(Application.ProductName, Application.ExecutablePath);
            }
        }

        public static void DeleteStartupRegistryKey()
        {
            using (var regkey = Registry.CurrentUser.OpenSubKey(RegistryStartupKeyPath))
            {
                regkey.DeleteValue(Application.ProductName);
            }
        }
    }
}
