using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class DataPomiaru
    {
        public DateTime Data { get; set; }
        public string NazwaRzeki { get; set; }
        public string Dzień { get; set; }
        public string Miesiąc { get; set; }
        public string Rok { get; set; }

        public virtual PomiarRzeki NazwaRzekiNavigation { get; set; }
    }
}
