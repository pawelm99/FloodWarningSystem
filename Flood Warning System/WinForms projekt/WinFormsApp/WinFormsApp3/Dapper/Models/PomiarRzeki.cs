using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class PomiarRzeki
    {
        public PomiarRzeki()
        {
            ObszarZagrozonies = new HashSet<ObszarZagrozony>();
        }

        public double PoziomWody { get; set; }
        public DateTime DataPomiaru { get; set; }
        public double StandardowyPoziom { get; set; }
        public string NazwaRzeki { get; set; }

        public virtual ICollection<ObszarZagrozony> ObszarZagrozonies { get; set; }
    }
}
