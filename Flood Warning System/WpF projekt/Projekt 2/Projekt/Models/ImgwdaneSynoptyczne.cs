using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt.Models
{
    public partial class ImgwdaneSynoptyczne
    {
        public ImgwdaneSynoptyczne()
        {
            DataPomiaruZstacjis = new HashSet<DataPomiaruZstacji>();
        }

        public string Stacja { get; set; }
        public double SumaOpadu { get; set; }
        public int IdStacji { get; set; }

        public virtual ICollection<DataPomiaruZstacji> DataPomiaruZstacjis { get; set; }
    }
}
