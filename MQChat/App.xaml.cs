using HandyControl.Data;
using HandyControl.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MQChat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GlobalData.Init();

            if (GlobalData.appConfig.UseDarkTheme)
                UpdateSkin(SkinType.Dark);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            GlobalData.Save();
        }

        internal void UpdateSkin(SkinType skin)
        {
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(ResourceHelper.GetSkin(skin));
            Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml") });

            Current.MainWindow?.OnApplyTemplate();
        }
    }
}
