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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        public static int MasaNumarasi;
        public static int masaNo;
        public static AnaSayfa anaSayfa;
        

        private void musteriTanimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriTanim yeni = new MusteriTanim();
            yeni.ShowDialog();
        }

        private void urunTanimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunTanim yeni = new UrunTanim();
            yeni.ShowDialog();
        }

        private void personelTanimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelTanim yeni = new PersonelTanim();
            yeni.ShowDialog();
        }

        private void musteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriListesi yeni = new MusteriListesi();
            yeni.ShowDialog();
        }

        private void urunListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunListesi yeni = new UrunListesi();
            yeni.ShowDialog();
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelListesi yeni = new PersonelListesi();
            yeni.ShowDialog();
        }

        private void rehberListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RehberListesi yeni = new RehberListesi();
            yeni.ShowDialog();
        }

        private void satisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaturaSatis.gelenSayi = 1;
            FaturaSatis yeni = new FaturaSatis();
            yeni.ShowDialog();            
            //Application.Restart();
        }

        private void alisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaturaAlis yeni = new FaturaAlis();
            yeni.ShowDialog();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            anaSayfa = this;
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.Siparis' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.siparisTableAdapter.Fill(this.cafeOtomasyonuDataSet.Siparis);
            this.masaTableAdapter.Fill(this.cafeOtomasyonuDataSet.Masa);
            string sayi;
            DataRowView a;
            a = (DataRowView)masaBindingSource.Current;
            sayi = a["Masasayisi"].ToString();

            DataRowView b;
            siparisBindingSource.MoveFirst();
                        
            for (int i = 0; i < int.Parse(sayi); i++)//Bu for döngüsü ile masalar oluşturuluyor.
            {
                b = (DataRowView)siparisBindingSource.Current;
                string Sayi = b["Siparisid"].ToString();
                string No = b["Siparisno"].ToString();
                siparisBindingSource.MoveNext();
                if (i + 1 == (int.Parse(Sayi)) && (No == "0"))
                {
                    listView1.Items.Add((i + 1) + ".Masa");
                    listView1.Items[i].ImageKey = "bosMasa.png";                    
                }
                else
                {
                    listView1.Items.Add((i + 1) + ".Masa");
                    listView1.Items[i].ImageKey = "doluMasa.png";
                }
                                
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)//Masanın durumuna göre forma dolu veya boş bilgisini gönderir.
        {
            try
            {
                MasaNumarasi = (int.Parse(listView1.SelectedIndices[0].ToString()) + 1);
                if (listView1.Items[MasaNumarasi-1].ImageKey == "doluMasa.png")
                {
                    FaturaSatisListesi.DoluMasaFatura = 1;
                    FaturaSatis.gelenSayi = 1;
                    FaturaSatis fatura = new FaturaSatis();
                    fatura.ShowDialog();
                }
                else
                {
                    FaturaSatis.gelenSayi = 1;
                    FaturaSatis yeni = new FaturaSatis();
                    yeni.ShowDialog();                    
                }                   
                                
            }
            catch
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int masaNo = Convert.ToInt32(listView1.SelectedItems[0].Text.Substring(0, listView1.SelectedItems[0].Text.IndexOf('.')));

            }
        }
    }
}
