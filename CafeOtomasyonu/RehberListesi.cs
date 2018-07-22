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
    public partial class RehberListesi : Form
    {
        public RehberListesi()
        {
            InitializeComponent();
        }

        private void RehberListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.RehberListesi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.rehberListesiTableAdapter.Fill(this.cafeOtomasyonuDataSet.RehberListesi);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                rehberListesiTableAdapter.ad(cafeOtomasyonuDataSet.RehberListesi, '%' + textBox6.Text + '%');
            else
                rehberListesiTableAdapter.soyad(cafeOtomasyonuDataSet.RehberListesi, '%' + textBox6.Text + '%');
            
        }
    }
}
