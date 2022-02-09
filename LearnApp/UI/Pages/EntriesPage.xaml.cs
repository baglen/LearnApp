using LearnApp.Entites;
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

namespace LearnApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для EntriesPage.xaml
    /// </summary>
    public partial class EntriesPage : Page
    {
        public EntriesPage()
        {
            InitializeComponent();
            startTimerAsync(5);
        }

        async void startTimerAsync(int days)
        {
            var time = DateTime.Now + TimeSpan.FromDays(days);
            while (DateTime.Now < time)
            {
                Update();
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }
        private void Update()
        {
            try
            {
                var temp = LearnBaseEntities.GetContext().ClientService.Where(p => p.StartTime >= DateTime.Now).ToList();
                List<ClientServiceModel> data = new List<ClientServiceModel>();
                foreach (ClientService clientService in temp)
                {
                    data.Add(clientService.ToClientServiceModel());
                }
                DGridEntries.ItemsSource = data;
                if (data.Count == 0)
                {
                    DGridEntries.Visibility = Visibility.Collapsed;
                    TxtNoData.Visibility = Visibility.Visible;
                }
                else
                {
                    DGridEntries.Visibility = Visibility.Visible;
                    TxtNoData.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                DGridEntries.Visibility = Visibility.Collapsed;
                TxtNoData.Visibility = Visibility.Visible;
            }
        }
    }
}
