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
using System.Data.Entity;

namespace ISIP323_Gusakov_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для SavePage.xaml
    /// </summary>
    public partial class SavePage : Page
    {
        public SavePage()
        {
            InitializeComponent();
            LoadSaveBuilds();
        }
        private void LoadSaveBuilds()
        {
            using (var db = new Entities4())
            {
                SaveBuilds.ItemsSource = db.assembly.ToList();
            }
        }
        private void SaveBuilds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SaveBuilds.SelectedItem is assembly selected)
            {
                TbAuthor.Text = $"Автор сборки: {selected.author}";

                using (var db = new Entities4())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    var links = db.partassembly
                                  .Where(pa => pa.assemblyid == selected.id)
                                  .Include(pa => pa.basepart)
                                  .ToList();

                    var finalParts = new List<basepart>();
                    foreach (var link in links)
                    {
                        var part = link.basepart;


                        db.Entry(part).Reference(p => p.cpu).Load();
                        db.Entry(part).Reference(p => p.gpu).Load();
                        db.Entry(part).Reference(p => p.motherboard).Load();
                        db.Entry(part).Reference(p => p.ram).Load();
                        db.Entry(part).Reference(p => p.powersupply).Load();
                        db.Entry(part).Reference(p => p.storagedevice).Load();
                        db.Entry(part).Reference(p => p.processorcooler).Load();

                        finalParts.Add(part);
                    }
                    SaveBuildsParts.ItemsSource = finalParts;
                }
            }
        }
    }
}
