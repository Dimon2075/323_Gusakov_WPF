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
using System.Collections.ObjectModel;

namespace ISIP323_Gusakov_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuilderPage.xaml
    /// </summary>
    public partial class BuilderPage : Page
    {
        private ObservableCollection<basepart> _buildParts = new ObservableCollection<basepart>();

        public BuilderPage()
        {
            InitializeComponent();
            LvCart.ItemsSource = _buildParts;
            LoadData();
        }

    }
}
