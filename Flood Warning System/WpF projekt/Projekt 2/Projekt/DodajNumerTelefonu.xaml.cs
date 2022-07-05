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
using System.Windows.Shapes;
using Dapper;
using Projekt.efcore;
using Projekt.Models;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy DodajNumerTelefonu.xaml
    /// </summary>
    public partial class DodajNumerTelefonu : Window
    {

        public DodajNumerTelefonu()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel
            {
               NumerTelefonuDN = "000-000-000"
            };
           
            ListaMiejscowosciViewModelu();
        }
       
        public async void ListaMiejscowosciViewModelu()
        {
          
            var readDataBase = new ReadDataBase();
            List<string> ListaMiejscowosci = new List<string>();
            var resoult = await readDataBase.GetLocalityCollection();
            foreach (var item in resoult )
            {
                ListaMiejscowosci.Add(item.Miejscowosc);
            }
            ListBoxMiejsc.ItemsSource = ListaMiejscowosci;//tutaj tez popraw usun liste
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var write = new DataBase();
            var powiadomienieSMS = new PowiadomienieSm();

            List<int> listValidationErrors = new List<int>();

            listValidationErrors.Add( Validation.GetErrors(TextNumerTelefonuDN).Count);
            listValidationErrors.Add( Validation.GetErrors(TextMiastoDN).Count);
            listValidationErrors.Add( Validation.GetErrors(TextStanDN).Count);
            var collections = listValidationErrors.Where(x => x == 0).ToList();

           
            
            if ((collections.Count == listValidationErrors.Count) && (ListBoxMiejsc.SelectedItem.ToString().Any() == true))
            {
                var ViewModel = (RegistrationViewModel)DataContext;

                powiadomienieSMS.NumerTelefonu = ViewModel.NumerTelefonuDN;
                powiadomienieSMS.Miasto = ViewModel.MistoDN;
                powiadomienieSMS.StanZagrozenia = ViewModel.StanZagrożeniaDN;

                
                var readDataBase = new ReadDataBase();
                bool resoultResarhNumber = await readDataBase.BaseGetPhoneKey(powiadomienieSMS.NumerTelefonu);
                
                powiadomienieSMS.Miejscowosc = ListBoxMiejsc.SelectedItem.ToString();
                bool resoultResarhLocality = await readDataBase.BaseGetMeasureResreahef(powiadomienieSMS.Miejscowosc);

                if (resoultResarhNumber == true)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine($"W bazie znajduję się już numer: {powiadomienieSMS.NumerTelefonu}");
                    MessageBox.Show(builder.ToString());     
                }

                else if(resoultResarhLocality)
                {

                    await write.WriteDataBaseNumerTelefonu(powiadomienieSMS);
                    MessageBox.Show("Dodano numer do bazy ;-)");
                }

              
            }
            else
                MessageBox.Show("Wypełnij wszystkie pola oraz zaznacz miejscowość!");
        }
    }
   
}
