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

namespace ISIP323_Gusakov_WPF.Pages.Master
{
    /// <summary>
    /// Логика взаимодействия для MastreServicesPage.xaml
    /// </summary>
    public partial class MasterServicesPage : Page
    {
        public class ServiceViewModel
        {
            public int ServiceId { get; set; }
            public string ServiceName { get; set; }
            public bool IsSelected { get; set; }
        }


        public MasterServicesPage()
        {
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            var allServices = Core.DB.Services.ToList();

            // Загружаем текущего мастера вместе с его списком услуг из навигационного свойства
            var currentMaster = Core.DB.Users.FirstOrDefault(u => u.ID == Core.AuthUser.ID);

            if (currentMaster != null)
            {
                // Получаем ID услуг через навигационную коллекцию (например, Services)
                var masterServiceIds = currentMaster.Services.Select(s => s.ID).ToList();

                var viewModel = allServices.Select(s => new ServiceViewModel
                {
                    ServiceId = s.ID,
                    ServiceName = s.Name,
                    IsSelected = masterServiceIds.Contains(s.ID)
                }).ToList();

                LBoxAllServices.ItemsSource = viewModel;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = LBoxAllServices.ItemsSource as List<ServiceViewModel>;

            // Находим текущего мастера в базе со всеми его услугами
            var master = Core.DB.Users.FirstOrDefault(u => u.ID == Core.AuthUser.ID);

            if (master != null)
            {
                // 1. Очищаем старые услуги (у EF это делается через Clear у коллекции)
                master.Services.Clear();

                // 2. Добавляем новые выбранные услуги
                foreach (var item in selectedItems.Where(i => i.IsSelected))
                {
                    var serviceToAdd = Core.DB.Services.FirstOrDefault(s => s.ID == item.ServiceId);
                    if (serviceToAdd != null)
                    {
                        master.Services.Add(serviceToAdd);
                    }
                }

                try
                {
                    Core.DB.SaveChanges();
                    MessageBox.Show("Список услуг обновлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
    }
}
