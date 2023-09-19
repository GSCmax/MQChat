using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQChat
{
    internal class GlobalData
    {
        /// <summary>
        /// 存储我的ID
        /// </summary>
        public static Guid myGuid;

        /// <summary>
        /// 存储我的名字
        /// </summary>
        public static string? myName = "TestUser0";

        /// <summary>
        /// 存储APP收到的消息
        /// </summary>
        public static BindingList<Msg> msgs = new BindingList<Msg>();

        /// <summary>
        /// 存储联系人列表
        /// </summary>
        public static BindingList<UserCustom> userCustoms = new BindingList<UserCustom>();
    }
}
