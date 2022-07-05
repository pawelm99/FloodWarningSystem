using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           
        }

    
        /// <summary>
        /// Ustawienie eventu jeśli klikniemy button1
        /// Podpięcie eventu errorTime
        /// Kontrolka będzie realizowana w dalszym projekcie 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            errorProvider1.SetError(button1, "Realizacja w drugim projekcie");
            EventHandler eventHandler = errorTime;
            eventHandler?.Invoke(this, e);
            //var form1 = new AddRegion();
            //form1.ShowDialog();
        }
        /// <summary>
        /// errorTime odlicza czas po czym kasuje zdarzenie errorProvider1
        /// Metoda async nie blokuje aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void errorTime(object sender, EventArgs e)
        {
           await Task.Delay(3000);
            errorProvider1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2= new WspieraneObszary();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form3 = new ZagrożoneObszary();
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

  
        
        private void Main_Load(object sender, EventArgs e)
        {
            
            label3.Text = DateTime.Now.ToString("d");
            menuStrip1.Items.Add(Name = "About",null,One_clickHelpMetod);
            


        }

        private void One_clickHelpMetod(object sender, EventArgs e)
        {
            var formText = new AboutText();
           formText.ShowDialog();
        }
 
    }
}
