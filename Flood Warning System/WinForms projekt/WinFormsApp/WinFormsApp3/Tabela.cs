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
    public partial class Tabela : Form
    {
        public Tabela()
        {
            InitializeComponent();
       
        }
        /// <summary>
        /// Async metoda ładowania danych z bazy. 
        /// Mijescowosc oraz Miasto 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Tabela_Load(object sender, EventArgs e)
        {
            var Baza = new Baza();

            textBox1.Text = "Miejscowosc";
            textBox2.Text = "Miasto";
            richTextBox1.Text = await Baza.BaseGetTownship();
            richTextBox2.Text = await Baza.BaseGetCity();
            
        }


    }
}
