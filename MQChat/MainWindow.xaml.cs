using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i < 6; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomName = "TestUser" + i, Type = UserType.user, UserID = Guid.NewGuid() });
            }

            for (int i = 1; i < 6; i++)
            {
                GlobalData.userCustoms.Add(new UserCustom() { CustomName = "TestGroup" + i, Type = UserType.group, UserID = Guid.NewGuid() });
            }

            Guid t = Guid.NewGuid();
            GlobalData.userCustoms.Add(new UserCustom() { CustomName = "TestUser_Send", Type = UserType.user, UserID = t });
            GlobalData.msgs.Add(new Msg() { MsgContent = "TestMsg", UserID = t });
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //GlobalData.showMsgs!.Clear();
            //var temp = GlobalData.msgs.Where(m => m.UserID == ((sender as ListBox)!.SelectedItem as UserCustom)!.UserID);
            //if (temp.Count() > 0)
            //    foreach (var item in temp)
            //        GlobalData.showMsgs.Add(item);
            msgListBox.ItemsSource = GlobalData.msgs.Where(m => m.UserID == ((sender as ListBox)!.SelectedItem as UserCustom)!.UserID);
        }
    }
}
