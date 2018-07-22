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
    public partial class UrunTanim : Form
    {
        public UrunTanim()
        {
            InitializeComponent();
        }
        private void btnKontrol(Boolean deger)
        {
            button1.Enabled = deger;
            button2.Enabled = deger;
            button5.Enabled = deger;

            button3.Enabled = !deger;
            button4.Enabled = !deger;
            textBox1.Enabled = !deger;
            textBox2.Enabled = !deger;
            textBox3.Enabled = !deger;
            textBox4.Enabled = !deger;
            textBox5.Enabled = !deger;
            textBox6.Enabled = !deger;
        }
        private void UrunTanim_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.UrunTanim' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.urunTanimTableAdapter.Fill(this.cafeOtomasyonuDataSet.UrunTanim);
            btnKontrol(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
            urunTanimBindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            urunTanimBindingSource.CancelEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            urunTanimBindingSource.EndEdit();
            urunTanimTableAdapter.Update(cafeOtomasyonuDataSet.UrunTanim);
            cafeOtomasyonuDataSet.UrunTanim.AcceptChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sil;
            sil = MessageBox.Show("Bu Kayıt Silinecek.Onaylıyormusunuz", "silme", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (sil == DialogResult.Yes)
            {
                urunTanimBindingSource.RemoveCurrent();
                urunTanimTableAdapter.Update(cafeOtomasyonuDataSet.UrunTanim);
                cafeOtomasyonuDataSet.UrunTanim.AcceptChanges();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            urunTanimBindingSource.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            urunTanimBindingSource.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            urunTanimBindingSource.MovePrevious();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            urunTanimBindingSource.MoveLast();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            urunTanimTableAdapter.ad(cafeOtomasyonuDataSet.UrunTanim, '%' + textBox7.Text + '%');
        }
    }
}
