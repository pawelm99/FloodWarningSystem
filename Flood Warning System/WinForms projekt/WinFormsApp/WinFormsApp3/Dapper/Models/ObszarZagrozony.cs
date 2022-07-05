using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class ObszarZagrozony
    {
        public ObszarZagrozony()
        {
            OstrzeganieInstytucjis = new HashSet<OstrzeganieInstytucji>();
            PowiadomienieSms = new HashSet<PowiadomienieSm>();
        }

        public DateTime Data { get; set; }
        public string Miasto { get; set; }
        public string SluzbaRatunkowa { get; set; }
        public string NazwaRzeki { get; set; }
        public string Miejscowosc { get; set; }

        public virtual PomiarRzeki NazwaRzekiNavigation { get; set; }
        public virtual ICollection<OstrzeganieInstytucji> OstrzeganieInstytucjis { get; set; }
        public virtual ICollection<PowiadomienieSm> PowiadomienieSms { get; set; }
    }
}
