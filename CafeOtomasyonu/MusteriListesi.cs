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
    public partial class MusteriListesi : Form
    {
        public MusteriListesi()
        {
            InitializeComponent();
        }
        public static string GelenForm, GelenForm1,mid;

        private void MusteriListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.MusteriTanim' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.musteriTanimTableAdapter.Fill(this.cafeOtomasyonuDataSet.MusteriTanim);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                musteriTanimTableAdapter.ad(cafeOtomasyonuDataSet.MusteriTanim, '%' + textBox6.Text + '%');
            else
                musteriTanimTableAdapter.soyad(cafeOtomasyonuDataSet.MusteriTanim, '%' + textBox6.Text + '%');
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//istenilen form için müşteri bilgilerini seçmemizi sağlar.
        {
            DataRowView secilenkayit;
            secilenkayit = (DataRowView)musteriTanimBindingSource.Current;

            if (GelenForm == "FaturaSatis")
            {
                FaturaSatis.mid = secilenkayit["ckod"].ToString();
                FaturaSatis.genelid = secilenkayit["ckod"].ToString();
                FaturaSatis.ad = secilenkayit["ad"].ToString();
                FaturaSatis.soyad = secilenkayit["soyad"].ToString();
                FaturaSatis.unvan = secilenkayit["ad"] + " " + secilenkayit["soyad"].ToString();
                mid = secilenkayit["ckod"].ToString();
            }
            Close();
            DataRowView secilenkayit2;
            secilenkayit2 = (DataRowView)musteriTanimBindingSource.Current;
            if (GelenForm1 == "FaturaAlis")
            {
                FaturaAlis.genelid = secilenkayit2["ckod"].ToString();
                FaturaAlis.ad = secilenkayit2["ad"].ToString();
                FaturaAlis.soyad = secilenkayit2["soyad"].ToString();
                FaturaAlis.unvan = secilenkayit2["ad"] + " " + secilenkayit2["soyad"].ToString();
            }             
               
            Close();
        }
    }
}
