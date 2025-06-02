using ECDL_Megoldas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECDL_Megoldas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        readonly AppContext appContext = new AppContext();
        public ObservableCollection<Vizsgazo> Vizsgazok { get; set; }
        public ObservableCollection<Vizsgatipus> Vizsgatipusok { get; set; }
        public Vizsgazo SelectedVizsgazo { get; set; }

        private Vizsgazo newVizsgazo = new Vizsgazo();
        public Vizsgazo NewVizsgazo

        {
            get { return newVizsgazo; }
            set { newVizsgazo = value; OnPropertyChanged(nameof(NewVizsgazo)); }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            appContext.Vizsgazok.Load();
            appContext.Vizsgatipus.Load();
            Vizsgazok = appContext.Vizsgazok.Local.ToObservableCollection();
            Vizsgatipusok = appContext.Vizsgatipus.Local.ToObservableCollection();
        }

        private void del_BTN_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedVizsgazo != null)
            {
                if(MessageBox.Show($"Biztosan törölni kívánja a(z) {SelectedVizsgazo.Nev} nevű vizsgázót?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Vizsgazok.Remove(SelectedVizsgazo);
                    appContext.SaveChanges();
                }
            }
        }

        private void save_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck())
            {
                Vizsgazok.Add(NewVizsgazo);
                appContext.SaveChanges();
                NewVizsgazo = new Vizsgazo();
            }
        }

        private bool InputCheck()
        {
            if (String.IsNullOrWhiteSpace(NewVizsgazo.Nev))
            {
                MessageBox.Show("A név megadása kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(NewVizsgazo.Vizsgatipus == null)
            {
                MessageBox.Show("A vizsgatípus megadása kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (NewVizsgazo.Eredmeny == null || NewVizsgazo.Eredmeny < 0 || NewVizsgazo.Eredmeny > 100)
            {
                MessageBox.Show("Az eredmény csak egész érték lehet és 0 és 100 közé eshet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }

    }
}