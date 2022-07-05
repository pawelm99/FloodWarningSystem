using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class RodzajSłużbyRatunkowej
    {
        public string Miejscowość { get; set; }
        public bool PogRatunkowe { get; set; }
        public bool StrażPożarna { get; set; }
        public bool Policja { get; set; }

        public virtual ObszarZagrozony MiejscowośćNavigation { get; set; }
    }
}
