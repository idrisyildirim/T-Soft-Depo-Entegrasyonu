using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DehasoftEntegrasyon.Class
{
   public class XMLSiparis
    {
        public XMLSiparis()
        {
            Tarihi = DateTime.Now.ToShortDateString();
            Carikodu = "";
            SiparisDurum = 1;
            KdvDurumu = 0;
            Aciklama = "";
            AdiSoyadi = "";
            OtvKullan = 0;
            OivKullan = 0;
            IskKulCari = 0;
            IskKul1 = 0;
            IskKul2 = 0;
            IskKul3 = 0;
            IskKulStok = 0;
            IskKulOzel = 0;
            IskKulAlt = 0;
            DovizKullan = 0;
            PazDurumu = 2;
            DvzHesIsleCari = 0;
            DvzHesIsleStok = 0;
            VadeDurumu = 0;
            Iptal = 0;
            FaturaNo = "";
            PazPersBlKodu = 0;
            OfflineGuid = "";
            CepTel = "";
            Ili = "";
            Ilcesi = "";
            Adresi = "";
            Faks = "";
            Tel1 = "";
            VergiDairesi = "";
            VergiNo = "";
            TicariUnvani = "";
            PazPersonel = "";
            OzelKodu = "";
            SayacTanimi = "";
            Aciklama2 = "";
            Ekbilgi1 = "";
            KpbdvzCari = 0;
            IskOranAlt = 0;
            IskOranCari = 0;
            IskOran1 = 0;
            IskOran2 = 0;
            IskOran3 = 0;
            IskTutarCari = 0;
            IskTutar1 = 0;
            IskTutar2 = 0;
            IskTutar3 = 0;
            IskTutarAlt2 = 0;
            PazUrunOrani = 0;
            PazUrunTutari = 0;
            PazIscOranı = 0;
            PazIscTutar = 0;
            BonusOdemeTutari = 0;
            IskTutarStok = 0;
            IskTutarOzel = 0;
            Vadesi = DateTime.Now.ToShortDateString();
            SiparisTuru=2;
            Ulkesi="";
            Kargosu = "";
            Grubu = "";
            sevkAdresi = "";
            Ekbilgi_2 = "";
        }

        public string sevkAdresi { get; set; }
        public string Ekbilgi_2 { get; set; }
        public string Grubu { get; set; }
        public string Kargosu { get; set; }
        public short SiparisTuru { get; set; }
        public short SiparisDurum { get; set; }
        public short OtvKullan { get; set; }
        public short OivKullan { get; set; }
        public short IskKulCari { get; set; }
        public short IskKul1 { get; set; }
        public short IskKul2 { get; set; }
        public short IskKul3 { get; set; }
        public short IskKulStok { get; set; }
        public short IskKulOzel { get; set; }
        public short IskKulAlt { get; set; }
        public short DovizKullan { get; set; }
        public short PazDurumu { get; set; }
        public short DvzHesIsleStok { get; set; }
        public short DvzHesIsleCari { get; set; }
        public short VadeDurumu { get; set; }
        public short Iptal { get; set; }
        public string FaturaNo { get; set; }
        public string Carikodu { get; set; }
        public long PazPersBlKodu { get; set; }
        public string OfflineGuid { get; set; }
        public string CepTel { get; set; }
        public string Ili { get; set; }
        public string Ilcesi { get; set; }
        public string Adresi { get; set; }
        public string Faks { get; set; }
        public string Tel1 { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string AdiSoyadi { get; set; }
        public string TicariUnvani { get; set; }
        public string PazPersonel { get; set; }
        public string Aciklama { get; set; }
        public string OzelKodu { get; set; }
        public string SayacTanimi { get; set; }
        public string Aciklama2 { get; set; }
        public string Ekbilgi1 { get; set; }
        public object KdvDurumu { get; set; }
        public double KpbdvzCari { get; set; }
        public double IskOranAlt { get; set; }
        public double IskOranCari { get; set; }
        public double IskOran1 { get; set; }
        public double IskOran2 { get; set; }
        public double IskOran3 { get; set; }
        public double IskTutarCari { get; set; }
        public double IskTutar1 { get; set; }
        public double IskTutar2 { get; set; }
        public double IskTutar3 { get; set; }
        public double IskTutarAlt2 { get; set; }
        public double PazUrunOrani { get; set; }
        public double PazUrunTutari { get; set; }
        public double PazIscOranı { get; set; }
        public double PazIscTutar { get; set; }
        public double BonusOdemeTutari { get; set; }
        public double IskTutarStok { get; set; }
        public double IskTutarOzel { get; set; }
        public string Vadesi { get; set; }
        public string Tarihi { get; set; }
        public string Ulkesi { get;  set; }
        
    }
}
