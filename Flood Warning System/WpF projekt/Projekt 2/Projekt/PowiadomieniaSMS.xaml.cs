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
    /// Logika interakcji dla klasy PowiadomieniaSMS.xaml
    /// </summary>
    public class ModelView
    {
        public List<string> NumerTelefonu { get; set; }
        public List<string> ObszaryZagrożone { get; set; }
        public string ChooseArea { get; set; }


        public ModelView()
        {
           
        }

    }
    public partial class PowiadomieniaSMS : Window
    {
        public PowiadomieniaSMS()
        {
            InitializeComponent();
            var model = new ModelView();

        }
        public async void KolekcjaObszaryZagrozone()
        {
            
            var readDataBase = new ReadDataBase();
            var Model = new ModelView();

          
            var collectionRickArea = await readDataBase.BaseGetAreaRisk();

            Model.ObszaryZagrożone = collectionRickArea;
            listboxObszary.ItemsSource = Model.ObszaryZagrożone;

        }  
        public async void KolekcjaNumerów()
        {
            
            var readDataBase = new ReadDataBase();
            var Model = new ModelView();

            Model.ChooseArea = listboxObszary.SelectedItem.ToString();

    
            var collectionNumber = readDataBase.BaseGetNumberPhone(Model.ChooseArea);


            Model.NumerTelefonu = new List<string>();
           
            foreach (var item in await collectionNumber)
            {
                
                Model.NumerTelefonu.Add(item.NumerTelefonu);
            }

                ListBoxNumery.ItemsSource = Model.NumerTelefonu;

        }

        private void ListBoxNumery_Loaded(object sender, RoutedEventArgs e)
        {
            KolekcjaObszaryZagrozone();
        }

        private void listboxObszary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KolekcjaNumerów();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (ListBoxNumery.ItemsSource == null)
            MessageBox.Show("Wybierz miejscowosc");
            else
            {
                foreach (var item in ListBoxNumery.ItemsSource)
                {
                    stringBuilder.AppendLine($" {item} ");
                }
                if (stringBuilder.Length > 0)
                    MessageBox.Show($"Numery: { stringBuilder.ToString()} zostały powaidomione!");
                else
                    MessageBox.Show("Brak numerów");
            }
            
        }
    }
}
