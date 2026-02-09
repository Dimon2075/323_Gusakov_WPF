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
            Orders newOrder = new Orders()
            {
                CustomerName = TxtName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
                //TotalPrice = Core.Cart.Sum(x => x.Price)
            };

            Core.Context.Orders.Add(newOrder);

            foreach (var item in Core.Cart)
            {
                Cart newCartItem = new Cart()
                {
                    ProductId = item.Id,
                    OrderId = newOrder.Id
                };
                Core.Context.Cart.Add(newCartItem);
            }


            MessageBox.Show($"Заказ №1 успешно оформлен!");

            Core.Cart.Clear();
            this.NavigationService.Navigate(new CatalogPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
