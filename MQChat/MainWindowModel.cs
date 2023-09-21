using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQChat
{
    /// <summary>
    /// 用户对象类型 个人or群
    /// </summary>
    enum UserType
    {
        user,
        group,
    }

    /// <summary>
    /// 消息类型 接收or发送
    /// </summary>
    enum MsgType
    {
        receive,
        send,
    }

    /// <summary>
    /// 消息内容类型 普通聊天、好友申请、加群申请
    /// </summary>
    enum MsgContentType
    {
        chat,
        userRequest,
        groupRequest,
    }

    internal class MainWindowModel
    {
    }

    internal partial class Msg : ObservableObject
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [ObservableProperty]
        private MsgType msgType;

        [ObservableProperty]
        private MsgContentType msgContentType;

        /// <summary>
        /// 消息类型为接收时，该属性为发送人ID；消息类型为发送时，该属性为接收人ID；
        /// </summary>
        [ObservableProperty]
        private Guid userID;

        /// <summary>
        /// 消息ID
        /// </summary>
        [ObservableProperty]
        private Guid msgID;

        /// <summary>
        /// 消息发送时间
        /// </summary>
        [ObservableProperty]
        private DateTime msgTime;

        /// <summary>
        /// 消息内容
        /// </summary>
        [ObservableProperty]
        private string? msgContent;
    }

    internal partial class UserCustom : ObservableObject
    {
        /// <summary>
        /// 用户对象类型
        /// </summary>
        [ObservableProperty]
        private UserType type;

        /// <summary>
        /// 用户ID
        /// </summary>
        [ObservableProperty]
        private Guid userID;

        /// <summary>
        /// 自定义昵称
        /// </summary>
        [ObservableProperty]
        private string? customNickname;
    }

    internal class AppConfig
    {
        /// <summary>
        /// 配置文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}Config.json";

        /// <summary>
        /// 使用暗色主题
        /// </summary>
        public bool UseDarkTheme { get; set; } = false;

        /// <summary>
        /// 本机昵称
        /// </summary>
        public string SelfNickname { get; set; } = "新的朋友";

        /// <summary>
        /// 本机ID
        /// </summary>
        public Guid SelfID { get; set; } = Guid.NewGuid();
    }
}
