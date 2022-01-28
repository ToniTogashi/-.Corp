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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Санта.Corp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Worker selectedWorker;

         ObservableCollection<Worker> Workers
        {
            get => Data.Workers;
        }
         ObservableCollection<Region> Regions
        {
            get => Data.Regions;
        }

        
         Worker SelectedWorker
        {
            get => selectedWorker;
            set
            {
                selectedWorker = value;
                Signal();
            }
        }

        public MainWindow()
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

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            Workers.Add(new Worker
            {
                LastName = "Новый работник",
                Birthday = DateTime.Today
            });
        }

        private void DeleteWorker(object sender, RoutedEventArgs e)
        {
            if (SelectedWorker == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного работника?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Workers.Remove(SelectedWorker);
                SelectedWorker = null;
            }
        }

        private void OpenSpecials(object sender, RoutedEventArgs e)
        {
            SpecialWin win = new SpecialWin();
            win.ShowDialog();
        }

        private void OpenRegions(object sender, RoutedEventArgs e)
        {
            RegionWin win = new RegionWin();
            win.ShowDialog();
        }

        private void OpenDeers(object sender, RoutedEventArgs e)
        {
            DeerWin win = new DeerWin();
            win.ShowDialog();
        }
    }
}
