using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace project2
{
    public partial class DataManifest : Form
    {
        static FileStream F;
        StreamWriter W, W1;
        string ValueUser;
        StreamReader R;
        private bool find;
        int kode, subTotal;
        string Str,kodebaru;
        string[] isi;
        public DataManifest()
        {
            InitializeComponent();
        }

        public string AutoGenerateResi()
        {
            FileStream OO = new FileStream("DataTransaksi.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader(OO);
            string datecod;
            textBox4.Text = DateTime.Now.Date.ToShortDateString();
            datecod = textBox4.Text;
            kode = 0;
            while ((Str = R.ReadLine()) != null)
            {
                string lastLine = File.ReadLines("DataTransaksi.txt").Last();
                if (lastLine != null)
                {
                    isi = lastLine.Split('#');
                    kode = Convert.ToInt32(isi[0].Substring(1, 2));
                    kode = kode + 1;
                    if (kode < 10)
                    {
                        TxNoresi.Text = "R0"  + kode;
                    }
                    else if (kode >= 10 && kode < 99)
                    {
                        TxNoresi.Text = "R" + kode;
                    }
                    else if (kode >= 100)
                    {
                        TxNoresi.Text = "FULL";
                    }

                    R.Close();
                    OO.Close();
                    return TxNoresi.Text;
                }
            }
            TxNoresi.Text = "R01";
            R.Close();
            OO.Close();
            return TxNoresi.Text;
        }

        //public void AutoGenResiTemp()
        //{
        //    int i;
        //    if(int.TryParse(textBox2.Text, out i))
        //    {
        //        textBox2.Text = (i + 1).ToString();
        //    }
        //}
        

        public void Total()
        {

          
                int berat, total, ongkir, Service, volume, hargaproduk;
                berat = Convert.ToInt32(this.txBerat.Text);
                volume = Convert.ToInt32(this.TxVolResult.Text);
                ongkir = Convert.ToInt32(this.txOngkir.Text);
                Service = Convert.ToInt32(this.TxService.Text);
                hargaproduk = Convert.ToInt32(this.textBox2.Text);

            total = ((berat + volume) * ongkir) + Service+hargaproduk;

            txTotal.Text = Convert.ToString(total);
                
            
        }
     

        public void isicombo()
        {
            string[] lineofcontent = File.ReadAllLines("daftarKotaKab.txt");
            foreach (var line in lineofcontent)

            {
                string[] token = line.Split('#');
                cmbkotatujuan.Items.Add(token[0]);
               
            }
        }
        public string searchAsuransi()
        {
            string line, cari, strPrice = "";
            string[] strArray = new string[8];

            F = new FileStream("Service.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader(F);

            cari = cmbservice.SelectedItem.ToString();
            while ((line = R.ReadLine()) != null)
            {
                int stringStartPos = line.IndexOf('#');
                if (cari.Equals(line.Substring(0, stringStartPos)))
                {
                    strArray = line.Split(new string[] { "#" }, StringSplitOptions.None);
                }
                strPrice = strArray[1];
            }
            F.Close();
            R.Close();
            return strPrice;
        }
        public string searchHargaProduk()
        {
            string line, cari, strPrice = "";
            string[] strArray = new string[4];

            F = new FileStream("Produk.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader(F);

            cari = cmbproduk.SelectedItem.ToString();
            while ((line = R.ReadLine()) != null)
            {
                int stringStartPos = line.IndexOf('#');
                if (cari.Equals(line.Substring(0, stringStartPos)))
                {
                    strArray = line.Split(new string[] { "#" }, StringSplitOptions.None);
                }
                strPrice = strArray[3];
            }
            F.Close();
            R.Close();
            return strPrice;
        }
        public string searchOngkir()
        {
            string line, cari, strPrice = "";
            string[] strArray = new string[8];

            F = new FileStream("daftarKotaKab.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader(F);

            cari = cmbkotatujuan.SelectedItem.ToString();
            while ((line = R.ReadLine()) != null)
            {
                int stringStartPos = line.IndexOf('#');
                if (cari.Equals(line.Substring(0, stringStartPos)))
                {
                    strArray = line.Split(new string[] { "#" }, StringSplitOptions.None);
                }
                strPrice = strArray[1];
            }
            F.Close();
            R.Close();
            return strPrice;
        }
        public string codeCategory()
        {
            string codcat = "", strcode = "";
            strcode = cmbkotatujuan.SelectedItem.ToString();
            string[] elemen = strcode.Split(' ');
            codcat = elemen[1];
            txOngkir.Text = codcat;
            return codcat;

        }
        public void callProduk()
        {
            if (cmbproduk.Text == "SDS")
            {
                TxProduk2.Text = "SAME DAY SERVICE";
                textBox2.Text = "25000";
             
            }
            else if (cmbproduk.Text == "ONS")
            {
                TxProduk2.Text = "ONE NIGHT SERVICE";
                textBox2.Text = "14000";
            }
            else if (cmbproduk.Text == "TDS")
            {
                TxProduk2.Text = "THREE DAY SERVICE";
                textBox2.Text = "13000";
            }
            else if (cmbproduk.Text == "HDS")
            {
                TxProduk2.Text = "HOLIDAY SERVICE";
                textBox2.Text = "9000";
            }
            else if (cmbproduk.Text == "REG")
            {
                TxProduk2.Text = "REGULAR";
                textBox2.Text = "7000";
            }
            else if (cmbproduk.Text == "ECO")
            {
                TxProduk2.Text = "ECONOMY";
                textBox2.Text = "5000";
            }
            else
            {
                return;
            }

        }

        public void bersih()
        {
            cmbkotatujuan.Text = "";
            cmbproduk.Text = "";
            TxProduk2.Text = "";
            cmbservice.Text = "";
            TxService.Text = "";
            textBox1.Text = "";
            cmbTipeKiriman.Text = "";
            txBerat.Text = "0";
            TxP.Text = "0";
            TxL.Text = "0";
            TxT.Text = "0";
            TxVolResult.Text = "0";
            txNamaPenerima.Text = "";
            txPerusahaan1.Text = "";
            txAlamatPenerima.Text = "";
            txKodeposPenerima.Text = "";
            txHPPenerima.Text = "";
            txEmailPenerima.Text = "";
            txNamaPengirm.Text = "";
            txperusahaan2.Text = "";
            txalamatpengirm.Text = "";
            txkodepos2.Text = "";
            txnohp2.Text = "";
            emailpengirim.Text = "";
            txTotal.Text = "0";
            txOngkir.Text = "0";
            TxBayar.Text = "0";
            TxKembalian.Text = "0";

            dataGridView1.Rows.Clear();


        }
        public void produk()
        {
            string[] produkzet = File.ReadAllLines("Produk.txt");
            foreach (var line in produkzet)
            {
                string[] token = line.Split('#');
                cmbproduk.Items.Add(token[1] );
            }

        }
        public void Services()
        {
            string[] isiservice = File.ReadAllLines("Service.txt");
            foreach (var line in isiservice)
            {
                string[] token = line.Split('#');
                cmbservice.Items.Add(token[0]);

            }
        }

        public void Hitung()
        {

            float p, l, t;
            double Result;
            p = float.Parse(this.TxP.Text);
            l = float.Parse(this.TxL.Text);
            t = float.Parse(this.TxT.Text);
            Result = p * l * t / 6000;

            Result = Math.Round(Result, 0);
            if (Result < 1)
            {
                Result = 1;
            }


            this.TxVolResult.Text = Result.ToString();


        }

        public void VNN()
        {
            if (cmbkotatujuan.Text == "")
            {
                MessageBox.Show("Pilih Kota Tujuan");
                cmbkotatujuan.Focus();
            }
            else if (cmbservice.Text == "")
            {
                MessageBox.Show("Pilih Tipe Service");
                cmbservice.Focus();
            }
            else if (cmbproduk.Text == "")
            {
                MessageBox.Show("Pilih Tipe Produk");
                cmbproduk.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Masukan Isi Kiriman");
                textBox1.Focus();
            }

            else if (cmbTipeKiriman.Text == "")
            {
                MessageBox.Show("Pilih Tipe Kiriman");
                cmbTipeKiriman.Focus();
            }
            else if (txBerat.Text == "")
            {
                MessageBox.Show("Masukan Berat Kiriman");
                txBerat.Focus();
            }
            else if (TxP.Text == "")
            {
                MessageBox.Show("Masukan panjang Kiriman");
                TxP.Focus();
            }
            else if (TxL.Text == "")
            {
                MessageBox.Show("Masukan Lebar Kiriman");
                TxL.Focus();
            }
            else if (TxT.Text == "")
            {
                MessageBox.Show("Masukan Tinggi Kiriman");
                TxT.Focus();
            }
            else if (txNamaPenerima.Text == "")
            {
                MessageBox.Show("Masukan Nama Penerima");
                txNamaPenerima.Focus();
            }
            else if (txAlamatPenerima.Text == "")
            {
                MessageBox.Show("Masukan Alamat Penerima");
                txAlamatPenerima.Focus();
            }
            else if (txKodeposPenerima.Text == "")
            {
                MessageBox.Show("Masukan Kode Pos Penerima");
                txKodeposPenerima.Focus();
            }
            else if (txHPPenerima.Text == "")
            {
                MessageBox.Show("Masukan Nomor Telpon Penerima");
                txHPPenerima.Focus();
            }
            else if (txEmailPenerima.Text == "")
            {
                MessageBox.Show("Masukan Email Penerima");
                txEmailPenerima.Focus();
            }

            else if (txNamaPengirm.Text == "")
            {
                MessageBox.Show("Masukan Nama Pengirim");
                txNamaPengirm.Focus();
            }
            else if (txalamatpengirm.Text == "")
            {
                MessageBox.Show("Masukan Alamat Pengirim");
                txalamatpengirm.Focus();
            }
            else if (txkodepos2.Text == "")
            {
                MessageBox.Show("Masukan Kode Pos Pengirim");
                txkodepos2.Focus();
            }
            else if (txnohp2.Text == "")
            {
                MessageBox.Show("Masukan Nomor Telpon Pengirim");
                txnohp2.Focus();
            }
            else if (emailpengirim.Text == "")
            {
                MessageBox.Show("Masukan Email Pengirim");
                emailpengirim.Focus();
            }
            else if (TxBayar.Text == "0")
            {
                MessageBox.Show("Silahkan Bayar Dahulu");
                TxBayar.Focus();
            }
            else
            {
                sendtodatagrid();
                datatransaksi2();
            }
        }

        public void datatransaksi2()
        {
            string noresi, kotatujuan, produk, IsiKiriman, TipeKiriman, BeratKiriman, VolumeKiriman, servis,
                namaPenerima, perusahaan1, alamatPenerima, kodeposPenerima, nohp1, email1,
                namapengirim, perusahaan2, alamatpengirim, kodepospengirim, nohp2, email2, total, infokiriman;

            F = new FileStream("DataTransaksi.txt", FileMode.Append, FileAccess.Write);
            W = new StreamWriter(F);

            noresi = TxNoresi.Text;
            kotatujuan = cmbkotatujuan.Text;
            produk = cmbproduk.Text;
            IsiKiriman = textBox1.Text;
            TipeKiriman = cmbTipeKiriman.Text;
            BeratKiriman = txBerat.Text;
            VolumeKiriman = TxVolResult.Text;
            servis = cmbservice.Text;
            namaPenerima = txNamaPenerima.Text;
            perusahaan1 = txPerusahaan1.Text;
            alamatPenerima = txAlamatPenerima.Text;
            kodeposPenerima = txKodeposPenerima.Text;
            nohp1 = txHPPenerima.Text;
            email1 = txEmailPenerima.Text + "@Gmail.com";
            namapengirim = txNamaPengirm.Text;
            perusahaan2 = txperusahaan2.Text;
            alamatpengirim = txalamatpengirm.Text;
            kodepospengirim = txkodepos2.Text;
            nohp2 = txnohp2.Text;
            email2 = emailpengirim.Text + "@Gmail.com";
            infokiriman = txInfoKirim.Text;
            total = txTotal.Text;
            

            ValueUser = noresi + '#' + kotatujuan+ '#' + produk+ '#'+servis + "#"+ IsiKiriman+ '#' + TipeKiriman+ '#' + BeratKiriman + '#' 
            + VolumeKiriman + '#'  + namaPenerima+ '#' + perusahaan1+ '#' + alamatPenerima+ '#'
            + kodeposPenerima + '#' + email1 +'#' + nohp1+ '#' + namapengirim+ '#' + perusahaan2 + '#' + alamatpengirim+ '#'
            + kodepospengirim+ '#' + email2+ '#' + nohp2 + '#' + total+ '#' + infokiriman ;
            W.WriteLine(ValueUser);

            MessageBox.Show("Berhasil Disimpan");
            
            W.Close();
            F.Close();

        }

        public void DataTransaksi()
        {

            FileStream F = new FileStream("DataTransaksi.txt", FileMode.Append, FileAccess.Write);
            StreamWriter W = new StreamWriter(F);



            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.SelectAll();
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
            //File.WriteAllText(" DataTransaksi.txt", Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
            ValueUser = Clipboard.GetText(TextDataFormat.CommaSeparatedValue);

            MessageBox.Show("Data Has Beed Saved");
            W.WriteLine(ValueUser);
            W.Flush();
            W.Close();
            F.Close();
        }
        
        
        private void DataManifest_Load(object sender, EventArgs e)
        {
            TxP.Text = "0";
            TxL.Text = "0";
            TxT.Text = "0";
            txTotal.Text = "0";
            txOngkir.Text = "0";
            TxBayar.Text = "0";
            TxKembalian.Text = "0";
            TxStatusBarang.Text = "Belum Di Pick Up";
            AutoGenerateResi();       
            produk();
            isicombo();
            Services();
            callProduk();

            txTotal.Multiline = true;
            txTotal.Height = 50;
        }

        public void sendtodatagrid()
        {
            string noresi, kotatujuan, produk, IsiKiriman, TipeKiriman, BeratKiriman, VolumeKiriman, servis,
                namaPenerima, perusahaan1, alamatPenerima, kodeposPenerima, nohp1, email1,
                namapengirim, perusahaan2, alamatpengirim, kodepospengirim, nohp2, email2, total, infokiriman;
            try
            {
                noresi = TxNoresi.Text;
                kotatujuan = cmbkotatujuan.Text;
                produk = cmbproduk.Text;
                IsiKiriman = textBox1.Text;
                TipeKiriman = cmbTipeKiriman.Text;
                BeratKiriman = txBerat.Text;
                VolumeKiriman = TxVolResult.Text;
                servis = cmbservice.Text;
                namaPenerima = txNamaPenerima.Text;
                perusahaan1 = txPerusahaan1.Text;
                alamatPenerima = txAlamatPenerima.Text;
                kodeposPenerima = txKodeposPenerima.Text;
                nohp1 = txHPPenerima.Text;
                email1 = txEmailPenerima.Text + "@Gmail.com";
                namapengirim = txNamaPengirm.Text;
                perusahaan2 = txperusahaan2.Text;
                alamatpengirim = txalamatpengirm.Text;
                kodepospengirim = txkodepos2.Text;
                nohp2 = txnohp2.Text;
                email2 = emailpengirim.Text + "@Gmail.com";
                infokiriman = txInfoKirim.Text;
                total = txTotal.Text;
                dataGridView1.Rows.Add(noresi, kotatujuan, produk, servis, IsiKiriman, TipeKiriman, BeratKiriman, VolumeKiriman,
                    namaPenerima, perusahaan1, alamatPenerima, kodeposPenerima, email1, nohp1, namapengirim, perusahaan2, alamatpengirim, kodepospengirim, email2, nohp2, total, infokiriman);

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            //  TxNoresi.Text = AutoGenerateResi();
            VNN();
            TxNoresi.Refresh();
           
        }
        //============================================== no use

        private void cmbproduk_Click(object sender, EventArgs e)
        {
            callProduk();
        }

        private void TxP_TextChanged(object sender, EventArgs e)
        {




        }

        private void TxNoresi_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TxT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hitung();

                Total();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembukaan operator hanya dapat dilakukan 1x24 jam");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PenutupanOperator PenutupanCounter = new PenutupanOperator();
            PenutupanCounter.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CekResi CR = new CekResi();
            Hide();
            CR.ShowDialog();
        }


        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 LT = new Form3();
            Hide();
            LT.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Void vo = new Void();
            vo.ShowDialog();
        }


        private void button10_Click(object sender, EventArgs e)
        {
        }
        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbservice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cmbproduk_SelectedIndexChanged(object sender, EventArgs e)
        {
            callProduk();
            Total();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void TxVolResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void TxL_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxT_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void TxT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTransaksi();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void cmbkotatujuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txOngkir.Text = searchOngkir();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void txBerat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Total();
            }
        }
        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }


        private void button10_Click_1(object sender, EventArgs e)
        {

            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected)
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void TxBayar_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void TxBayar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int bayar, total, kembalian;
                bayar = Convert.ToInt32(this.TxBayar.Text);
                total = Convert.ToInt32(this.txTotal.Text);

                if (total > bayar)
                {
                    MessageBox.Show("Uang Anda Kurang!");
                    TxKembalian.Text = "0";
                    TxBayar.Text = "0";
                    TxBayar.Focus();
                    
                }
                else
                {
                    kembalian = bayar - total;
                    TxKembalian.Text = Convert.ToString(kembalian);
                }

            }
        }

        private void TxStatusBarang_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bersih();
            DataManifest dm = new DataManifest();
            Hide();
            dm.Show();
        }

        private void txOngkir_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxAsuransi_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbservice_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            TxService.Text = searchAsuransi();
            Total();
        }

        private void txKodeposPenerima_TextChanged(object sender, EventArgs e)
        {

        }

        private void txKodeposPenerima_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txHPPenerima_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txkodepos2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txnohp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MenuUser MU = new MenuUser();
            Hide();
            MU.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Hide();
            f2.ShowDialog();

        }

        private void TxHargaProduk_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            Hide();
            f5.ShowDialog();
        }

        private void txTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxProduk2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxNoresi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
