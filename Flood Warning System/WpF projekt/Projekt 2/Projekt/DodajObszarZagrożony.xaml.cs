using Projekt.Models;
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
using Projekt.efcore;
using Dapper;


namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy DodajObszar.xaml
    /// </summary>
    /// 

    public partial class DodajObszar : Window
    {
        public DataPomiaru dataPomiaru { get; set; }
        public PomiarRzeki pomiarRzeki { get; set; }
        public ObszarZagrozony obszarZagrozony { get; set; }

        public DodajObszar()
        {
            InitializeComponent();

        }

        private async void ClickFinal_Click(object sender, RoutedEventArgs e)
        {
            var ViewModel = (RegistrationViewModel)DataContext;
            List<int> listErrorsValidations = new List<int>();
            

            listErrorsValidations.Add(Validation.GetErrors(TextData).Count);
            listErrorsValidations.Add(Validation.GetErrors(TextNazwaRzekiPK).Count);
            listErrorsValidations.Add(Validation.GetErrors(TextPoziomWody).Count);
            listErrorsValidations.Add(Validation.GetErrors(TextPoziomWodyStand).Count);
            listErrorsValidations.Add(Validation.GetErrors(TextMiejscowość).Count);
            listErrorsValidations.Add(Validation.GetErrors(TextMiasto).Count);

            var collection = listErrorsValidations.Where(x => x == 0).ToList();

            if (collection.Count == listErrorsValidations.Count)
            {

                dataPomiaru = new DataPomiaru();
                pomiarRzeki = new PomiarRzeki();
                obszarZagrozony = new ObszarZagrozony();
                var wrtie = new DataBase();

                var resoultTryParseDate = DateTime.TryParse(TextData.Text, out DateTime data);
                if (resoultTryParseDate)
                    dataPomiaru.Data = data;

                else
                {
                    MessageBox.Show("Blędna data. Format daty: dd/mm/rrrr");

                }


                dataPomiaru.NazwaRzeki = ViewModel.NazwaRzeki;

                pomiarRzeki.NazwaRzeki = ViewModel.NazwaRzeki;
                bool resoultDouble = double.TryParse(ViewModel.PoziomWody, out double dPoziom);
                if (resoultDouble == true)
                    pomiarRzeki.PoziomWody = dPoziom;
                else
                {
                    MessageBox.Show("Blędnie wpisany poziom rzeki ");

                }


                bool resoultDouble2 = double.TryParse(ViewModel.StaPoziomWody, out double dPoziomStand);
                if (resoultDouble2 == true)
                    pomiarRzeki.StandardowyPoziom = dPoziomStand;
                else
                {
                    MessageBox.Show("Blędnie wpisany stand poziom rzeki ");

                }


                if ((resoultDouble2) && (resoultDouble) && (resoultTryParseDate))
                {

                    obszarZagrozony.Miasto = ViewModel.Miasto;
                    obszarZagrozony.Miejscowosc = ViewModel.Miejscowosc;
                    obszarZagrozony.NazwaRzeki = ViewModel.NazwaRzeki;

                  
                    var readDataBase = new ReadDataBase();
                    bool resoultResarhLocality = await readDataBase.ReadDataLocality(obszarZagrozony.Miejscowosc);
                    bool resoultResarhRiver = await readDataBase.ReadDataRiver(pomiarRzeki.NazwaRzeki);
                    var resoultResarhData = await readDataBase.ReadDataDate(dataPomiaru.Data);
                    


                    if ((resoultResarhLocality))
                    {

                        SearchDatabase czyOk = new SearchDatabase();
                        
                       
                        czyOk.DataContext = new CheckInToDatabase
                        {
                            Check = obszarZagrozony.Miejscowosc,

                        };
                        czyOk.ShowDialog();

                    }
                     if ((resoultResarhRiver))
                    {

                        SearchDatabase czyOk = new SearchDatabase();
                      
                       
                        czyOk.DataContext = new CheckInToDatabase
                        {
                            Check = obszarZagrozony.NazwaRzeki,

                        };
                        czyOk.ShowDialog();

                    }
                     if ((resoultResarhData.Count>0))
                    {

                        SearchDatabase czyOk = new SearchDatabase();
                        DateTime DataString = DateTime.Now;
                        foreach (var item in resoultResarhData)
                        {
                            DataString = item.Date;
                        }
                        czyOk.DataContext = new CheckInToDatabase
                        {

                            Check = DataString.ToString("d"),



                        };
                        czyOk.ShowDialog();

                    }

                    else if((resoultResarhLocality == false) && (resoultResarhRiver== false) && (resoultResarhData.Count == 0))
                    {

                        await wrtie.WriteToDatabasePomiarRzeki(pomiarRzeki);
                        await wrtie.WriteDataBaseDataPomiaru(dataPomiaru);
                        await wrtie.WriteDataBaseObszarZagrozony(obszarZagrozony);
                        MessageBox.Show("Obszar został pomyślnie dodany :-)");
                    }

                }

            }
            else
                MessageBox.Show($"Wypełnij wszystie pola ");
        }

    }
}
