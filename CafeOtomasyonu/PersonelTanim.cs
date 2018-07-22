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
    public partial class PersonelTanim : Form
    {
        public PersonelTanim()
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
            textBox5.Enabled = !deger;
            maskedTextBox1.Enabled = !deger;

        }
        private void PersonelTanim_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'cafeOtomasyonuDataSet.PersonelTanim' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTanimTableAdapter.Fill(this.cafeOtomasyonuDataSet.PersonelTanim);
            btnKontrol(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
            personelTanimBindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnKontrol(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            personelTanimBindingSource.CancelEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKontrol(true);
            personelTanimBindingSource.EndEdit();
            personelTanimTableAdapter.Update(cafeOtomasyonuDataSet.PersonelTanim);
            cafeOtomasyonuDataSet.PersonelTanim.AcceptChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sil;
            sil = MessageBox.Show("Bu kayıt silinicek. Onaylıyor musunuz?", "Silme",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            if ( sil == DialogResult.Yes)
            {
                personelTanimBindingSource.RemoveCurrent();
                personelTanimTableAdapter.Update(cafeOtomasyonuDataSet.PersonelTanim);
                cafeOtomasyonuDataSet.PersonelTanim.AcceptChanges();
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            personelTanimBindingSource.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            personelTanimBindingSource.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            personelTanimBindingSource.MovePrevious();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            personelTanimBindingSource.MoveLast();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                personelTanimTableAdapter.ad(cafeOtomasyonuDataSet.PersonelTanim, '%' + textBox6.Text + '%');
            else
                personelTanimTableAdapter.soyad(cafeOtomasyonuDataSet.PersonelTanim, '%' + textBox6.Text + '%');
        }
    }
}
