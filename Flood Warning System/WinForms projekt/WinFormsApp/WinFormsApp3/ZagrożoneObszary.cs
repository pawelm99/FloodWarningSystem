using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class ZagrożoneObszary : Form
    {
        
        private int selectedIndexlistBox; 
        public ZagrożoneObszary()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Czyta z bazy obszary zagrożone. 
        /// Wypisuje w listBoxie po czym wyłącza 
        /// button1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

  

        private async void Analiza_Load(object sender, EventArgs e)
        {
            label2.Text = "DataPomiaru";
            label3.Text = "Miasto";
            label4.Text = "Miejscowosc";
            label5.Text = "NazwaRzeki";
            label6.Text = "PoziomWody";
            label7.Text = "StandardowyPoziom";

            var baza = new Baza();
            var collction = await baza.BaseGetMeasureData();

            var text2 = collction.Select(x => x);

            foreach (var item in text2)
            {
                listBox1.Items.Add($"{item.DataPomiaru.ToString("d")}");
                listBox2.Items.Add($"{item.Miasto.ToString()}");
                listBox3.Items.Add($"{item.Miejscowosc.ToString()}");
                listBox5.Items.Add($"{item.NazwaRzeki.ToString()}");
                listBox4.Items.Add($"{item.PoziomWody.ToString()}");
                listBox6.Items.Add($"{item.StandardowyPoziom.ToString()}");

            }

        }
        /// <summary>
        /// Funkcja synchronizuje zaznaczanie tekstu
        /// </summary>
        /// <param name="index"></param>
        void AllIndex(int index)
        {
            listBox1.SelectedIndex = index;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox5.SelectedIndex = index;
            listBox6.SelectedIndex = index;
            button2.Enabled = true;
            selectedIndexlistBox  = index;
            
        }
        /// <summary>
        /// selectedIndexlistBox jest przekazywany do następnego
        /// formularza który pokazuje który wybraliśmy obszar do 
        /// powiadomienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var form5 = new Ostrzeganie(selectedIndexlistBox);
            form5.ShowDialog();
        }
        /// <summary>
        /// Przekazywanie do funkcji ALLIndex 
        /// który index został przez nas kliknięty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            AllIndex(listBox1.SelectedIndex);
        }

      

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox2.SelectedIndex);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox3.SelectedIndex);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox5.SelectedIndex);
        }


        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox4.SelectedIndex);
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox6.SelectedIndex);
        }

      
    }
}
