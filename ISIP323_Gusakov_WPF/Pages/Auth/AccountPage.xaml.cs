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

namespace ISIP323_Gusakov_WPF.Pages.Auth
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();

            if (Core.AuthUser != null)
            {
                TxtUserName.Text = Core.AuthUser.FullName;
                TxtUserPhone.Text = Core.AuthUser.Phone;

                DgAppointments.ItemsSource = Core.DB.Appointments
                    .Where(a => a.ClientID == Core.AuthUser.ID)
                    .OrderByDescending(a => a.AppointmentDateTime)
                    .ToList();

                // Загружаем заказы текущего пользователя
                DgOrders.ItemsSource = Core.DB.Orders
                    .Where(o => o.ClientID == Core.AuthUser.ID)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
        }
    }
}
