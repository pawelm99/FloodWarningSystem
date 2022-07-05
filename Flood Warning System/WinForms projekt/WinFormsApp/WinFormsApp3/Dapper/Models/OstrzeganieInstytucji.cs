using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class OstrzeganieInstytucji
    {
        public string SluzbaRatunkowa { get; set; }
        public string StanZagrozenia { get; set; }
        public DateTime Data { get; set; }
        public string MiastoOrganizacji { get; set; }
        public string MiejscowoscOrganizacji { get; set; }
        public string MiejscowoscZagrozona { get; set; }

        public virtual ObszarZagrozony MiejscowoscZagrozonaNavigation { get; set; }
    }
}
