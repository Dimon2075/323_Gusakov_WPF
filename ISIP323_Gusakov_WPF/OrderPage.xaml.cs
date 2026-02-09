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
using System.Xml.Linq;

namespace ISIP323_Gusakov_WPF
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            decimal sum = Core.Cart.Sum(x => x.Price);
            TotalSumTxt.Text = $"К оплате {sum} руб.";
        }
        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Пожалуйста, введи имя.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("Пожалуйста, введи email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, введите адрес.");
                return;
            }


            Orders newOrder = new Orders()
            {
                CustomerName = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
                //TotalPrice = Core.Cart.Sum(x => x.Price)
            };

            Core.Context.Orders.Add(newOrder);

            Core.Context.SaveChanges();


            MessageBox.Show($"Заказ №{newOrder.Id} успешно оформлен!");

            this.NavigationService.Navigate(new CatalogPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
