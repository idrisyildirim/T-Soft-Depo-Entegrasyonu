using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DehasoftEntegrasyon.Class
{
    public class XMLSiparisHareket
    {
        public XMLSiparisHareket()
        {
            BlstKodu = "";
            StokAdi = "";
            StokKodu = "";
            Barkodu = "";
            Miktari2 = "1";
            Birimi2 = "";
            Miktari = "1";
            Birimi = "";
            KdvOrani = 0;
            KpbFiyati = "0";
            KpbDvzHR = 0;
            DepoAdi = "";
            MuhKoduGenel = "";
            OzelKoduHR = "";
            EkBilgi1 = "";
            EkBilgi2 = "";
            EkBilgi3 = "";
            EkBilgi4 = "";
            IskTutarPrm = 0;
            IskSnTutarPrm = 0;
            IskTutarPrmDvz = 0;
            IskSntutarPrmDvz = 0;
            PazPErsonel = "";
            PazPersonelBlkodu = 0;
            KdvDurumu = 0;
            kdvHaric = 0;
        }// default value
        public string BlstKodu { get; set; }
        public string StokAdi { get; set; }
        public string StokKodu { get; set; }
        public string Barkodu { get; set; }
        public string Miktari2 { get; set; }
        public string Birimi2 { get; set; }
        public string Miktari { get; set; }
        public string Birimi { get; set; }
        public double KdvOrani { get; set; }
        public string KpbFiyati { get; set; }
        public double KpbDvzHR { get; set; }
        public string DepoAdi { get; set; }
        public string MuhKoduGenel { get; set; }
        public string OzelKoduHR { get; set; }
        public string EkBilgi1 { get; set; }
        public string EkBilgi2 { get; set; }
        public string EkBilgi3 { get; set; }
        public string EkBilgi4 { get; set; }
        public double IskTutarPrm { get; set; }
        public double IskSnTutarPrm { get; set; }
        public double IskTutarPrmDvz { get; set; }
        public double IskSntutarPrmDvz { get; set; }
        public long? PazPersonelBlkodu { get; set; }
        public string PazPErsonel { get; set; } = "";
        public int KdvDurumu { get; set; }
        public double kdvHaric { get; set; }
    }
}
