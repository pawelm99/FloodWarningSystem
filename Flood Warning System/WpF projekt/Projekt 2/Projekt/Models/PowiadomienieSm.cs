using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class PowiadomienieSm
    {
        public string NumerTelefonu { get; set; }
        public string StanZagrozenia { get; set; }
        public string Miasto { get; set; }
        public string Miejscowosc { get; set; }

        public virtual ObszarZagrozony MiejscowoscNavigation { get; set; }
    }
}
