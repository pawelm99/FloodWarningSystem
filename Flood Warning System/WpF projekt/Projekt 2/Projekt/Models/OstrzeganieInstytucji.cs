using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class OstrzeganieInstytucji
    {
        public string StanZagrozenia { get; set; }
        public string MiastoOrganizacji { get; set; }
        public string MiejscowoscOrganizacji { get; set; }
        public string MiejscowoscZagrozona { get; set; }
        public string NazwaSluzby { get; set; }

        public virtual ObszarZagrozony MiejscowoscZagrozonaNavigation { get; set; }
    }
}
