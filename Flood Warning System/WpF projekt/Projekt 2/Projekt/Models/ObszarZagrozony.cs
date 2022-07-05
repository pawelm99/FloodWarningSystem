using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class ObszarZagrozony
    {
        public ObszarZagrozony()
        {
            PowiadomienieSms = new HashSet<PowiadomienieSm>();
        }

        public string Miasto { get; set; }
        public string NazwaRzeki { get; set; }
        public string Miejscowosc { get; set; }

        public virtual PomiarRzeki NazwaRzekiNavigation { get; set; }
        public virtual ICollection<PowiadomienieSm> PowiadomienieSms { get; set; }
    }
}
