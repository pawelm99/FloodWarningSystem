using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class PomiarMiejscowosc
    {
        public DateTime Data { get; set; }
        public string NazwaRzeki { get; set; }
        public string Miasto { get; set; }
        public string SluzbaRatunkowa { get; set; }
        public string Miejscowosc { get; set; }
        public double PoziomWody { get; set; }
        public DateTime DataPomiaru { get; set; }
        public double StandardowyPoziom { get; set; }
    }
}
