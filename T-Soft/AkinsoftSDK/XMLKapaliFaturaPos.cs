using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DehasoftEntegrasyon.Class
{
    public class XMLKapaliFaturaPos
    {
        public XMLKapaliFaturaPos()
        {
            IslemTuru = 6;
            BlBnHesapKodu ="0";
            BankaAdi = "";
            PossDetay = "";
            KpbDvz = 1;
            KpbAtut = 0;

        }        
        public short IslemTuru { get; set; }
        public string BlBnHesapKodu { get; set; }
        public string BankaAdi { get; set; }
        public string PossDetay { get; set; }
        public short KpbDvz { get; set; }
        public double KpbAtut { get; set; }
    }
}
