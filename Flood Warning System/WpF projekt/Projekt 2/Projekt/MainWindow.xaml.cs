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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click1_Click(object sender, RoutedEventArgs e)
        {
            var dodajObszar = new DodajObszar();
            dodajObszar.Show();
        }

        private void Click3_Click(object sender, RoutedEventArgs e)
        {
            var powiadomSMS = new PowiadomieniaSMS();
            powiadomSMS.ShowDialog();
        }

        private void Clikc2_Click(object sender, RoutedEventArgs e)
        {
            DodajNumerTelefonu dodajNumerTelefonu = new DodajNumerTelefonu();
            dodajNumerTelefonu.ShowDialog();
        }
    }
}
