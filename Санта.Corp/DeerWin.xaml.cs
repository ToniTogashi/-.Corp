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
    /// Логика взаимодействия для DeerWin.xaml
    /// </summary>
    public partial class DeerWin : Window, INotifyPropertyChanged
    {
        private Deer selectedDeer;

         Deer SelectedDeer
        {
            get => selectedDeer;
            set
            {
                selectedDeer = value;
                Signal();
            }
        }

        ObservableCollection<Deer> Deers
        {
            get => Data.Deers;
        }
        public DeerWin()
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

        private void AddDeer(object sender, RoutedEventArgs e)
        {
            Deers.Add(new Deer { Name = "Имя" });
        }

        private void DeleteDeer(object sender, RoutedEventArgs e)
        {
            if (SelectedDeer == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного оленя?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Deers.Remove(SelectedDeer);
            }
        }
    }
}
