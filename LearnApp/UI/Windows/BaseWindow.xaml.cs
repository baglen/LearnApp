using LearnApp.UI.Pages;
using LearnApp.Utils;
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
using System.Windows.Shapes;

namespace LearnApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow()
        {
            InitializeComponent();
            Manager.CurrentFrame = MainFrame;
            Manager.CurrentFrame.Navigate(new ServicesPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnService.Visibility = Visibility.Visible;
                TxtUser.Visibility = Visibility.Visible;
                if (Manager.IsAdmin)
                {
                    BtnEntries.Visibility = Visibility.Visible;
                    TxtUser.Text = "Администратор";
                }
                else
                {
                    TxtUser.Text = "Клиент";
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.CurrentFrame.CanGoBack)
            {
                Manager.CurrentFrame.GoBack();
            } 
        }

        private void BtnEntries_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrentFrame.Navigate(new EntriesPage());
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrentFrame.Navigate(new ServicesPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Close();
        }
    }
}
