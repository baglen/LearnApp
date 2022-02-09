using LearnApp.Entites;
using LearnApp.Utils;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LearnApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private ServiceModel CurrentService;
        public AddEditServicePage(ServiceModel service)
        {
            InitializeComponent();
            CurrentService = new ServiceModel();
            if (service != null)
                CurrentService = service;
            DataContext = CurrentService.ToServiceEntities();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (String.IsNullOrWhiteSpace(CurrentService.Title))
                stringBuilder.AppendLine("Введите название услуги");
            if (CurrentService.Cost <= 0)
                stringBuilder.AppendLine("Введите стоимость");
            if (CurrentService.DurationInMinute <= 0)
                stringBuilder.AppendLine("Введите продолжительность занятия");
            if (stringBuilder.Length != 0)
            {
                MessageBox.Show(stringBuilder.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                if (CurrentService.ID == 0)
                    LearnBaseEntities.GetContext().Service.Add(CurrentService.ToServiceEntities());
                DataContext = CurrentService.ToServiceEntities();
                LearnBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.CurrentFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
