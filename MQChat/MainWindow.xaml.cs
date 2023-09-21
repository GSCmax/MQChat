using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i < 6; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestUser" + i, Type = UserType.user, UserID = Guid.NewGuid() });
            }

            for (int i = 1; i < 6; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestGroup" + i, Type = UserType.group, UserID = Guid.NewGuid() });
            }

            Guid t = Guid.NewGuid();
            GlobalData.userCustoms.Add(new UserCustom() { CustomNickname = "TestUser_Send", Type = UserType.user, UserID = t });
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
}
