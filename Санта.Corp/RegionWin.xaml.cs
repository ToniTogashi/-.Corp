using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Санта.Corp
{
    /// <summary>
    /// Логика взаимодействия для RegionWin.xaml
    /// </summary>
    public partial class RegionWin : Window, INotifyPropertyChanged
    {
        private Region selectedRegion;

         Region SelectedRegion
        {
            get => selectedRegion;
            set
            {
                selectedRegion = value;
                Signal();
            }
        }
        ObservableCollection<Region> Regions
        {
            get => Data.Regions;
        }
         ObservableCollection<Special> Specials
        {
            get => Data.Specials;
        }
         ObservableCollection<Deer> Deers
        {
            get => Data.Deers;
        }
        public RegionWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        

        private void DeleteRegion(object sender, RoutedEventArgs e)
        {
            if (SelectedRegion == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный регион?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Regions.Remove(SelectedRegion);
            }
        }

        private void AddRegion(object sender, RoutedEventArgs e)
        {
            Region.Add(new Region { Title = "Новый регион" });
        }
    }
}