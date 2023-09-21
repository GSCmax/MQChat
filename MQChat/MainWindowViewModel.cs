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
        /// <summary>
        /// Github按钮点击
        /// </summary>
        [RelayCommand]
        private void showGithubClick()
        {
            Process.Start(new ProcessStartInfo() { FileName = @"https://github.com/GSCmax/MQChat", UseShellExecute = true });
        }

        #region 设置Popup
        /// <summary>
        /// 设置Pop展开状态
        /// </summary>
        [ObservableProperty]
        private bool showSettingPop = false;

        /// <summary>
        /// 展开设置Pop
        /// </summary>
        [RelayCommand]
        private void showSettingPopClick() => ShowSettingPop = true;
        #endregion

        /// <summary>
        /// 主题切换
        /// </summary>
        /// <param name="isDark"></param>
        [RelayCommand]
        private void skinToggle(bool isDark)
        {
            (Application.Current as App)?.UpdateSkin(isDark ? SkinType.Dark : SkinType.Default);
        }

        #region 添加Pop
        /// <summary>
        /// 添加Pop展开状态
        /// </summary>
        [ObservableProperty]
        private bool showAddPop = false;

        /// <summary>
        /// 展开添加Pop
        /// </summary>
        [RelayCommand]
        private void showAddPopClick() => ShowAddPop = true;
        #endregion

        #region 添加好友遮罩
        /// <summary>
        /// 添加好友遮罩展开状态
        /// </summary>
        [ObservableProperty]
        private bool showAddUserMask = false;

        /// <summary>
        /// 展开添加好友遮罩
        /// </summary>
        [RelayCommand]
        private void showAddUserMaskClick()
        {
            ShowAddPop = false;
            ShowAddUserMask = true;
        }
        #endregion

        /// <summary>
        /// 关闭添加好友遮罩
        /// </summary>
        [RelayCommand]
        private void closeAddUserMaskClick() => ShowAddUserMask = false;

        #region 创建群聊遮罩展
        /// <summary>
        /// 创建群聊遮罩展开状态
        /// </summary>
        [ObservableProperty]
        private bool createGroupMask = false;

        /// <summary>
        /// 创建群聊好友遮罩
        /// </summary>
        [RelayCommand]
        private void createGroupMaskClick()
        {
            ShowAddPop = false;
            CreateGroupMask = true;
        }
        #endregion
    }
}
