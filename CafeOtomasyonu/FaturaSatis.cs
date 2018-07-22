using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class FaturaSatis : Form
    {
        public FaturaSatis()
        {
            InitializeComponent();
        }

        public static string ad, soyad, unvan, genelid, mid;
        public static string uid, barkodu, urunadi;
        public static double fiyat,kdv;
        
        public static int fustid;
        public static int gelenSayi;
        DataRowView AktifKayitUst;
        DataRowView AktifKayitSiparis;

        private void FaturaSatis_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.Siparis' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.siparisTableAdapter.Fill(this.cafeOtomasyonuDataSet.Siparis);
            BtnKontrol(true);
            Kayitlar(-11111);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            if (FaturaSatisListesi.DoluMasaFatura==1)//Ana sayfadan gelen dolu masa bilgisi ile istenilen verileri database'den alır.
            {
                fustid = -111;
                FaturaSatisListesi.DoluMasaFatura = 0; 
                string Masano;
                Masano = AnaSayfa.MasaNumarasi.ToString();
                faturaSatisUstTableAdapter.DoluMasa(cafeOtomasyonuDataSet.FaturaSatisUst, Masano);

                DataRowView AktifKayit;
                AktifKayit = (DataRowView)faturaSatisUstBindingSource.Current;
                FaturaSatis.fustid = Convert.ToInt32(AktifKayit["fustid"].ToString());
                
                if (fustid == -111) return;
                Kayitlar(fustid);
                ToplamTutarBul();
            }          
            
        }

        private void Kayitlar(int id)
        {
            faturaSatisDetayTableAdapter.Fill(cafeOtomasyonuDataSet.FaturaSatisDetay, id);
            faturaSatisUstTableAdapter.Fill(cafeOtomasyonuDataSet.FaturaSatisUst, id);
        }
        private void BtnKontrol(Boolean durum)
        {
            Btnyeni.Enabled = durum;
            Btnduzelt.Enabled = durum;
            Btnsil.Enabled = durum;
            satirSilToolStripMenuItem.Enabled = !durum;

            Btnvazgec.Enabled = !durum;
            Btnkaydet.Enabled = !durum;
            textBox13.Enabled = !durum;
            textBox1.Enabled = !durum;
            textBox2.Enabled = !durum;
            textBox3.Enabled = !durum;
            textBox4.Enabled = !durum;
            textBox5.Enabled = !durum;
            textBox6.Enabled = !durum;

            textBox7.Enabled = !durum;
            textBox8.Enabled = !durum;
            textBox9.Enabled = !durum;
            textBox10.Enabled = !durum;
            textBox11.Enabled = !durum;
            textBox12.Enabled = !durum;
            textBox13.Enabled = !durum;

            comboBox1.Enabled = !durum;
            dateTimePicker1.Enabled = !durum;
            dateTimePicker2.Enabled = !durum;

            musteriListesiToolStripMenuItem.Enabled = !durum;
            urunListesiToolStripMenuItem.Enabled = !durum;            
        }
        private void Btnyeni_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            Kayitlar(-11111);
            ToplamTutarBul();
            BtnKontrol(false);
            faturaSatisUstBindingSource.AddNew();
            faturaSatisUstBindingSource.EndEdit();            
            comboBox1.Text = "Peşin";
            textBox6.Text = (AnaSayfa.MasaNumarasi.ToString());

        }
        private void Btnduzelt_Click(object sender, EventArgs e)
        {
            BtnKontrol(false);
        }

        private void Btnvazgec_Click(object sender, EventArgs e)
        {
            AktifKayitUst = (DataRowView)faturaSatisUstBindingSource.Current;
            fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());
            Kayitlar(fustid);
            BtnKontrol(true);
            ToplamTutarBul();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            BtnKontrol(true);
            siparisBindingSource.MoveFirst();
            for (int j = 1; j <= siparisBindingSource.Count; j++)
            {
                AktifKayitSiparis = (DataRowView)siparisBindingSource.Current;                
                if (AktifKayitSiparis["Siparisid"].ToString() == textBox6.Text)
                {
                    AktifKayitSiparis["Siparisno"] = 1;
                    gelenSayi = 0;
                }
                siparisBindingSource.MoveNext();
            }
            AktifKayitSiparis["Siparisno"] = 1;
            siparisBindingSource.EndEdit();
            siparisTableAdapter.Update(cafeOtomasyonuDataSet.Siparis);
            cafeOtomasyonuDataSet.Siparis.AcceptChanges();
            
            faturaSatisUstBindingSource.EndEdit();
            faturaSatisUstTableAdapter.Update(cafeOtomasyonuDataSet.FaturaSatisUst);
            cafeOtomasyonuDataSet.FaturaSatisUst.AcceptChanges();

            AktifKayitUst = (DataRowView)faturaSatisUstBindingSource.Current;
            fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());

            faturaSatisDetayBindingSource.MoveFirst();

            DataRowView AktifKayitDetay;
            for (int i = 1; i <= faturaSatisDetayBindingSource.Count; i++)
            {
                AktifKayitDetay = (DataRowView)faturaSatisDetayBindingSource.Current;
                AktifKayitDetay["fustid"] = fustid;
                faturaSatisDetayBindingSource.MoveNext();
            }

            faturaSatisDetayBindingSource.EndEdit();
            faturaSatisDetayTableAdapter.Update(cafeOtomasyonuDataSet.FaturaSatisDetay);
            cafeOtomasyonuDataSet.FaturaSatisDetay.AcceptChanges();           
        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            DialogResult sil;
            sil = MessageBox.Show("Bu Kayıt Silinecek. Onaylıyormusunuz?", "silme", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (sil == DialogResult.Yes)
            {
                for (int j = 1; j <= siparisBindingSource.Count; j++)
                {
                    AktifKayitSiparis = (DataRowView)siparisBindingSource.Current;
                    if (AktifKayitSiparis["Siparisid"].ToString() == textBox6.Text)
                    {
                        AktifKayitSiparis["Siparisno"] = 0;
                        gelenSayi = 0;
                    }
                    siparisBindingSource.MoveNext();
                }
                AktifKayitSiparis["Siparisno"] = 0;
                siparisBindingSource.EndEdit();
                siparisTableAdapter.Update(cafeOtomasyonuDataSet.Siparis);
                cafeOtomasyonuDataSet.Siparis.AcceptChanges();
                
                AktifKayitUst = (DataRowView)faturaSatisUstBindingSource.Current;
                fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());
                faturaSatisUstTableAdapter.KayitSil(fustid);
                faturaSatisDetayTableAdapter.KayitSil(fustid);
                Kayitlar(fustid);
                
                ToplamTutarBul();
            }
        }

        private void Btnkapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            int basilantus;
            basilantus = Convert.ToInt32((byte)e.KeyChar);

            if (basilantus == 13)
                UrunBul();
        }

       
        private void urunListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            uid = "Kayıt Seçilmedi";
            UrunListesi yeni = new UrunListesi();
            UrunListesi.GelenForm1 = "FaturaSatis";
            yeni.ShowDialog();

            if (uid == "Kayıt Seçilmedi") return;
            UrunEkle();
            ToplamTutarBul();
        }
        private void UrunEkle()
        {
            faturaSatisDetayBindingSource.AddNew();
            faturaSatisDetayBindingSource.EndEdit();

            DataRowView AktifKayitDetay;
            AktifKayitDetay = (DataRowView)faturaSatisDetayBindingSource.Current;

            AktifKayitDetay["uckod"] = uid;
            AktifKayitDetay["barkod"] = barkodu;
            AktifKayitDetay["urun"] = urunadi;
            AktifKayitDetay["fiyat"] = fiyat;
            AktifKayitDetay["kdv"] = kdv;
            AktifKayitDetay["miktar"] = 1;
            AktifKayitDetay["tutar"] = fiyat;
            
        }       

        private void satirSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faturaSatisDetayBindingSource.Count == 0) return;
            faturaSatisDetayBindingSource.RemoveCurrent();
            ToplamTutarBul();
        }

        private void musteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Btnyeni.Enabled == false)
            {
                genelid = "-1";
                MusteriListesi yeni = new MusteriListesi();
                MusteriListesi.GelenForm = "FaturaSatis";
                yeni.ShowDialog();

                if (genelid == "-1") return;
                {
                    DataRowView aktifkayitust;
                    aktifkayitust = (DataRowView)faturaSatisUstBindingSource.Current;                    
                    aktifkayitust["ad"] = ad;
                    aktifkayitust["soyad"] = soyad;
                    aktifkayitust["unvan"] = unvan;
                    aktifkayitust["genelid"] = genelid;
                    
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                    comboBox1.Text = "Peşin";
                    textBox6.Text = (AnaSayfa.MasaNumarasi.ToString());
                }
            }
            else
            {
                fustid = -111;
                FaturaSatisListesi yeni = new FaturaSatisListesi();
                yeni.ShowDialog();
                if (fustid == -111) return;
                Kayitlar(fustid);
                ToplamTutarBul();
            }
            
            
        }

        private void FaturaSatis_FormClosing(object sender, FormClosingEventArgs e)//Form kapatıldığında değişiklik gösteren verilere göre masanın iconun ne olduğunu belirler.
        {
            if (gelenSayi == 0)
            {
                gelenSayi = 0;

                if (Convert.ToInt32(AktifKayitSiparis["Siparisno"]) == 1)
                {

                    if (AnaSayfa.anaSayfa.listView1.Items[AnaSayfa.MasaNumarasi - 1].ImageKey == "bosMasa.png")
                    {
                        AnaSayfa.anaSayfa.listView1.Items[AnaSayfa.MasaNumarasi - 1].ImageKey = "doluMasa.png";
                        AktifKayitSiparis["Siparisno"] = 0;
                    }
                    else
                    {
                        AnaSayfa.anaSayfa.listView1.Items[AnaSayfa.MasaNumarasi - 1].ImageKey = "doluMasa.png";
                        AktifKayitSiparis["Siparisno"] = 0;
                    }
                }
                else
                {
                    if (AnaSayfa.anaSayfa.listView1.Items[AnaSayfa.MasaNumarasi - 1].ImageKey == "doluMasa.png")
                    {
                        AnaSayfa.anaSayfa.listView1.Items[AnaSayfa.MasaNumarasi - 1].ImageKey = "bosMasa.png";
                        AktifKayitSiparis["Siparisno"] = 0;
                    }
                }
            }
        }

        private void UrunBul()
        {
            if (radioButton1.Checked)
                urunTanimTableAdapter.BarkodAyni(cafeOtomasyonuDataSet.UrunTanim, textBox13.Text.Trim());
            else
                urunTanimTableAdapter.AdiAyniOlan(cafeOtomasyonuDataSet.UrunTanim, textBox13.Text.Trim());
            textBox13.Text = "";
            if (urunTanimBindingSource.Count == 0)
            {
                MessageBox.Show("Ürün Bulunamadı");
                return;
            }

            DataRowView SecilenKayit;
            SecilenKayit = (DataRowView)urunTanimBindingSource.Current;
            uid = SecilenKayit["ckod"].ToString();
            urunadi = SecilenKayit["ad"].ToString();
            barkodu = SecilenKayit["barkodu"].ToString();
            if (SecilenKayit["fiyat"].ToString().Trim() == "")
                fiyat = 0;
            else
                fiyat = Convert.ToDouble(SecilenKayit["fiyat"].ToString());
            if (SecilenKayit["kdv"].ToString().Trim() == "")
                kdv = 0;
            else
                kdv = Convert.ToDouble(SecilenKayit["kdv"].ToString());

            UrunEkle();
            faturaSatisDetayBindingSource.MoveLast();
            ToplamTutarBul();
        }
        private void TutarBul()
        {

            double ttutar = 0, miktar = 0, fiyat = 0, kdv = 0;
            double ToplamTutar = 0, ToplamKdv = 0, GenelToplam = 0, tutar = 0;
            int kayitsirasi = 0;
            if (faturaSatisDetayBindingSource.Count == 0) return;

            kayitsirasi = faturaSatisDetayBindingSource.Position;

            if (textBox9.Text.Trim() == "")
                textBox9.Text = "0";
            if (textBox10.Text.Trim() == "")
                textBox10.Text = "";
            if (textBox11.Text.Trim() == "")
                textBox11.Text = "";
            miktar = Convert.ToDouble(textBox9.Text.Trim());
            fiyat = Convert.ToDouble(textBox10.Text.Trim());
            kdv = Convert.ToDouble(textBox11.Text.Trim());
            ttutar = miktar * fiyat;
            textBox12.Text = tutar.ToString();
            
            faturaSatisDetayBindingSource.MovePrevious();
            faturaSatisDetayBindingSource.MoveNext();
            ToplamTutarBul();
            faturaSatisDetayBindingSource.Position = kayitsirasi;
        }

        private void ToplamTutarBul()
        {
            double ToplamTutar = 0, ToplamKdv = 0, GenelToplam = 0, tutar = 0;
            int kayitsayisi;
            DataRowView AktifKayit;
            kayitsayisi = faturaSatisDetayBindingSource.Count;
            faturaSatisDetayBindingSource.MoveFirst();
            
                for (int i = 1; i <= kayitsayisi; i++)
                {
                    AktifKayit = (DataRowView)faturaSatisDetayBindingSource.Current;
                    tutar = Convert.ToDouble(AktifKayit["tutar"].ToString());
                    kdv = Convert.ToDouble(AktifKayit["kdv"].ToString());
                    ToplamKdv = ToplamKdv + tutar * kdv / 100;
                    ToplamTutar = ToplamTutar + tutar;
                    faturaSatisDetayBindingSource.MoveNext();
                }           

            GenelToplam = ToplamTutar + ToplamKdv;
            label19.Text = ToplamTutar.ToString();
            label20.Text = ToplamKdv.ToString();
            label21.Text = GenelToplam.ToString();

        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            int basilantus;
            basilantus = Convert.ToInt32((byte)e.KeyChar);

            if ((basilantus < 48 || basilantus > 57) && (basilantus != 8) && (basilantus != 44))
                e.Handled = true;
            if (basilantus == 13)
                TutarBul();
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            int basilantus;
            basilantus = Convert.ToInt32((byte)e.KeyChar);

            if ((basilantus < 48 || basilantus > 57) && (basilantus != 8) && (basilantus != 44))
                e.Handled = true;
            if (basilantus == 13)
                TutarBul();
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            TutarBul();
        }
        private void textBox10_Leave(object sender, EventArgs e)
        {
            TutarBul();
        }

    }
}
