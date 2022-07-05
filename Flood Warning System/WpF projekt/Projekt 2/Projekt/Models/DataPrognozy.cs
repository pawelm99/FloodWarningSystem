using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class DataPrognozy
    {
        public DateTime Data { get; set; }
        public string Miasto { get; set; }
        public string Dzień { get; set; }
        public string Miesiąc { get; set; }
        public string Rok { get; set; }

        public virtual PrognozaPogody MiastoNavigation { get; set; }
    }
}
