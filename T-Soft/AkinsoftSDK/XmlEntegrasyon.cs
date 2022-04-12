using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using DehasoftEntegrasyon.Akinsoft;
using VCLClasses;

namespace DehasoftEntegrasyon.Class
{
    public class XmlEntegrasyon
    {
        public static string GelenSifre = "";
        public static string StokBlkodu { get; set; }
        public string SifreCoz(string data)
        {
            var tempDizi = Convert.FromBase64String(data);
            var finalData = Encoding.ASCII.GetString(tempDizi);
            return finalData;
        }
        public string Sifrele(string data)
        {
            var tempDizi = Encoding.ASCII.GetBytes(data); // şifrelenecek veri byte dizisine çevrilir
            var finalData = Convert.ToBase64String(tempDizi); //Base64 ile şifrelenir
            return finalData;
        }
        public string FaturaXml(XmlConfiguration config, XmlFatura fatura, List<XMLFaturaHareket> faturaHr )
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("Fatura.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WFT");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWFT1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("FATURA"); //fatura başlangıç
                BaslikYaz(writer, "FATURA_DURUMU", fatura.FaturaDurumu.ToString());
                BaslikYaz(writer, "CARIKODU", fatura.Carikodu);
                BaslikYaz(writer, "KDV_DURUMU", fatura.KdvDurumu.ToString());
                BaslikYaz(writer, "OTV_KULLAN", fatura.OtvKullan.ToString());
                BaslikYaz(writer, "OIV_KULLAN", fatura.OivKullan.ToString());
                BaslikYaz(writer, "KPBDVZ_CARI", fatura.KpbdvzCari.ToString());
                BaslikYaz(writer, "ISK_KUL_CARI", fatura.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", fatura.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", fatura.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", fatura.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", fatura.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", fatura.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_KUL_ALT", fatura.IskKulAlt.ToString());
                BaslikYaz(writer, "ISK_ORAN_ALT", fatura.IskOranAlt.ToString());
                BaslikYaz(writer, "ISK_TUTAR_ALT2", fatura.IskTutarAlt2.ToString());
                BaslikYaz(writer, "FATURA_NO", fatura.FaturaNo);
                BaslikYaz(writer, "EKBILGI_1", fatura.Ekbilgi1);
                BaslikYaz(writer, "ACIKLAMA_2", fatura.Aciklama2);
                BaslikYaz(writer, "SAYAC_TANIMI", fatura.SayacTanimi);
                BaslikYaz(writer, "ISK_KUL_CARI", fatura.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", fatura.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", fatura.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", fatura.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", fatura.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", fatura.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_ORAN_CARI", fatura.IskOranCari.ToString());
                BaslikYaz(writer, "ISK_ORAN_1", fatura.IskOran1.ToString());
                BaslikYaz(writer, "ISK_ORAN_2", fatura.IskOran2.ToString());
                BaslikYaz(writer, "ISK_ORAN_3", fatura.IskOran3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_CARI", fatura.IskTutarCari.ToString());
                BaslikYaz(writer, "ISK_TUTAR_1", fatura.IskTutar1.ToString());
                BaslikYaz(writer, "ISK_TUTAR_2", fatura.IskTutar2.ToString());
                BaslikYaz(writer, "ISK_TUTAR_3", fatura.IskTutar3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_STOK", fatura.IskTutarStok.ToString());
                BaslikYaz(writer, "ISK_TUTAR_OZEL", fatura.IskTutarOzel.ToString());
                BaslikYaz(writer, "DOVIZ_KULLAN", fatura.DovizKullan.ToString());
                BaslikYaz(writer, "DVZ_HSISLE_CARI", fatura.DvzHesIsleCari.ToString());
                BaslikYaz(writer, "DVZ_HSISLE_STOK", fatura.DvzHesIsleStok.ToString());
                BaslikYaz(writer, "KPBDVZ_CARI", fatura.KpbdvzCari.ToString());
                BaslikYaz(writer, "OZEL_KODU", fatura.OzelKodu);
                BaslikYaz(writer, "VADESI", fatura.Vadesi);
                BaslikYaz(writer, "VADE_DURUMU", fatura.VadeDurumu.ToString());
                BaslikYaz(writer, "IPTAL", fatura.Iptal.ToString());
                BaslikYaz(writer, "ACIKLAMA", fatura.Aciklama);
                BaslikYaz(writer, "PAZ_DURUMU", fatura.PazDurumu.ToString());
                BaslikYaz(writer, "PAZ_PERS_BLKODU", fatura.PazPersBlKodu.ToString());
                BaslikYaz(writer, "PAZ_PERSONEL", fatura.PazPersonel);
                BaslikYaz(writer, "PAZ_URUN_ORANI", fatura.PazUrunOrani.ToString());
                BaslikYaz(writer, "PAZ_URUN_TUTARI", fatura.PazUrunTutari.ToString());
                BaslikYaz(writer, "PAZ_ISC_ORANI", fatura.PazIscOranı.ToString());
                BaslikYaz(writer, "PAZ_ISC_TUTARI", fatura.PazIscTutar.ToString());
                //BaslikYaz(writer, "TICARI_UNVANI", fatura.TicariUnvani);
                //BaslikYaz(writer, "ADI_SOYADI", fatura.AdiSoyadi);
                //BaslikYaz(writer, "VERGI_DAIRESI", fatura.VergiDairesi);
                //BaslikYaz(writer, "VERGI_NO", fatura.VergiNo);
                //BaslikYaz(writer, "TEL1", fatura.Tel1);
                //BaslikYaz(writer, "FAKS", fatura.Faks);
                //BaslikYaz(writer, "ADRESI", fatura.Adresi);
                //BaslikYaz(writer, "ILCESI", fatura.Ilcesi);
                //BaslikYaz(writer, "ILI", fatura.Ili);
                //BaslikYaz(writer, "CEP_TEL", fatura.CepTel);
                BaslikYaz(writer, "BONUS_ODEME_TUTARI", fatura.BonusOdemeTutari.ToString());
                BaslikYaz(writer, "OFFLINE_GUID", fatura.OfflineGuid);
                writer.WriteEndElement();
                //hareket
                writer.WriteStartElement("FATURAHAREKET");

                foreach (var item in faturaHr)
                {
                    writer.WriteStartElement("HAREKET");
                    BaslikYaz(writer, "BLSTKODU", item.BlstKodu.ToString());
                    BaslikYaz(writer, "STOK_ADI", item.StokAdi);
                    BaslikYaz(writer, "STOKKODU", item.StokKodu);
                    BaslikYaz(writer, "BARKODU", item.Barkodu);
                    BaslikYaz(writer, "MIKTARI_2", item.Miktari2.ToString());
                    BaslikYaz(writer, "BIRIMI_2", item.Birimi2);
                    BaslikYaz(writer, "MIKTARI", item.Miktari.ToString());
                    BaslikYaz(writer, "BIRIMI", item.Birimi);
                    BaslikYaz(writer, "KDV_ORANI", item.KdvOrani.ToString());
                    BaslikYaz(writer, "KPB_FIYATI", item.KpbFiyati.ToString());
                    BaslikYaz(writer, "KPBDVZ", item.KpbDvzHR.ToString());
                    BaslikYaz(writer, "DEPO_ADI", item.DepoAdi);
                    BaslikYaz(writer, "MUH_KODU_GENEL", item.MuhKoduGenel);
                    BaslikYaz(writer, "OZEL_KODU", item.OzelKoduHR); BaslikYaz(writer, "EKBILGI_1", item.EkBilgi1);
                    BaslikYaz(writer, "EKBILGI_2", item.EkBilgi2);
                    BaslikYaz(writer, "EKBILGI_3", item.EkBilgi3);
                    BaslikYaz(writer, "EKBILGI_4", item.EkBilgi4);
                    BaslikYaz(writer, "ISK_TUTAR_PRM", item.IskTutarPrm.ToString());
                    BaslikYaz(writer, "ISK_SNTUTAR_PRM", item.IskSnTutarPrm.ToString());
                    BaslikYaz(writer, "ISK_TUTAR_PRM_DVZ", item.IskTutarPrmDvz.ToString());
                    BaslikYaz(writer, "ISK_SNTUTAR_PRM_DVZ", item.IskSntutarPrmDvz.ToString());
                    BaslikYaz(writer, "PAZ_PERSONEL", item.PazPErsonel);
                    BaslikYaz(writer, "PAZ_PERS_BLKODU", item.PazPersonelBlkodu.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();                
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("Fatura.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("Fatura.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }
        public string FaturaMasrafXml(XmlConfiguration config, XmlFatura fatura, List<XMLFaturaHareket> faturaHr)
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("Fatura2.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WFT");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWFT1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("FATURA"); //fatura başlangıç
                BaslikYaz(writer, "FATURA_DURUMU", fatura.FaturaDurumu.ToString());
                BaslikYaz(writer, "CARIKODU", fatura.Carikodu);
                BaslikYaz(writer, "KDV_DURUMU", fatura.KdvDurumu.ToString());
                BaslikYaz(writer, "OTV_KULLAN", fatura.OtvKullan.ToString());
                BaslikYaz(writer, "OIV_KULLAN", fatura.OivKullan.ToString());
                BaslikYaz(writer, "KPBDVZ_CARI", fatura.KpbdvzCari.ToString());
                BaslikYaz(writer, "ISK_KUL_CARI", fatura.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", fatura.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", fatura.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", fatura.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", fatura.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", fatura.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_KUL_ALT", fatura.IskKulAlt.ToString());
                BaslikYaz(writer, "ISK_ORAN_ALT", fatura.IskOranAlt.ToString());
                BaslikYaz(writer, "ISK_TUTAR_ALT2", fatura.IskTutarAlt2.ToString());
                BaslikYaz(writer, "FATURA_NO", fatura.FaturaNo);
                BaslikYaz(writer, "EKBILGI_1", fatura.Ekbilgi1);
                BaslikYaz(writer, "ACIKLAMA_2", fatura.Aciklama2);
                BaslikYaz(writer, "SAYAC_TANIMI", fatura.SayacTanimi);
                BaslikYaz(writer, "ISK_KUL_CARI", fatura.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", fatura.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", fatura.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", fatura.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", fatura.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", fatura.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_ORAN_CARI", fatura.IskOranCari.ToString());
                BaslikYaz(writer, "ISK_ORAN_1", fatura.IskOran1.ToString());
                BaslikYaz(writer, "ISK_ORAN_2", fatura.IskOran2.ToString());
                BaslikYaz(writer, "ISK_ORAN_3", fatura.IskOran3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_CARI", fatura.IskTutarCari.ToString());
                BaslikYaz(writer, "ISK_TUTAR_1", fatura.IskTutar1.ToString());
                BaslikYaz(writer, "ISK_TUTAR_2", fatura.IskTutar2.ToString());
                BaslikYaz(writer, "ISK_TUTAR_3", fatura.IskTutar3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_STOK", fatura.IskTutarStok.ToString());
                BaslikYaz(writer, "ISK_TUTAR_OZEL", fatura.IskTutarOzel.ToString());
                BaslikYaz(writer, "DOVIZ_KULLAN", fatura.DovizKullan.ToString());
                BaslikYaz(writer, "DVZ_HSISLE_CARI", fatura.DvzHesIsleCari.ToString());
                BaslikYaz(writer, "DVZ_HSISLE_STOK", fatura.DvzHesIsleStok.ToString());
                BaslikYaz(writer, "KPBDVZ_CARI", fatura.KpbdvzCari.ToString());
                BaslikYaz(writer, "OZEL_KODU", fatura.OzelKodu);
                BaslikYaz(writer, "VADESI", fatura.Vadesi);
                BaslikYaz(writer, "VADE_DURUMU", fatura.VadeDurumu.ToString());
                BaslikYaz(writer, "IPTAL", fatura.Iptal.ToString());
                BaslikYaz(writer, "ACIKLAMA", fatura.Aciklama);
                //BaslikYaz(writer, "PAZ_DURUMU", fatura.PazDurumu.ToString());
                //BaslikYaz(writer, "PAZ_PERS_BLKODU", fatura.PazPersBlKodu.ToString());
                //BaslikYaz(writer, "PAZ_PERSONEL", fatura.PazPersonel);
                //BaslikYaz(writer, "PAZ_URUN_ORANI", fatura.PazUrunOrani.ToString());
                //BaslikYaz(writer, "PAZ_URUN_TUTARI", fatura.PazUrunTutari.ToString());
                //BaslikYaz(writer, "PAZ_ISC_ORANI", fatura.PazIscOranı.ToString());
                //BaslikYaz(writer, "PAZ_ISC_TUTARI", fatura.PazIscTutar.ToString());

                //BaslikYaz(writer, "BONUS_ODEME_TUTARI", fatura.BonusOdemeTutari.ToString());
                //BaslikYaz(writer, "OFFLINE_GUID", fatura.OfflineGuid);
                writer.WriteEndElement();
                //hareket
                writer.WriteStartElement("FATURAHAREKET");

                foreach (var item in faturaHr)
                {
                    writer.WriteStartElement("HAREKET");
                    BaslikYaz(writer, "STOK_ADI", item.StokAdi);
                    BaslikYaz(writer, "BLHZMKODU", item.BlHzmKodu.ToString());
                    BaslikYaz(writer, "MIKTARI_2", item.Miktari2.ToString());
                    BaslikYaz(writer, "BIRIMI_2", item.Birimi2);
                    BaslikYaz(writer, "MIKTARI", item.Miktari.ToString());
                    BaslikYaz(writer, "BIRIMI", item.Birimi);
                    BaslikYaz(writer, "KDV_ORANI", item.KdvOrani.ToString());
                    BaslikYaz(writer, "KPB_FIYATI", item.KpbFiyati.ToString());
                    BaslikYaz(writer, "KPBDVZ", item.KpbDvzHR.ToString());
                    //BaslikYaz(writer, "DEPO_ADI", item.DepoAdi);
                    // BaslikYaz(writer, "MUH_KODU_GENEL", item.MuhKoduGenel);
                    BaslikYaz(writer, "OZEL_KODU", item.OzelKoduHR);
                    BaslikYaz(writer, "EKBILGI_1", item.EkBilgi1);
                    BaslikYaz(writer, "EKBILGI_2", item.EkBilgi2);
                    BaslikYaz(writer, "EKBILGI_3", item.EkBilgi3);
                    BaslikYaz(writer, "EKBILGI_4", item.EkBilgi4);
                    //BaslikYaz(writer, "ISK_TUTAR_PRM", item.IskTutarPrm.ToString());
                    //BaslikYaz(writer, "ISK_SNTUTAR_PRM", item.IskSnTutarPrm.ToString());
                    //BaslikYaz(writer, "ISK_TUTAR_PRM_DVZ", item.IskTutarPrmDvz.ToString());
                    //BaslikYaz(writer, "ISK_SNTUTAR_PRM_DVZ", item.IskSntutarPrmDvz.ToString());
                    //BaslikYaz(writer, "PAZ_PERSONEL", item.PazPErsonel);
                    //BaslikYaz(writer, "PAZ_PERS_BLKODU", item.PazPersonelBlkodu.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("Fatura2.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("Fatura2.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }
        public string SiparisXml(XmlConfiguration config, XMLSiparis siparis, List<XMLSiparisHareket> siparisHr)
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("Siparis.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WSP");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWSP1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("SIPARIS"); //siparis başlangıç
                BaslikYaz(writer, "SIPARIS_DURUMU", siparis.SiparisDurum.ToString());
                BaslikYaz(writer, "SIPARIS_TURU", siparis.SiparisTuru.ToString());
                BaslikYaz(writer, "CARIKODU", siparis.Carikodu);
                BaslikYaz(writer, "KDV_DURUMU", siparis.KdvDurumu.ToString());
                //BaslikYaz(writer, "OTV_KULLAN", siparis.OtvKullan.ToString());
                //BaslikYaz(writer, "OIV_KULLAN", siparis.OivKullan.ToString());
                // BaslikYaz(writer, "KPBDVZ_CARI", siparis.KpbdvzCari.ToString());
                BaslikYaz(writer, "ISK_KUL_CARI", siparis.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", siparis.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", siparis.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", siparis.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", siparis.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", siparis.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_KUL_ALT", siparis.IskKulAlt.ToString());
                BaslikYaz(writer, "ISK_ORAN_ALT", siparis.IskOranAlt.ToString());
                BaslikYaz(writer, "ISK_TUTAR_ALT2", siparis.IskTutarAlt2.ToString());
                //BaslikYaz(writer, "FATURA_NO", siparis.FaturaNo);
                BaslikYaz(writer, "EKBILGI_1", siparis.Ekbilgi1);
                BaslikYaz(writer, "ACIKLAMA_2", siparis.Aciklama2);
                BaslikYaz(writer, "EKBILGI_2", siparis.Ekbilgi_2);
                BaslikYaz(writer, "ISK_KUL_CARI", siparis.IskKulCari.ToString());
                BaslikYaz(writer, "ISK_KUL_1", siparis.IskKul1.ToString());
                BaslikYaz(writer, "ISK_KUL_2", siparis.IskKul2.ToString());
                BaslikYaz(writer, "ISK_KUL_3", siparis.IskKul3.ToString());
                BaslikYaz(writer, "ISK_KUL_STOK", siparis.IskKulStok.ToString());
                BaslikYaz(writer, "ISK_KUL_OZEL", siparis.IskKulOzel.ToString());
                BaslikYaz(writer, "ISK_ORAN_CARI", siparis.IskOranCari.ToString());
                BaslikYaz(writer, "ISK_ORAN_1", siparis.IskOran1.ToString());
                BaslikYaz(writer, "ISK_ORAN_2", siparis.IskOran2.ToString());
                BaslikYaz(writer, "ISK_ORAN_3", siparis.IskOran3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_CARI", siparis.IskTutarCari.ToString());
                BaslikYaz(writer, "ISK_TUTAR_1", siparis.IskTutar1.ToString());
                BaslikYaz(writer, "ISK_TUTAR_2", siparis.IskTutar2.ToString());
                BaslikYaz(writer, "ISK_TUTAR_3", siparis.IskTutar3.ToString());
                BaslikYaz(writer, "ISK_TUTAR_STOK", siparis.IskTutarStok.ToString());
                BaslikYaz(writer, "ISK_TUTAR_OZEL", siparis.IskTutarOzel.ToString());
                BaslikYaz(writer, "DOVIZ_KULLAN", siparis.DovizKullan.ToString());
                //BaslikYaz(writer, "DVZ_HSISLE_CARI", siparis.DvzHesIsleCari.ToString());
                //BaslikYaz(writer, "DVZ_HSISLE_STOK", siparis.DvzHesIsleStok.ToString());
                //BaslikYaz(writer, "KPBDVZ_CARI", siparis.KpbdvzCari.ToString());
                BaslikYaz(writer, "OZEL_KODU", siparis.OzelKodu);
                BaslikYaz(writer, "VADESI", siparis.Vadesi);
                BaslikYaz(writer, "VADE_DURUMU", siparis.VadeDurumu.ToString());
                //BaslikYaz(writer, "IPTAL", siparis.Iptal.ToString());
                BaslikYaz(writer, "ACIKLAMA", siparis.Aciklama);
                BaslikYaz(writer, "KARGO_FIRMASI", siparis.Kargosu);
                //BaslikYaz(writer, "PAZ_DURUMU", siparis.PazDurumu.ToString());
                //BaslikYaz(writer, "PAZ_PERS_BLKODU", siparis.PazPersBlKodu.ToString());
                //BaslikYaz(writer, "PAZ_PERSONEL", siparis.PazPersonel);
                //BaslikYaz(writer, "PAZ_URUN_ORANI", siparis.PazUrunOrani.ToString());
                //BaslikYaz(writer, "PAZ_URUN_TUTARI", siparis.PazUrunTutari.ToString());
                //BaslikYaz(writer, "PAZ_ISC_ORANI", siparis.PazIscOranı.ToString());
                //BaslikYaz(writer, "PAZ_ISC_TUTARI", siparis.PazIscTutar.ToString());
                //BaslikYaz(writer, "ADRESI", siparis.Adresi);
                BaslikYaz(writer, "TICARI_UNVANI", siparis.TicariUnvani);
                BaslikYaz(writer, "CEP_TEL", siparis.CepTel);
                //BaslikYaz(writer, "ADI_SOYADI", siparis.AdiSoyadi);
                //BaslikYaz(writer, "VERGI_DAIRESI", siparis.VergiDairesi);
                //BaslikYaz(writer, "VERGI_NO", siparis.VergiNo);
                //BaslikYaz(writer, "TEL1", siparis.Tel1);
                //BaslikYaz(writer, "FAKS", siparis.Faks);
                BaslikYaz(writer, "ADRESI", siparis.Adresi);
                BaslikYaz(writer, "ILCESI", siparis.Ilcesi);
                BaslikYaz(writer, "ILI", siparis.Ili);
                BaslikYaz(writer, "ULKESI", siparis.Ulkesi);
                BaslikYaz(writer, "GRUBU", siparis.Grubu);
                BaslikYaz(writer, "SEVK_ADRESI", siparis.Adresi);
                BaslikYaz(writer, "SEVK_ILCESI", siparis.Ilcesi);
                BaslikYaz(writer, "SEVK_ILI", siparis.Ili);
                BaslikYaz(writer, "SEVK_ULKESI", siparis.Ulkesi);
                // BaslikYaz(writer, "SEVK_TEL", siparis.CepTel);
                //BaslikYaz(writer, "CEP_TEL", siparis.CepTel);
                //BaslikYaz(writer, "BONUS_ODEME_TUTARI", siparis.BonusOdemeTutari.ToString());
                //BaslikYaz(writer, "OFFLINE_GUID", siparis.OfflineGuid);
                writer.WriteEndElement();
                //hareket
                writer.WriteStartElement("SIPARISHAREKET");

                foreach (var item in siparisHr)
                {
                    writer.WriteStartElement("HAREKET");
                    //BaslikYaz(writer, "BLSTKODU", item.BlstKodu.ToString());
                    //BaslikYaz(writer, "STOK_ADI", item.StokAdi);
                    BaslikYaz(writer, "STOKKODU", item.StokKodu);
                    //BaslikYaz(writer, "BARKODU", item.Barkodu);
                    BaslikYaz(writer, "MIKTARI_2", item.Miktari2.ToString());
                    BaslikYaz(writer, "KPB_KDV_HARICFY", item.kdvHaric.ToString());
                    BaslikYaz(writer, "MIKTARI", item.Miktari.ToString());
                    BaslikYaz(writer, "KDV_DURUMU", item.KdvDurumu.ToString());
                    BaslikYaz(writer, "KDV_ORANI", item.KdvOrani.ToString());
                    BaslikYaz(writer, "KPB_FIYATI", item.KpbFiyati.ToString());
                    BaslikYaz(writer, "KPBDVZ", item.KpbDvzHR.ToString());
                    //BaslikYaz(writer, "DEPO_ADI", item.DepoAdi);
                    // BaslikYaz(writer, "MUH_KODU_GENEL", item.MuhKoduGenel);
                    BaslikYaz(writer, "OZEL_KODU", item.OzelKoduHR);
                    BaslikYaz(writer, "EKBILGI_1", item.EkBilgi1);
                    BaslikYaz(writer, "EKBILGI_2", item.EkBilgi2);
                    BaslikYaz(writer, "EKBILGI_3", item.EkBilgi3);
                    BaslikYaz(writer, "EKBILGI_4", item.EkBilgi4);
                    //BaslikYaz(writer, "ISK_TUTAR_PRM", item.IskTutarPrm.ToString());
                    //BaslikYaz(writer, "ISK_SNTUTAR_PRM", item.IskSnTutarPrm.ToString());
                    //BaslikYaz(writer, "ISK_TUTAR_PRM_DVZ", item.IskTutarPrmDvz.ToString());
                    //BaslikYaz(writer, "ISK_SNTUTAR_PRM_DVZ", item.IskSntutarPrmDvz.ToString());
                    //BaslikYaz(writer, "PAZ_PERSONEL", item.PazPErsonel);
                    //BaslikYaz(writer, "PAZ_PERS_BLKODU", item.PazPersonelBlkodu.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("Siparis.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("Siparis.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }
        public string StokXml(XmlConfiguration config, XmlStok stok)
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("Stok.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WST");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWST1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("STOK"); //STOK BAŞLANGIC
                BaslikYaz(writer, "BLKODU", stok.Blkodu.ToString());
                BaslikYaz(writer, "STOKKODU", stok.Stokkodu);
                BaslikYaz(writer, "AKTIF", stok.Aktif.ToString());
                BaslikYaz(writer, "STOK_ADI", stok.StokAdi);
                BaslikYaz(writer, "STOK_ADI_YD", stok.StokAdiYd);
                BaslikYaz(writer, "BARKODU", stok.Barkodu);
                BaslikYaz(writer, "GRUBU", stok.Grubu);
                BaslikYaz(writer, "ARA_GRUBU", stok.AraGrubu);
                BaslikYaz(writer, "ALT_GRUBU", stok.AltGrubu);
                BaslikYaz(writer, "ACIKLAMA1", stok.Aciklama);
                BaslikYaz(writer, "OZEL_KODU1", stok.OzelKodu1);
                BaslikYaz(writer, "OZEL_KODU2", stok.OzelKodu2);
                BaslikYaz(writer, "OZEL_KODU3", stok.OzelKodu3);
                BaslikYaz(writer, "OZELALANTANIM_10", stok.OzelAlanTanım_10);
                BaslikYaz(writer, "OZELALANTANIM_12", stok.OzelAlanTanım_12);
                BaslikYaz(writer, "OZELALANTANIM_13", stok.OzelAlanTanım_13);
                BaslikYaz(writer, "OZELALANTANIM_14", stok.OzelAlanTanım_14);
                BaslikYaz(writer, "KDV_ORANI", stok.KdvOrani.ToString());
                BaslikYaz(writer, "DOVIZ_KULLAN", stok.DovizKullan.ToString());
                BaslikYaz(writer, "ANA_STOK", stok.AnaStok.ToString());
                BaslikYaz(writer, "ANA_STOKKODU", stok.AnaStokkodu);
                BaslikYaz(writer, "MARKASI", stok.Markasi);
                BaslikYaz(writer, "MODELI", stok.Modeli);
                BaslikYaz(writer, "RENK", stok.Renk);
                BaslikYaz(writer, "BEDEN", stok.Beden);
                BaslikYaz(writer, "DEPO_ADI", stok.DepoAdi);
                BaslikYaz(writer, "BIRIMI", stok.Birimi);
                BaslikYaz(writer, "RESIM_YOLU", stok.ResimYolu);
                BaslikYaz(writer, "KAYDEDEN", stok.Kaydeden);
                BaslikYaz(writer, "MUH_ALIS", stok.MuhAlis);
                BaslikYaz(writer, "MUH_SATIS_YI", stok.MuhSatisYi);
                BaslikYaz(writer, "MUH_SATIS_YD", stok.MuhSatisYd);
                BaslikYaz(writer, "MUH_IADE_YI", stok.MuhIadeYi);
                BaslikYaz(writer, "MUH_IADE_YD", stok.MuhIadeYd);

                BaslikYaz(writer, "KDV_ORANI_SATIS_TPT", stok.KdvSatisPrk);
                BaslikYaz(writer, "KDV_ORANI_ALIS", stok.KdvAlis);


                writer.WriteEndElement(); // STOK BİTİŞ
                writer.WriteStartElement("STOKFIYAT");//Fiyatlar
                foreach (var item in stok.Fiyatlar)
                {
                    writer.WriteStartElement("FIYATLAR");
                    BaslikYaz(writer, "FIYAT_NO", item.FiyatNo.ToString());
                    BaslikYaz(writer, "FIYATI", item.Fiyati);
                    BaslikYaz(writer, "HESAP", item.Hesap);
                    BaslikYaz(writer, "TANIMI", item.Tanimi);
                    BaslikYaz(writer, "ALIS_SATIS", ((int)item.FiyatTipi).ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();//Bitiş
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("Stok.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("Stok.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }
        public string StokHareketXml(XmlConfiguration config, List<XMLStokHareket> stokHareket)
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("StokHareket.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WST");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWSH1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("STOKHAREKET");//StokHareketler
                foreach (var item in stokHareket)
                {
                    writer.WriteStartElement("HAREKET");
                    BaslikYaz(writer, "BLSTKODU", item.Blstkodu.ToString());
                    BaslikYaz(writer, "KPB_FIYATI", item.Kpb_Tutari.ToString());
                    BaslikYaz(writer, "MIKTAR_2", item.Miktari.ToString());
                    BaslikYaz(writer, "DEPO_ADI", item.DepoAdi);
                    BaslikYaz(writer, "OZEL_KODU", item.Ozel_kodu);
                    BaslikYaz(writer, "TARIHI", item.Tarihi);
                    BaslikYaz(writer, "TUTAR_TURU", item.Tutar_Turu.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("StokHareket.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("StokHareket.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }

        public string CariXml(XmlConfiguration config, XmlCari cari)
        {
            var sonuc = "";
            try
            {
                var writer = new XmlTextWriter("Cari.xml", Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //baslik
                writer.WriteStartElement("WCR");
                writer.WriteStartElement("AYAR");
                BaslikYaz(writer, "TRSVER", "ASWCR1.02.03");
                BaslikYaz(writer, "DATABASETYPE", config.dbSetType);
                BaslikYaz(writer, "DBFILENAME", config.DbFileName);
                BaslikYaz(writer, "USERNAME", config.userName);
                BaslikYaz(writer, "LCTYPE", config.lcType);
                BaslikYaz(writer, "DBISUNICODE", config.dbIsUniCode);
                BaslikYaz(writer, "COLLATE", config.collate);
                BaslikYaz(writer, "OSAUTHENT", config.osauthent);
                BaslikYaz(writer, "PRGLISANS", config.prgLisans);
                BaslikYaz(writer, "LISANSLIMODULLER", config.lisansliModuller);
                BaslikYaz(writer, "PERSUSER", config.PersUser);
                BaslikYaz(writer, "SUBE_KODU", config.subeKodu);
                BaslikYaz(writer, "SERVER_OMYUKLU", config.serverOmYuklu);
                BaslikYaz(writer, "SERVER_GMYUKLU", config.serverGmYuklu);
                BaslikYaz(writer, "SERVER_BYYUKLU", config.serverByYuklu);
                BaslikYaz(writer, "SERVER_IMYUKLU", config.serverImYuklu);
                BaslikYaz(writer, "SERVER_DMYUKLU", config.serverDmYuklu);
                BaslikYaz(writer, "SERVER_IKYUKLU", config.serverIkYuklu);
                writer.WriteEndElement();
                writer.WriteStartElement("CARI"); //CARİ BAŞLANGIC
                BaslikYaz(writer, "AKTIF", cari.Aktif.ToString());
                BaslikYaz(writer, "CARIKODU", cari.CariKodu);
                BaslikYaz(writer, "TICARI_UNVANI", cari.TicariUnvani);
                BaslikYaz(writer, "ADI", cari.Adi);
                BaslikYaz(writer, "SOYADI", cari.Soyadi);
                BaslikYaz(writer, "ADRESI_1", cari.Adresi1);
                BaslikYaz(writer, "ADRESI_2", cari.Adresi2);
                BaslikYaz(writer, "ILI_1", cari.Ili1);
                BaslikYaz(writer, "ILI_2", cari.Ili2);
                BaslikYaz(writer, "ILCESI_1", cari.Ilce1);
                BaslikYaz(writer, "ILCESI_2", cari.Ilce2);
                BaslikYaz(writer, "ULKESI_1", cari.Ulkesi1);
                BaslikYaz(writer, "ULKESI_2", cari.Ulkesi2);
                BaslikYaz(writer, "GRUBU", cari.Grubu);
                BaslikYaz(writer, "ARA_GRUBU", cari.AraGrubu);
                BaslikYaz(writer, "ALT_GRUBU", cari.CariKodu);
                BaslikYaz(writer, "MUHKODU_ALIS", cari.MuhKoduAlis);
                BaslikYaz(writer, "MUHKODU_SATIS", cari.MuhKoduSatis);
                BaslikYaz(writer, "TEL1", cari.Tel1);
                BaslikYaz(writer, "TEL2", cari.Tel2);
                BaslikYaz(writer, "CEP_TEL", cari.Cep1);
                BaslikYaz(writer, "EV_TEL", cari.EvTel);
                BaslikYaz(writer, "OZEL_KODU1", cari.OzelKodu1);
                BaslikYaz(writer, "OZEL_KODU2", cari.OzelKodu2);
                BaslikYaz(writer, "OZEL_KODU3", cari.OzelKodu3);
                BaslikYaz(writer, "KAYIT_TARIHI", cari.KayitTarihi.ToString());
                BaslikYaz(writer, "E_MAIL", cari.EmailAdres);
                BaslikYaz(writer, "VERGI_DAIRESI", cari.VergiDairesi);
                BaslikYaz(writer, "VERGI_NO", cari.VergiNo);
                BaslikYaz(writer, "DOVIZ_KULLAN", cari.DovizKullan.ToString());
                BaslikYaz(writer, "DOVIZ_BIRIMI", cari.DovizBirimi);
                BaslikYaz(writer, "KAYDEDEN", cari.Kaydeden);
                BaslikYaz(writer, "SILINDI", cari.Silindi.ToString());
                BaslikYaz(writer, "TC_KIMLIK_NO", cari.TcKimlikNo.ToString());

                writer.WriteEndElement(); // CARİ BİTİŞ
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();

                if (File.Exists("Cari.xml"))
                {
                    var sList = new TStringList();
                    sList.LoadFromFile("Cari.xml");
                    var xmlValue = sList.Text.Replace(Environment.NewLine, " ");
                    xmlValue = xmlValue.Replace("&", "|*");
                    sList.Text = "xmlValue=" + xmlValue;
                    sonuc = xmlValue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sonuc;
        }

        public bool StokKaydet(string psw, string xmlData, ref string ht, XmlConfiguration config)
        {
            if (xmlData == null) throw new ArgumentNullException(nameof(xmlData));
            var don = false;
            var veri = "tpwd=" + psw + "&command=postxml_stok&sirketKodu=" + config.AkinsoftSirketKodu +
                       "&calismaYili=" + config.AkinsoftCalismaYili + "&xmlValue=" + xmlData + "& &XMLCData=1";
            var VBYT = Encoding.UTF8.GetBytes(veri);
            var V_64 = Convert.ToBase64String(VBYT);
            var SOR = WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" + V_64);
            var cevap = SOR.GetResponse();
            var DONEN = new StreamReader(cevap.GetResponseStream());
            var gelen = DONEN.ReadToEnd();
            var COZ = Convert.FromBase64String(gelen);
            var xv = Encoding.UTF8.GetString(COZ);
            var X = xv.IndexOf("XML_POST_OK^MBLKODU=", 0);
            if (X > -1)
            {
                var D = xv.Replace("XML_POST_OK^MBLKODU=", "");
                ht = D;
                don = true;
            }
            else
            {
                don = false;
                ht = xv;
            }
            return don;
        }
        private void BaslikYaz(XmlTextWriter writer, string baslik, string deger)
        {
            if (deger == null)
            {
                return;
            }
            writer.WriteStartElement(baslik);
            writer.WriteCData(deger);
            writer.WriteEndElement();
        }
        public bool Akinsoft_Baglan(ref string token, ref string logg, XmlConfiguration config)
        {
            var md5Anahtar = new MD5CryptoServiceProvider();
            var Sec = new SecurityAlgorithm();
            var byteblok = Encoding.UTF8.GetBytes(config.AkinsoftSifre);
            byteblok = md5Anahtar.ComputeHash(byteblok);
            var sb = new StringBuilder();
            foreach (var ba in byteblok)
                sb.Append(ba.ToString("x2").ToLower());
            var veri = "command=wlogin&username=" + config.AkinsoftKullanici + "&password=" + sb + "&devCode=" +
                       config.SdkKullaniciAdi + "&devPass=" + config.SdkSifre;
            var veriByteDizisi = Encoding.ASCII.GetBytes(veri);
            var sifrelenmisVeri = Convert.ToBase64String(veriByteDizisi);
            try
            {
                var istek =
                    WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" +
                                      sifrelenmisVeri);
                var cevap = istek.GetResponse();
                var donenBilgiler = new StreamReader(cevap.GetResponseStream());
                var gelen = donenBilgiler.ReadToEnd();
                var cozByteDizi = Convert.FromBase64String(gelen);
                var orjinalVeri = Encoding.UTF8.GetString(cozByteDizi);
                var veriler = orjinalVeri.Split('&');
                if (veriler[0] == "1")
                {
                    GelenSifre = veriler[1];
                    token = GelenSifre;
                    return true;
                }
                logg = orjinalVeri;
                return false;
            }
            catch (Exception ex)
            {
                logg = ex.Message;
                return false;
            }
        }
        public bool Fatura_Kaydet(string psw, string xml_data, ref string ht, XmlConfiguration config)
        {
            var don = false;

            // xml_data = xml_data.Replace("&", "|*");
            var veri = "tpwd=" + psw + "&command=postxml_fatura&sirketKodu=" + config.AkinsoftSirketKodu +
                       "&calismaYili=" + config.AkinsoftCalismaYili + "&xmlValue=" + xml_data + "& &XMLCData=1";
            var VBYT = Encoding.UTF8.GetBytes(veri);
            var V_64 = Convert.ToBase64String(VBYT);
            var SOR =
                WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" +
                                  V_64);
            var cevap = SOR.GetResponse();
            var DONEN = new StreamReader(cevap.GetResponseStream());
            var gelen = DONEN.ReadToEnd();
            var COZ = Convert.FromBase64String(gelen);
            var xv = Encoding.UTF8.GetString(COZ);
            var X = xv.IndexOf("XML_POST_OK^MBLKODU=", 0);
            if (X > -1)
            {
                var D = xv.Replace("XML_POST_OK^MBLKODU=", "");
                ht = D;
                don = true;
            }
            else
            {
                don = false;
                ht = xv;
            }
            //Frm_Main.lst_Log.Items.Add(ht)
            //HataKaydetSQL(ht)
            return don;
        }
        public bool Siparis_Kaydet(string psw, string xml_data, ref string ht, XmlConfiguration config)
        {
            var don = false;

            // xml_data = xml_data.Replace("&", "|*");
            var veri = "tpwd=" + psw + "&command=postxml_siparis&sirketKodu=" + config.AkinsoftSirketKodu +
                       "&calismaYili=" + config.AkinsoftCalismaYili + "&xmlValue=" + xml_data + "& &XMLCData=1";
            var VBYT = Encoding.UTF8.GetBytes(veri);
            var V_64 = Convert.ToBase64String(VBYT);
            var SOR =
                WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" +
                                  V_64);
            var cevap = SOR.GetResponse();
            var DONEN = new StreamReader(cevap.GetResponseStream());
            var gelen = DONEN.ReadToEnd();
            var COZ = Convert.FromBase64String(gelen);
            var xv = Encoding.UTF8.GetString(COZ);
            var X = xv.IndexOf("XML_POST_OK^MBLKODU=", 0);
            if (X > -1)
            {
                var D = xv.Replace("XML_POST_OK^MBLKODU=", "");
                ht = D;
                don = true;
            }
            else
            {
                don = false;
                ht = xv;
            }
            //Frm_Main.lst_Log.Items.Add(ht)
            //HataKaydetSQL(ht)
            return don;
        }
        public bool FaturaKaydet2(string psw, string xmlData, ref string ht, XmlConfiguration config)
        {
            var don = false;
            var data2 = $"DATA=&tpwd={psw}&command=postxml_fatura&sirketKodu={config.AkinsoftSirketKodu}&calismaYili={config.AkinsoftCalismaYili}&xmlValue={xmlData}";
            var textData = "DATA=" + HttpUtility.UrlEncode(Base64Encode(data2.Substring(5)));
            System.Net.WebRequest req = System.Net.WebRequest.Create($"http://{config.AkinsoftIp}:{config.AkinsoftUpdatePort}/");
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(textData);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp != null)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string rst = Base64Decode(sr.ReadToEnd().Trim());
                var X = rst.IndexOf("XML_POST_OK^MBLKODU=", 0);
                if (X > -1)
                {
                    var d = rst.Replace("XML_POST_OK^MBLKODU=", "");
                    ht = d;
                    don = true;
                }
                else
                {
                    don = false;
                    ht = rst;
                }
            }

            return don;
        }
        public bool SiparisKaydet2(string psw, string xmlData, ref string ht, XmlConfiguration config)
        {
            var don = false;
            var data2 = $"DATA=&tpwd={psw}&command=postxml_siparis&sirketKodu={config.AkinsoftSirketKodu}&calismaYili={config.AkinsoftCalismaYili}&xmlValue={xmlData}";
            var textData = "DATA=" + HttpUtility.UrlEncode(Base64Encode(data2.Substring(5)));
            System.Net.WebRequest req = System.Net.WebRequest.Create($"http://{config.AkinsoftIp}:{config.AkinsoftUpdatePort}/");
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(textData);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp != null)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string rst = Base64Decode(sr.ReadToEnd().Trim());
                var X = rst.IndexOf("XML_POST_OK^MBLKODU=", 0);
                if (X > -1)
                {
                    var d = rst.Replace("XML_POST_OK^MBLKODU=", "");
                    ht = d;
                    don = true;
                }
                else
                {
                    don = false;
                    ht = rst;
                }
            }

            return don;
        }
        public bool StokHrKaydet2(string psw, string xmlData, ref string ht, XmlConfiguration config, ref string blkodu)
        {
            var don = false;
            var data2 = $"DATA=&tpwd={psw}&command=postxml_stokhrk&sirketKodu={config.AkinsoftSirketKodu}&calismaYili={config.AkinsoftCalismaYili}&xmlValue={xmlData}";
            var textData = "DATA=" + HttpUtility.UrlEncode(Base64Encode(data2.Substring(5)));
            System.Net.WebRequest req = System.Net.WebRequest.Create($"http://{config.AkinsoftIp}:{config.AkinsoftUpdatePort}/");
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(textData);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp != null)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string rst = Base64Decode(sr.ReadToEnd().Trim());
                var X = rst.IndexOf("XML_POST_OK^MBLKODU=", 0);
                if (X > -1)
                {
                    var d = rst.Replace("XML_POST_OK^MBLKODU=", "");
                    ht = d;
                    var fblkodu = d;
                    blkodu = fblkodu;
                    don = true;
                }
                else
                {
                    don = false;
                    ht = rst;
                }
            }

            return don;
        }
        public bool CariKaydet(string psw, string xmlData, ref string ht, XmlConfiguration config)
        {
            var don = false;
            var veri = "tpwd=" + psw + "&command=postxml_cari&sirketKodu=" + config.AkinsoftSirketKodu +
                       "&calismaYili=" + config.AkinsoftCalismaYili + "&xmlValue=" + xmlData + "& &XMLCData=1";
            var VBYT = Encoding.UTF8.GetBytes(veri);
            var V_64 = Convert.ToBase64String(VBYT);
            var SOR = WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" + V_64);
            var cevap = SOR.GetResponse();
            var DONEN = new StreamReader(cevap.GetResponseStream());
            var gelen = DONEN.ReadToEnd();
            var COZ = Convert.FromBase64String(gelen);
            var xv = Encoding.UTF8.GetString(COZ);
            var X = xv.IndexOf("XML_POST_OK^MBLKODU=", 0);
            if (X > -1)
            {
                var D = xv.Replace("XML_POST_OK^MBLKODU=", "");
                ht = D;
                don = true;
            }
            else
            {
                don = false;
                ht = xv;
            }
            return don;
        }

        private string Base64Encode(string text)
        {
            byte[] EncryptAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(text);
            string value = System.Convert.ToBase64String(EncryptAsBytes);
            return value;
        }
        private string Base64Decode(string text)
        {
            byte[] DecryptAsBytes = System.Convert.FromBase64String(text);
            string value = System.Text.UTF8Encoding.UTF8.GetString(DecryptAsBytes);
            return value;
        }

        public string GetData(string psw, XmlConfiguration config)
        {
            string result;
            var veri = "tpwd=" + psw + "&command=get_sirketliste";
            var vbyt = Encoding.ASCII.GetBytes(veri);
            var v64 = Convert.ToBase64String(vbyt);
            var sor =
                WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" +
                                  v64);
            var cevap = sor.GetResponse();
            // ReSharper disable once AssignNullToNotNullAttribute
            var donen = new StreamReader(cevap.GetResponseStream());
            var gelen = donen.ReadToEnd();
            var coz = Convert.FromBase64String(gelen);
            var xv = Encoding.UTF8.GetString(coz);
            result = xv;
            return result;
        }
        public object Akinsoft_Baglanti_KES(string psw, XmlConfiguration config)
        {
            var veri2 = "command=wlogout&tpwd=" + psw;
            var vbyt2 = Encoding.ASCII.GetBytes(veri2);
            var v642 = Convert.ToBase64String(vbyt2);
            WebRequest.Create("http://" + config.AkinsoftIp + ":" + config.AkinsoftUpdatePort + "/getdata.html?" + v642);
            return "";
        }
    }
}