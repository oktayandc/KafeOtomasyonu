namespace CafeOtomasyonu
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tanimlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musteriTanimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelTanimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunTanimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musteriListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rehberListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satisAlisİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cafeOtomasyonuDataSet = new CafeOtomasyonu.CafeOtomasyonuDataSet();
            this.masaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masaTableAdapter = new CafeOtomasyonu.CafeOtomasyonuDataSetTableAdapters.MasaTableAdapter();
            this.siparisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siparisTableAdapter = new CafeOtomasyonu.CafeOtomasyonuDataSetTableAdapters.SiparisTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cafeOtomasyonuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tanimlarToolStripMenuItem,
            this.listelerToolStripMenuItem,
            this.satisAlisİToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tanimlarToolStripMenuItem
            // 
            this.tanimlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteriTanimToolStripMenuItem,
            this.personelTanimToolStripMenuItem,
            this.urunTanimToolStripMenuItem});
            this.tanimlarToolStripMenuItem.Name = "tanimlarToolStripMenuItem";
            this.tanimlarToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.tanimlarToolStripMenuItem.Text = "Tanimlar";
            // 
            // musteriTanimToolStripMenuItem
            // 
            this.musteriTanimToolStripMenuItem.Name = "musteriTanimToolStripMenuItem";
            this.musteriTanimToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.musteriTanimToolStripMenuItem.Text = "MusteriTanim";
            this.musteriTanimToolStripMenuItem.Click += new System.EventHandler(this.musteriTanimToolStripMenuItem_Click);
            // 
            // personelTanimToolStripMenuItem
            // 
            this.personelTanimToolStripMenuItem.Name = "personelTanimToolStripMenuItem";
            this.personelTanimToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.personelTanimToolStripMenuItem.Text = "PersonelTanim";
            this.personelTanimToolStripMenuItem.Click += new System.EventHandler(this.personelTanimToolStripMenuItem_Click);
            // 
            // urunTanimToolStripMenuItem
            // 
            this.urunTanimToolStripMenuItem.Name = "urunTanimToolStripMenuItem";
            this.urunTanimToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.urunTanimToolStripMenuItem.Text = "UrunTanim";
            this.urunTanimToolStripMenuItem.Click += new System.EventHandler(this.urunTanimToolStripMenuItem_Click);
            // 
            // listelerToolStripMenuItem
            // 
            this.listelerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musteriListesiToolStripMenuItem,
            this.personelListesiToolStripMenuItem,
            this.urunListesiToolStripMenuItem,
            this.rehberListesiToolStripMenuItem});
            this.listelerToolStripMenuItem.Name = "listelerToolStripMenuItem";
            this.listelerToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.listelerToolStripMenuItem.Text = "Listeler";
            // 
            // musteriListesiToolStripMenuItem
            // 
            this.musteriListesiToolStripMenuItem.Name = "musteriListesiToolStripMenuItem";
            this.musteriListesiToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.musteriListesiToolStripMenuItem.Text = "Musteri Listesi";
            this.musteriListesiToolStripMenuItem.Click += new System.EventHandler(this.musteriListesiToolStripMenuItem_Click);
            // 
            // personelListesiToolStripMenuItem
            // 
            this.personelListesiToolStripMenuItem.Name = "personelListesiToolStripMenuItem";
            this.personelListesiToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.personelListesiToolStripMenuItem.Text = "Personel Listesi";
            this.personelListesiToolStripMenuItem.Click += new System.EventHandler(this.personelListesiToolStripMenuItem_Click);
            // 
            // urunListesiToolStripMenuItem
            // 
            this.urunListesiToolStripMenuItem.Name = "urunListesiToolStripMenuItem";
            this.urunListesiToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.urunListesiToolStripMenuItem.Text = "Urun Listesi";
            this.urunListesiToolStripMenuItem.Click += new System.EventHandler(this.urunListesiToolStripMenuItem_Click);
            // 
            // rehberListesiToolStripMenuItem
            // 
            this.rehberListesiToolStripMenuItem.Name = "rehberListesiToolStripMenuItem";
            this.rehberListesiToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.rehberListesiToolStripMenuItem.Text = "Rehber Listesi";
            this.rehberListesiToolStripMenuItem.Click += new System.EventHandler(this.rehberListesiToolStripMenuItem_Click);
            // 
            // satisAlisİToolStripMenuItem
            // 
            this.satisAlisİToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satisToolStripMenuItem,
            this.alisToolStripMenuItem});
            this.satisAlisİToolStripMenuItem.Name = "satisAlisİToolStripMenuItem";
            this.satisAlisİToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.satisAlisİToolStripMenuItem.Text = "Satis/Alis Islemleri";
            // 
            // satisToolStripMenuItem
            // 
            this.satisToolStripMenuItem.Name = "satisToolStripMenuItem";
            this.satisToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.satisToolStripMenuItem.Text = "Satis";
            this.satisToolStripMenuItem.Click += new System.EventHandler(this.satisToolStripMenuItem_Click);
            // 
            // alisToolStripMenuItem
            // 
            this.alisToolStripMenuItem.Name = "alisToolStripMenuItem";
            this.alisToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.alisToolStripMenuItem.Text = "Alis";
            this.alisToolStripMenuItem.Click += new System.EventHandler(this.alisToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(555, 355);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bosMasa.png");
            this.imageList1.Images.SetKeyName(1, "doluMasa.png");
            // 
            // cafeOtomasyonuDataSet
            // 
            this.cafeOtomasyonuDataSet.DataSetName = "CafeOtomasyonuDataSet";
            this.cafeOtomasyonuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // masaBindingSource
            // 
            this.masaBindingSource.DataMember = "Masa";
            this.masaBindingSource.DataSource = this.cafeOtomasyonuDataSet;
            // 
            // masaTableAdapter
            // 
            this.masaTableAdapter.ClearBeforeFill = true;
            // 
            // siparisBindingSource
            // 
            this.siparisBindingSource.DataMember = "Siparis";
            this.siparisBindingSource.DataSource = this.cafeOtomasyonuDataSet;
            // 
            // siparisTableAdapter
            // 
            this.siparisTableAdapter.ClearBeforeFill = true;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 383);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cafeOtomasyonuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siparisBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tanimlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriTanimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelTanimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunTanimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musteriListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rehberListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satisAlisİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alisToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ListView listView1;
        private CafeOtomasyonuDataSet cafeOtomasyonuDataSet;
        private System.Windows.Forms.BindingSource masaBindingSource;
        private CafeOtomasyonuDataSetTableAdapters.MasaTableAdapter masaTableAdapter;
        private System.Windows.Forms.BindingSource siparisBindingSource;
        private CafeOtomasyonuDataSetTableAdapters.SiparisTableAdapter siparisTableAdapter;
    }
}