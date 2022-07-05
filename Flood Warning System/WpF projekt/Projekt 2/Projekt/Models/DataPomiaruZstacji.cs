using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class DataPomiaruZstacji
    {
        public DateTime Data { get; set; }
        public int IdStacji { get; set; }
        public string Dzień { get; set; }
        public string Miesiąc { get; set; }
        public string Rok { get; set; }

        public virtual ImgwdaneSynoptyczne IdStacjiNavigation { get; set; }
    }
}
