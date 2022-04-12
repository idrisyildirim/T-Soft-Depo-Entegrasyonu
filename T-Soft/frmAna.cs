using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using T_Soft.T_Soft;
using DehasoftEntegrasyon.Class;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace T_Soft
{
    public partial class frmAna : DevExpress.XtraEditors.XtraForm
    {
        public frmAna()
        {
            InitializeComponent();
        }

        List<Datum> dt = new List<Datum>();

        private SqlConnection con;

        public int CariVarmi(string cariKodu)
        {
            string baglantiAdresi = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(baglantiAdresi);

            int sonuc = 0;
            
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM CARI WHERE CARIKODU = '{cariKodu}' AND SILINDI = 0", con);
                int cariId = Convert.ToInt32(command.ExecuteScalar());
                con.Close();
                sonuc = cariId;
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message + " CariVarmi()");
            }

            return sonuc;
        }

        public int FaturaVarmi(string faturaNo)
        {
            string baglantiAdresi = ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(baglantiAdresi);

            int sonuc = 0;

            try
            {
                con.Open();
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM FATURA WHERE FATURA_NO = '{faturaNo}' AND SILINDI = 0", con);
                int cariId = Convert.ToInt32(command.ExecuteScalar());
                con.Close();
                sonuc = cariId;
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message + " FaturaVarmi()");
            }

            return sonuc;
        }

        private void AkinsoftSDK()
        {
            try
            {
                string basarisizFatNo = "";
                string basarisizCariNo = "";

                XmlConfiguration config = new XmlConfiguration();
                XmlEntegrasyon entegrasyon = new XmlEntegrasyon();

                string logg = "";
                string psw = ConfigurationManager.AppSettings["akinsoftSifre"];
                var baglan = entegrasyon.Akinsoft_Baglan(ref psw, ref logg, config);
                if (!baglan)
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                    MessageBox.Show(logg, "Kontrol Paneline Bağlanılamadı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (var item in dt)
                {
                    #region Sipariş veren müşterinin soyadını, adından ayırmak için kullanılan yapı..

                    int idIndex = item.CustomerName.IndexOf(" (");
                    string[] adSoyad = item.CustomerName.Split(' ');
                    int uzunluk = 0;

                    if (idIndex >= 0)
                        uzunluk = adSoyad.Length - 1;
                    else
                        uzunluk = adSoyad.Length;

                    string ad = "";
                    string soyad = "";

                    if (uzunluk <= 2)
                    {
                        ad = adSoyad[0];
                    }
                    else
                    {
                        for (int i = 0; i < uzunluk - 1; i++)
                        {
                            if (i == 0)
                            {
                                ad = adSoyad[i];
                            }
                            else
                            {
                                ad = ad + " " + adSoyad[i];
                            }
                        }
                    }
                    soyad = adSoyad[uzunluk - 1];

                    #endregion

                    if (CariVarmi(item.CustomerCode) <= 0)
                    {
                        var cari = new XmlCari
                        {
                            CariKodu = item.CustomerCode,
                            Adi = ad,
                            Soyadi = soyad,
                            TicariUnvani = ad + " " +soyad,
                            Tel1 = item.InvoiceMobile,
                            Tel2 = item.InvoiceTel,
                            EmailAdres = item.CustomerUsername,
                            Adresi1 = item.InvoiceAddress,
                            Ulkesi1 = item.Invoice_country,
                            Ili1 = item.InvoiceCity,
                            Ilce1 = item.InvoiceTown,
                            VergiNo = item.InvoiceTaxno,
                            VergiDairesi = item.InvoiceTaxdep,
                            Kaydeden = "sa",
                            KayitTarihi = DateTime.Now.ToShortDateString(),
                            DovizKullan = 0,
                            Grubu = "T-Soft",
                            Aktif = 1,
                            Silindi = 0,
                        };
                        var carXml = entegrasyon.CariXml(config, cari);
                        var carikaydet = entegrasyon.CariKaydet(psw, carXml, ref logg, config);
                        if (!carikaydet)
                        {
                            if (basarisizCariNo == "")
                            {
                                basarisizCariNo = item.OrderCode;
                            }
                            else
                            {
                                basarisizCariNo = basarisizCariNo + ", " + item.OrderCode;
                            }

                            if (splashScreenManager1.IsSplashFormVisible == true)
                                splashScreenManager1.CloseWaitForm();
                            MessageBox.Show(logg, "Cari Kaydedilemedi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    if (FaturaVarmi(item.OrderCode) <= 0)
                    {
                        var fat1 = new XmlFatura
                        {
                            Carikodu = item.CustomerCode,
                            AdiSoyadi = ad + " " + soyad,
                            TicariUnvani = ad + " " + soyad,
                            CepTel = item.InvoiceMobile,
                            Tel1 = item.InvoiceTel,
                            Adresi = item.InvoiceAddress,
                            Ili = item.InvoiceCity,
                            Ilcesi = item.InvoiceTown,
                            VergiNo = item.InvoiceTaxno,
                            FaturaDurumu = 1,
                            Iptal = 0,
                            KdvDurumu = 1,
                            FaturaNo = item.OrderCode,
                            Tarihi = item.OrderDate.ToShortDateString(),
                            Aciklama = item.OrderStatus
                        };

                        var fatHrList = new List<XMLFaturaHareket>();
                        foreach (var item2 in dt[dt.IndexOf(item)].OrderDetails)
                        {
                            var fh1 = new XMLFaturaHareket()
                            {
                                Miktari = double.Parse(item2.Quantity),
                                Miktari2 = double.Parse(item2.Quantity),
                                BlstKodu = 0,
                                Barkodu = item2.Barcode,
                                StokKodu = item2.ProductCode,
                                StokAdi = item2.ProductName,
                                KpbFiyati = double.Parse(item2.SellingPrice),
                                EkBilgi1 = item2.OrderNote,
                                EkBilgi2 = item2.GiftNote,
                                KdvDurumu = 1,
                                KdvOrani = int.Parse(item2.Vat),
                                DepoAdi = "INTERNET DEPO",
                            };
                            fatHrList.Add(fh1);
                        }
                        var fatXml = entegrasyon.FaturaXml(config, fat1, fatHrList);
                        var fatkaydet = entegrasyon.FaturaKaydet2(psw, fatXml, ref logg, config);
                        if (!fatkaydet)
                        {
                            if (basarisizFatNo == "")
                            {
                                basarisizFatNo = item.OrderCode;
                            }
                            else
                            {
                                basarisizFatNo = basarisizFatNo + ", " + item.OrderCode;
                            }

                            if (splashScreenManager1.IsSplashFormVisible == true)
                                splashScreenManager1.CloseWaitForm();
                            MessageBox.Show(logg, "Fatura Kaydedilemedi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }                     
                    }
                }

                if (basarisizCariNo != "")
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                    MessageBox.Show($"Kaydedilemeyen cari numaraları: {basarisizCariNo}", "Cari Kaydedilemedi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (basarisizFatNo == "")
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                    MessageBox.Show("Fatura kaydetme işlemi başarıyla gerçekleşti.", "Fatura Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                    MessageBox.Show($"Kaydedilemeyen fatura numaraları: {basarisizFatNo}", "Fatura Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grdControlSip.DataSource = null;
            lblSipSayisi.Text = "0";
        }

        private KullaniciBilgileri Login()
        {
            string url = "http://tofisa.com/rest1/auth/login/cuneyt";

            string retVal = "";

            Dictionary<string, object> PostData = new Dictionary<string, object>();
            PostData.Add("pass", "123456");

            StringBuilder postData = new StringBuilder();

            foreach (string item in PostData.Keys)
            {
                postData.Append(item + "=" + HttpUtility.UrlEncode(PostData[item].ToString()) + "&"); 
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            Encoding encoding = Encoding.UTF8;
            byte[] bt = encoding.GetBytes(postData.ToString().Substring(0, postData.ToString().Length - 1));
            request.GetRequestStream().Write(bt, 0, bt.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            retVal = new StreamReader(response.GetResponseStream()).ReadToEnd();

            JObject MyParser = JObject.Parse(retVal);
            var data = MyParser["data"];

            var liste = JsonConvert.DeserializeObject<List<KullaniciBilgileri>>(data.ToString()).First();

            return liste;
        }

        private void SiparisleriGoruntule()
        {
            try
            {
                if (dateBaslangic.DateTime > dateBitis.DateTime)
                {
                    MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dateBaslangic.EditValue == null || dateBitis.EditValue == null)
                {
                    MessageBox.Show("Başlangıç veya bitiş tarihleri boş olamaz", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dateBaslangic.DateTime >= DateTime.Now)
                {
                    MessageBox.Show("Başlangıç tarihi bugünün tarihinden büyük olamaz", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                grdControlSip.DataSource = null;
                lblSipSayisi.Text = "0";

                Login();

                string url = "http://www.tofisa.com/rest1/order2/getOrders";

                string retVal = "";

                Dictionary<string, object> PostData = new Dictionary<string, object>();
                PostData.Add("token", Login().token);
                PostData.Add("OrderDateTimeStart", dateBaslangic.DateTime);
                PostData.Add("OrderDateTimeEnd", dateBitis.DateTime);
                PostData.Add("start", "1");
                PostData.Add("limit", "15");
                

                StringBuilder postData = new StringBuilder();

                foreach (string item in PostData.Keys)
                {
                    postData.Append(item + "=" + HttpUtility.UrlEncode(PostData[item].ToString()) + "&");
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                Encoding encoding = Encoding.UTF8;
                byte[] bt = encoding.GetBytes(postData.ToString().Substring(0, postData.ToString().Length - 1));
                request.GetRequestStream().Write(bt, 0, bt.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                retVal = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string result = retVal;

                var liste = JsonConvert.DeserializeObject<Rootobject>(result).data.ToList();

                dt = liste;

                grdControlSip.DataSource = liste;
                int kolonUzunlugu = grdViewSip.Columns.Count - 1;
                grdViewSip.Columns[kolonUzunlugu].Visible = false;
                grdViewSip.Columns[0].Width = 130;
                grdViewSip.Columns[1].Width = 100;
                grdViewSip.Columns[2].Width = 100;
                grdViewSip.Columns[3].Width = 180;
                grdViewSip.Columns[4].Width = 130;
                grdViewSip.Columns[5].Width = 180;
                grdViewSip.Columns[6].Width = 120;
                grdViewSip.Columns[7].Width = 120;
                grdViewSip.Columns[8].Width = 120;
                grdViewSip.Columns[9].Width = 120;
                grdViewSip.Columns[10].Width = 120;
                grdViewSip.Columns[11].Width = 500;
                grdViewSip.Columns[13].Width = 120;
                grdViewSip.Columns[14].Width = 120;
                grdViewSip.Columns[15].Width = 120;

                lblSipSayisi.Text = grdViewSip.RowCount.ToString();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                if (ex.Message.StartsWith("Değer null olamaz."))
                    MessageBox.Show("Bu tarihler arasında bir sipariş bulunamadı.", "Sipariş Bulunamadı",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void frmAna_Load(object sender, EventArgs e)
        {
            dateBaslangic.DateTime = DateTime.Now.AddDays(-1);
            dateBitis.DateTime = DateTime.Now;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                SiparisleriGoruntule();
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdViewSip.RowCount > 0)
                {
                    splashScreenManager1.ShowWaitForm();
                    AkinsoftSDK();
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    if (splashScreenManager1.IsSplashFormVisible == true)
                        splashScreenManager1.CloseWaitForm();
                    MessageBox.Show("ERP'ye aktarma yapmadan önce siparişleri listelemeniz gerekiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                if (splashScreenManager1.IsSplashFormVisible == true)
                    splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //FillCheckData();
            checkedComboBoxEdit1.Properties.DataSource = FillCheckData();
            checkedComboBoxEdit1.Properties.DisplayMember = "MODUL";
        }

        private DataTable FillCheckData()
        {
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection("Data Source=localhost;Initial Catalog=LKSDB;User ID=sa;Password=Qwer123!.!");
                SqlDataAdapter ad = new SqlDataAdapter($"SELECT DISTINCT MODUL FROM NR_BI_CH_EKSTRE_2 ", con);
                con.Open();
                ad.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void frmAna_Shown(object sender, EventArgs e)
        {
            if(!this.checkedComboBoxEdit1.IsPopupOpen)
            {
                this.checkedComboBoxEdit1.ShowPopup();
            }


            DataTable dataTable = FillCheckData();
            foreach (var item in dataTable.Rows)
            {
                string a = ((System.Data.DataRow)item)[0].ToString();
                this.checkedListBoxControl1.Items.Add(a);
            }

        }

        private void checkedComboBoxEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
           
        }

        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}