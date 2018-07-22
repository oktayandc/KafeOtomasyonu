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
    public partial class UrunListesi : Form
    {
        public UrunListesi()
        {
            InitializeComponent();
        }

        public static string GelenForm, GelenForm1 ;

        private void UrunListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.UrunTanim' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.urunTanimTableAdapter.Fill(this.cafeOtomasyonuDataSet.UrunTanim);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            urunTanimTableAdapter.ad(cafeOtomasyonuDataSet.UrunTanim, '%' + textBox1.Text + '%');
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//İstenilen forma göre ürün bilgilerinin gönderilmesi sağlanır.
        {
            DataRowView SecilenKayit;
            SecilenKayit = (DataRowView)urunTanimBindingSource.Current;
            if(GelenForm == "FaturaAlis")
            {
                FaturaAlis.uid = SecilenKayit["ckod"].ToString();
                FaturaAlis.urunadi = SecilenKayit["ad"].ToString();
                FaturaAlis.barkodu = SecilenKayit["barkodu"].ToString();
                if (SecilenKayit["fiyat"].ToString().Trim() == "")
                    FaturaAlis.fiyat = 0;
                else
                    FaturaAlis.fiyat = Convert.ToDouble(SecilenKayit["fiyat"].ToString());
                if (SecilenKayit["kdv"].ToString().Trim() == "")
                    FaturaAlis.kdv = 0;
                else
                    FaturaAlis.kdv = Convert.ToDouble(SecilenKayit["kdv"].ToString());
                
            }
            
            DataRowView SecilenKayit1;
            SecilenKayit1 = (DataRowView)urunTanimBindingSource.Current;
            if (GelenForm1 == "FaturaSatis")
            {
                FaturaSatis.uid = SecilenKayit1["ckod"].ToString();
                FaturaSatis.urunadi = SecilenKayit1["ad"].ToString();
                FaturaSatis.barkodu = SecilenKayit1["barkodu"].ToString();
                if (SecilenKayit1["fiyat"].ToString().Trim() == "")
                    FaturaSatis.fiyat = 0;
                else
                    FaturaSatis.fiyat = Convert.ToDouble(SecilenKayit1["fiyat"].ToString());
                if (SecilenKayit1["kdv"].ToString().Trim() == "")
                    FaturaSatis.kdv = 0;
                else
                    FaturaSatis.kdv = Convert.ToDouble(SecilenKayit1["kdv"].ToString());                
            }            
            Close();

        }
    }
}
