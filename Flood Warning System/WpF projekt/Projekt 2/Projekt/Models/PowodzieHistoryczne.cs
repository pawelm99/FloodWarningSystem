using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class PowodzieHistoryczne
    {
        public PowodzieHistoryczne()
        {
            DataPowodziHis = new HashSet<DataPowodziHi>();
        }

        public string Miasto { get; set; }
        public string Miejscowosc { get; set; }

        public virtual ICollection<DataPowodziHi> DataPowodziHis { get; set; }
    }
}
