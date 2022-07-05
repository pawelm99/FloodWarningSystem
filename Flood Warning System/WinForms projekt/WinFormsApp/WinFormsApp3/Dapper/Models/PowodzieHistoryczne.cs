using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class PowodzieHistoryczne
    {
        public string Miasto { get; set; }
        public int IloscDniDeszczowych { get; set; }
        public DateTime DataPowodzi { get; set; }
        public string Miejscowosc { get; set; }
    }
}
