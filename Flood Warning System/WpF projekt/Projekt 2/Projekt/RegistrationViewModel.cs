using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt
{
    class RegistrationViewModel : IDataErrorInfo
    {
        public string Data { get; set; }
        public string PoziomWody { get; set; }
        public string StaPoziomWody { get; set; }
        public string NazwaRzeki { get; set; }
        public string Miejscowosc { get; set; }
        public string Miasto { get; set; }
        public string StanZagrożeniaDN { get; set; }
        public string NumerTelefonuDN { get; set; }
        public string MistoDN { get; set; }
        public string MiejscowośćDN { get; set; }


        public string this[string columnName]
        {

            get
            {

                switch (columnName)
                {
                    case nameof(Data):
                        if(string.IsNullOrWhiteSpace(Data))
                        {
                            return "Wpisz date w formacie np. 00.00.0000";
                        }
                        break;
                    case nameof(PoziomWody):
                        if (string.IsNullOrWhiteSpace(PoziomWody))
                        {
                            return "Wpisz Poziom Wody w metrach";
                        }
                        break;
                    case nameof(StaPoziomWody):
                        if (string.IsNullOrWhiteSpace(StaPoziomWody))
                        {
                            return "Wpisz Standardowy Poziom Wody w metrach";
                        }
                        break;
                    case nameof(NazwaRzeki):
                        if (string.IsNullOrWhiteSpace(NazwaRzeki))
                        {
                            return "Wpisz  nazwe rzeki";
                        }
                        break;
                    case nameof(Miejscowosc):
                        if (string.IsNullOrWhiteSpace(Miejscowosc))
                        {
                            return "Wpisz miejscowosc obszaru zagrożonego";
                        }
                        break;
                    case nameof(Miasto):
                        if (string.IsNullOrWhiteSpace(Miasto))
                        {
                            return "Wpisz Miasto obszaru zagrożonego";
                        }
                        break;
                    case nameof(StanZagrożeniaDN):
                        if (string.IsNullOrWhiteSpace(StanZagrożeniaDN))
                        {
                            return "Wpisz StanZagrożenia np. Powodziowe";
                        }
                        break;
                    case nameof(NumerTelefonuDN):
                        if (string.IsNullOrWhiteSpace(NumerTelefonuDN) || (12<=NumerTelefonuDN.Length))
                        {
                            
                            return "Wpisz Numer telefonu bez kierunkowego np. 737-567-224. Maksymalnie 9 cyfr";
                        }
                        break;
                    case nameof(MistoDN):
                        if (string.IsNullOrWhiteSpace(MistoDN))
                        {
                            return "Wpisz Misto w którym jest numer";
                        }
                        break;
               
                    default:
                        break;
                }
                return string.Empty;
                

            }
        }

        public string Error => throw new NotImplementedException();
    }
}
