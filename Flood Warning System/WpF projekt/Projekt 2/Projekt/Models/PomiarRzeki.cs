using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class PomiarRzeki
    {
        public PomiarRzeki()
        {
            DataPomiarus = new HashSet<DataPomiaru>();
            ObszarZagrozonies = new HashSet<ObszarZagrozony>();
        }

        public double PoziomWody { get; set; }
        public double StandardowyPoziom { get; set; }
        public string NazwaRzeki { get; set; }

        public virtual ICollection<DataPomiaru> DataPomiarus { get; set; }
        public virtual ICollection<ObszarZagrozony> ObszarZagrozonies { get; set; }
    }
}
