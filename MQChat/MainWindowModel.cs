using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQChat
{
    enum UserType
    {
        user,
        group,
    }

    enum MsgType
    {
        receive,
        send,
    }

    internal class MainWindowModel
    {
    }

    internal partial class Msg : ObservableObject
    {
        [ObservableProperty]
        private MsgType msgType;

        [ObservableProperty]
        private Guid userID;

        [ObservableProperty]
        private Guid msgID;

        [ObservableProperty]
        private DateTime msgTime;

        [ObservableProperty]
        private string? msgContent;
    }

    internal partial class UserCustom : ObservableObject
    {
        [ObservableProperty]
        private UserType type;

        [ObservableProperty]
        private Guid userID;

        [ObservableProperty]
        private string? customName;
    }
}
