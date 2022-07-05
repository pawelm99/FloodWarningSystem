using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class PomiarRzekiDlaMiejscowosci
    {
        public string Miasto { get; set; }
        public string Miejscowosc { get; set; }
        public string NazwaRzeki { get; set; }
        public double PoziomWody { get; set; }
        public double StandardowyPoziom { get; set; }
    }
}
