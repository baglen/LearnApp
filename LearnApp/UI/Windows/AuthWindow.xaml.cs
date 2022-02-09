using LearnApp.Utils;
using System.Windows;

namespace LearnApp.UI.Windows
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSignClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.IsAdmin = false;
            BaseWindow baseWindow = new BaseWindow();
            baseWindow.Show();
            this.Close();
        }

        private void BtnSign_Click(object sender, RoutedEventArgs e)
        {
            if (PasBox.Password.Equals("0000"))
            {
                MessageBox.Show("Вы успешно авторизованы", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.IsAdmin = true;
                BaseWindow baseWindow = new BaseWindow();
                baseWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неверный пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
