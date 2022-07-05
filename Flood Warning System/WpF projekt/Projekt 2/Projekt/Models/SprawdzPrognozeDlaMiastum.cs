using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class SprawdzPrognozeDlaMiastum
    {
        public string Miasto { get; set; }
        public string Miejscowosc { get; set; }
        public bool Deszcz { get; set; }
        public double? IloscOpadow { get; set; }
    }
}
