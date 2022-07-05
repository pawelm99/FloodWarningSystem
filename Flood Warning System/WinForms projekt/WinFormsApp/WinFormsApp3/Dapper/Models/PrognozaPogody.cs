using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class PrognozaPogody
    {
        public DateTime Data { get; set; }
        public double IloscOpadow { get; set; }
        public string RodzajPogody { get; set; }
        public string Miasto { get; set; }
    }
}
