using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class PrognozaPogody
    {
        public PrognozaPogody()
        {
            DataPrognozies = new HashSet<DataPrognozy>();
        }

        public string Miasto { get; set; }
        public bool Deszcz { get; set; }
        public double? IloscOpadow { get; set; }

        public virtual ICollection<DataPrognozy> DataPrognozies { get; set; }
    }
}
