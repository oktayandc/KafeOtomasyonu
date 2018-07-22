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
    public partial class FaturaAlis : Form
    {
        public FaturaAlis()
        {
            InitializeComponent();
        }
        public static string ad, soyad, unvan, genelid;
        public static string uid, barkodu, urunadi;            
        public static double kdv, fiyat;

        public static int fustid;
        DataRowView AktifKayitUst;
               
        private void FaturaAlis_Load(object sender, EventArgs e)
        {
            BtnKontrol(true);
            Kayitlar(-11111);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            

        }
        private void Kayitlar(int id)
        {
            faturaAlisUstTableAdapter.Fill(cafeOtomasyonuDataSet.FaturaAlisUst, id);
            faturaAlisDetayTableAdapter.Fill(cafeOtomasyonuDataSet.FaturaAlisDetay, id);
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

            comboBox1.Enabled = !durum;
            dateTimePicker1.Enabled = !durum;
            dateTimePicker2.Enabled = !durum;

            musteriListesiToolStripMenuItem.Enabled = !durum;
            urunListesiToolStripMenuItem.Enabled = !durum;            

        }
        private void urunListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            uid = "Kayit Seçilmedi";
            UrunListesi yeni = new UrunListesi();
            UrunListesi.GelenForm = "FaturaAlis";
            yeni.ShowDialog();            

            if (uid == "Kayit Seçilmedi") return;
            UrunEkle();
            ToplamTutarBul();

        }
        private void musteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Btnyeni.Enabled == false)
            {
                genelid = "1";

                MusteriListesi yeni = new MusteriListesi();
                MusteriListesi.GelenForm1 = "FaturaAlis";
                yeni.ShowDialog();

                if (genelid == "1") return;
                {
                    DataRowView AktifKayitUst;
                    AktifKayitUst = (DataRowView)faturaAlisUstBindingSource.Current;
                    AktifKayitUst["ad"] = ad;
                    AktifKayitUst["soyad"] = soyad;
                    AktifKayitUst["unvan"] = unvan;
                    AktifKayitUst["genelid"] = genelid;
                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                }
            }
            else
            {
                fustid = -111;
                FaturaAlisListesi yeni = new FaturaAlisListesi();
                yeni.ShowDialog();
                if (fustid == -111) return;
                Kayitlar(fustid);
                ToplamTutarBul();
            }           
            
        }
        private void satirSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faturaAlisDetayBindingSource.Count == 0) return;
            faturaAlisDetayBindingSource.RemoveCurrent();
            ToplamTutarBul();
        }
        private void Btnyeni_Click(object sender, EventArgs e)
        {
            DateTime tarih;
            textBox1.Focus();
            Kayitlar(-11111);

            ToplamTutarBul();
                        
            faturaAlisUstBindingSource.AddNew();
            faturaAlisUstBindingSource.EndEdit();
            BtnKontrol(false);

            comboBox1.Text = "Peşin";
            tarih = DateTime.Today;
            dateTimePicker1.Value = tarih;
        }              
        private void Btnduzelt_Click(object sender, EventArgs e)
        {
            BtnKontrol(false);
        }       
        private void Btnvazgec_Click(object sender, EventArgs e)
        {
            BtnKontrol(true);
            AktifKayitUst = (DataRowView)faturaAlisUstBindingSource.Current;
            fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());
            Kayitlar(fustid);
            ToplamTutarBul();
        }
        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            BtnKontrol(true);
            faturaAlisUstBindingSource.EndEdit();
            faturaAlisUstTableAdapter.Update(cafeOtomasyonuDataSet.FaturaAlisUst);
            cafeOtomasyonuDataSet.FaturaSatisUst.AcceptChanges();

            AktifKayitUst = (DataRowView)faturaAlisUstBindingSource.Current;
            fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());

            faturaAlisDetayBindingSource.MoveFirst();

            DataRowView AktifKayitDetay;
            for (int i = 1; i <= faturaAlisDetayBindingSource.Count; i++)
            {
                AktifKayitDetay = (DataRowView)faturaAlisDetayBindingSource.Current;
                AktifKayitDetay["fustid"] = fustid;
                faturaAlisDetayBindingSource.MoveNext();
            }

            faturaAlisDetayBindingSource.EndEdit();
            faturaAlisDetayTableAdapter.Update(cafeOtomasyonuDataSet.FaturaAlisDetay);
            cafeOtomasyonuDataSet.FaturaSatisDetay.AcceptChanges();
        }
        private void Btnsil_Click(object sender, EventArgs e)
        {
            DialogResult sil;
            sil = MessageBox.Show("Bu Kayıt Silinecek. Onaylıyormusunuz?", "silme", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (sil == DialogResult.Yes)
            {
                AktifKayitUst = (DataRowView)faturaAlisUstBindingSource.Current;
                fustid = Convert.ToInt32(AktifKayitUst["fustid"].ToString());
                faturaAlisUstTableAdapter.KayitSil(fustid);
                faturaAlisDetayTableAdapter.KayitSil(fustid);
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
        private void UrunEkle()
        {
            faturaAlisDetayBindingSource.AddNew();
            faturaAlisDetayBindingSource.EndEdit();            
            DataRowView AktifKayitDetay;
            AktifKayitDetay = (DataRowView)faturaAlisDetayBindingSource.Current;

            AktifKayitDetay["uckod"] = uid;
            AktifKayitDetay["barkod"] = barkodu;
            AktifKayitDetay["urun"] = urunadi;
            AktifKayitDetay["fiyat"] = fiyat;
            AktifKayitDetay["kdv"] = kdv;            
            AktifKayitDetay["miktar"] = 1;
            AktifKayitDetay["tutar"] = fiyat;
        }

        private void UrunBul()
        {
            if (radioButton1.Checked)
                urunTanimTableAdapter.BarkodAyni(cafeOtomasyonuDataSet.UrunTanim, textBox13.Text.Trim());
            else
                urunTanimTableAdapter.AdiAyniOlan(cafeOtomasyonuDataSet.UrunTanim, textBox13.Text.Trim());

            textBox13.Text = "";
            if(urunTanimBindingSource.Count == 0)
            {
                MessageBox.Show("Ürün Bulunamadı !");
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
            faturaAlisDetayBindingSource.MoveLast();
            ToplamTutarBul();
        }

        private void TutarBul()
        {
            
            double tutar = 0, miktar = 0, fiyat = 0, kdv = 0;
            int kayitsirasi = 0;
            if (faturaAlisDetayBindingSource.Count == 0) return;

            kayitsirasi = faturaAlisDetayBindingSource.Position;

            if (textBox9.Text.Trim() == "")
                textBox9.Text = "0";
            if (textBox10.Text.Trim() == "")
                textBox10.Text = "";
            if (textBox11.Text.Trim() == "")
                textBox11.Text = "";
            miktar = Convert.ToDouble(textBox9.Text.Trim());
            fiyat = Convert.ToDouble(textBox10.Text.Trim());
            kdv = Convert.ToDouble(textBox11.Text.Trim());
            tutar = miktar * fiyat;
            textBox12.Text = tutar.ToString();

            faturaAlisDetayBindingSource.MovePrevious();
            faturaAlisDetayBindingSource.MoveNext();
            ToplamTutarBul();
            faturaAlisDetayBindingSource.Position = kayitsirasi;
        }

        private void ToplamTutarBul()
        {
            double ToplamTutar = 0, ToplamKdv = 0, GenelToplam = 0, tutar = 0;
            int kayitsayisi;
            DataRowView AktifKayit;
            kayitsayisi = faturaAlisDetayBindingSource.Count;
            faturaAlisDetayBindingSource.MoveFirst();

            for (int i = 1; i <= kayitsayisi; i++)
            {
                AktifKayit = (DataRowView)faturaAlisDetayBindingSource.Current;
                tutar = Convert.ToDouble(AktifKayit["tutar"].ToString());
                kdv = Convert.ToDouble(AktifKayit["kdv"].ToString());
                ToplamKdv = ToplamKdv + tutar * kdv / 100;
                ToplamTutar = ToplamTutar + tutar;
                faturaAlisDetayBindingSource.MoveNext();
            }          
            
            GenelToplam = ToplamTutar + ToplamKdv;
            label19.Text = ToplamTutar.ToString();
            label20.Text = ToplamKdv.ToString();
            label21.Text = GenelToplam.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox11_Leave(object sender, EventArgs e)
        {
            TutarBul();
        }
        
    }
}
