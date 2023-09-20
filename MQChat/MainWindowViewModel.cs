using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MQChat
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        #region 设置Popup

        /// <summary>
        /// 设置Pop展开状态
        /// </summary>
        [ObservableProperty]
        private bool showPop = false;

        /// <summary>
        /// 展开设置Pop
        /// </summary>
        [RelayCommand]
        private void showPopClick() => ShowPop = true;

        #endregion

        /// <summary>
        /// Github按钮点击
        /// </summary>
        [RelayCommand]
        private void showGithubClick()
        {
            Process.Start(new ProcessStartInfo() { FileName = @"https://github.com/GSCmax/MQChat", UseShellExecute = true });
        }

        /// <summary>
        /// 主题切换
        /// </summary>
        /// <param name="isDark"></param>
        [RelayCommand]
        private void skinToggle(bool isDark)
        {
            (Application.Current as App)?.UpdateSkin(isDark ? SkinType.Dark : SkinType.Default);
        }
    }
}
