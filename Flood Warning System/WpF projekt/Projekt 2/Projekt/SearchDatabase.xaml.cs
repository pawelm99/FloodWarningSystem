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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy SearchDatabase.xaml
    /// </summary>
    public partial class SearchDatabase : Window
    {
        
        public SearchDatabase( )
        {
            
            InitializeComponent();
           
           
        }

        private void Click1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    public class CheckInToDatabase
    {
        public string Check { get; set; }
      
    }

}
