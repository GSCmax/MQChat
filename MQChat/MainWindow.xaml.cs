using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MQChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            for (short i = 0; i < 5; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestUser" + i, Type = UserType.user, UserID = Guid.NewGuid(), NewMsgCount = i });
            }

            for (short i = 0; i < 5; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestGroup" + i, Type = UserType.group, UserID = Guid.NewGuid(), NewMsgCount = i });
            }

            Guid t = Guid.NewGuid();
            GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestUser_Send", Type = UserType.user, UserID = t, NewMsgCount = 99 });
            GlobalData.msgs.Add(new Msg() { MsgContent = "TestMsg", UserID = t });
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            msgListBox.ItemsSource = GlobalData.msgs.Where(m => m.UserID == ((sender as ListBox)!.SelectedItem as UserCustom)!.UserID);
        }
    }

    public class OneBooleanToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (object obj in values)
                if (obj is bool)
                    if ((bool)obj)
                        return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToWatermarkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value + "🤣 ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UserTypeToEmojiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((UserType)value)
            {
                case UserType.user:
                    return "😀";
                case UserType.group:
                    return "👪";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NewMsgCountToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((short)value > 0)
                return value;
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
