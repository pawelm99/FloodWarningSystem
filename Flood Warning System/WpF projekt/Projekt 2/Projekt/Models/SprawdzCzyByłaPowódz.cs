using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class SprawdzCzyByłaPowódz
    {
        public string NazwaRzeki { get; set; }
        public string Miejscowosc { get; set; }
        public string Miasto { get; set; }
        public DateTime DataPowodzi { get; set; }
    }
}
