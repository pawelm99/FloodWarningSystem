using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class DataPowodziHi
    {
        public DateTime DataPowodzi { get; set; }
        public string Miejscowość { get; set; }
        public string Dzień { get; set; }
        public string Miesiąc { get; set; }
        public string Rok { get; set; }

        public virtual PowodzieHistoryczne MiejscowośćNavigation { get; set; }
    }
}
