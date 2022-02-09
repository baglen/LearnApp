using LearnApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace LearnApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddClientServiceWindow.xaml
    /// </summary>
    public partial class AddClientServiceWindow : Window
    {
        private Service CurrentService;
        private Dictionary<int, string> ComboData = new Dictionary<int, string>();
        public AddClientServiceWindow(Service service)
        {
            InitializeComponent();
            CurrentService = service;
            try
            {
                foreach (var row in LearnBaseEntities.GetContext().Client.ToList())
                {
                    ComboData.Add(row.ID, row.LastName + " " + row.FirstName.First() + ". " + (!String.IsNullOrWhiteSpace(row.Patronymic) ? row.Patronymic.First() + "." : ""));
                }
                ComboClient.ItemsSource = ComboData.Values;
                int minutes = service.DurationInSeconds / 60;
                TxtService.Text = service.Title + " (" + minutes + " мин)";
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComboClient.SelectedItem != null && DatePicker.Value != null)
            {
                try
                {
                    ClientService clientService = new ClientService();
                    clientService.ClientID = ComboData.FirstOrDefault(x => x.Value == ComboClient.SelectedItem.ToString()).Key;
                    clientService.ServiceID = CurrentService.ID;
                    clientService.StartTime = (DateTime)DatePicker.Value;
                    LearnBaseEntities.GetContext().ClientService.Add(clientService);
                    LearnBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка получения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DatePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Дата не может быть меньше текущей");
                DatePicker.Value = DateTime.Now.AddDays(1);
            }

        }
    }
}
