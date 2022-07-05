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
    public partial class Ostrzeganie : Form
    {
        private int index;
        private int Policja;
        private int Szpital;
        private int StrażPożarna;
        private int PowiadomienieSMS;
        private string Sluzby;
        /// <summary>
        /// Formularz przyjmuje numer pozycji wiersza którego zaznaczyliśmy.
        /// </summary>
        /// <param name="ilosc"></param>
        public Ostrzeganie(int ilosc)
        {
            this.index = ilosc;
            InitializeComponent();
        }

         /// <summary>
         /// Następuje tutaj wyszukanie w bazie jaką służbę ratunkową posiada dany obszar.
         /// Jeśli posiada checkBox zostanie odblokwoany
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         
        private async void Ostrzeganie_Load(object sender, EventArgs e)
        {
            var baza = new Baza();
            var collction = await baza.BaseGetMeasureData();
            var text2 = collction.Select(x => x).ToArray();
            errorProvider1.SetError(checkBox4, "Realizowane w drugim projekcie");
            errorProvider1.RightToLeft = true;
            checkBox4.Enabled = false;
            if (text2[index].SluzbaRatunkowa.IndexOf("Szpital") >= 0)
            {
                checkBox2.Enabled = true;
            }
             if (text2[index].SluzbaRatunkowa.IndexOf("StrazPozarna") >= 0)
            {
                checkBox3.Enabled = true;
            }
             if (text2[index].SluzbaRatunkowa.IndexOf("Policja") >= 0)
            {
                checkBox1.Enabled = true;
            }


        }
        /// <summary>
        /// Odblokuje przycisk jeśli zaznaczymy checkBoxa
        /// </summary>
        void funEnableButton1()
        {
            button1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//poliucja
        {
            funEnableButton1();
            if (checkBox1.Checked)
                Policja = 1 ;

            else
                Policja = 0; ;
        }

 

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //szpital
        {
            funEnableButton1();
            if (checkBox2.Checked)
                Szpital = 1;

            else
                Szpital = 0; ;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)//straz
        {
            funEnableButton1();
            if (checkBox3.Checked)
                StrażPożarna = 1;

            else
                StrażPożarna = 0; ;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            if (checkBox4.Checked)
                PowiadomienieSMS = 1;

            else
                PowiadomienieSMS = 0; ;
        }

       /// <summary>
       /// Utworzenie nowego formularza oraz wyświetlenie 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new WynikWyszukania();
            form.label1.Location = new Point(0,41);
            if (Policja == 1) Sluzby += "Policja, ";
            if (Szpital == 1) Sluzby += "Szpital, ";
            if (StrażPożarna == 1) Sluzby += "Straż Pożarna, ";
            form.label1.Text = $"Powiadomienie wysłane do: {Sluzby}";
            form.ShowDialog();
            button1.Enabled = false;
            Close();

            
        }

  
    }
}
