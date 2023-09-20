using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MQChat
{
    internal class GlobalData
    {
        /// <summary>
        /// 当前App的版本信息与调试信息
        /// </summary>
#if DEBUG
        private static bool IsDebugMode = true;
#else
        private static bool IsDebugMode = false;
#endif
        public static string Version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() + (Debugger.IsAttached ? " Debugger attached" : (IsDebugMode ? " Debug" : " Release"));

        /// <summary>
        /// 存储当前App实例的配置信息
        /// </summary>
        public static AppConfig? appConfig;

        /// <summary>
        /// 存储APP收到的消息
        /// </summary>
        public static BindingList<Msg> msgs = new BindingList<Msg>();

        /// <summary>
        /// 存储联系人列表
        /// </summary>
        public static BindingList<UserCustom> userCustoms = new BindingList<UserCustom>();

        /// <summary>
        /// 获取本地存储的配置信息
        /// </summary>
        public static void Init()
        {
            //读取Config
            if (File.Exists(AppConfig.SavePath))
                try
                {
                    var json = File.ReadAllText(AppConfig.SavePath);
                    appConfig = (string.IsNullOrEmpty(json) ? new AppConfig() : JsonConvert.DeserializeObject<AppConfig>(json)) ?? new AppConfig();
                }
                catch
                {
                    appConfig = new AppConfig();
                }
            else
                appConfig = new AppConfig();
        }

        /// <summary>
        /// 保存本地存储的配置信息
        /// </summary>
        public static void Save()
        {
            var json1 = JsonConvert.SerializeObject(appConfig, Formatting.Indented);
            File.WriteAllText(AppConfig.SavePath, json1);
        }
    }
}
