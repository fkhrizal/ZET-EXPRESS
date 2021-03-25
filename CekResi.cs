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
    public partial class CekResi : Form
    {
        static FileStream F;
        StreamWriter W, W1;
        string ValueUser;
        StreamReader R;
        private bool find;
        int kode;
        string Str, kodebaru;
        string[] isi;
        public static string getCekResi;

        public CekResi()
        {
            InitializeComponent();
        }

        //public void showbaloon()
        //{
           
        //    NotifyIcon notifyIcon = new NotifyIcon();
        //    notifyIcon.Visible = true; 
        //    if (title != null)
        //    {
        //        notifyIcon.BalloonTipTitle = title;
               
        //    }
        //    if (body != null)
        //    {
        //        notifyIcon.BalloonTipText = body;
        //    }
        //    notifyIcon.ShowBalloonTip(3000);
        //}
        public void SearchData()
        {
            string data;
            bool find = false;
            string[] dataarr;

            F = new FileStream("DataTransaksi.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader("DataTransaksi.txt");

            while ((data = R.ReadLine()) != null)
            {
                dataarr = data.Split('#');
                if (TxCekResi.Text == dataarr[0])
                {
                    find = true;
                    
                    MessageBox.Show("Resi Ditemukan!");
                    TxStatusResi.Text = dataarr[21];
                    TxCekResi.Text = getCekResi;
                    break;

                }

            }
            if (!find)
            {
                MessageBox.Show("Resi tidak ada!");
                TxStatusResi.Text = "";
                TxCekResi.Text = "";
                TxStatusResi.Focus();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void TxCekResi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MenuUser MU = new MenuUser();
            Hide();
            MU.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembukaan operator hanya dapat dilakukan 1x24 jam");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataManifest F4 = new DataManifest();
            Hide();
            F4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Form3 LT = new Form3();
            Hide();
            LT.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Hide();
            f2.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          
        }
        public void showNotif()
        {
            if (label2.Text == "Barang Telah Sampai")
            {
                label3.Visible = true;
                MessageBox.Show(label4.Text + "SUDAH SAMPAI");
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void CekResi_Load(object sender, EventArgs e)
        {
            label2.Text = FormKurir.getnotif;
            label4.Text = FormKurir.getresi;
            showNotif();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            SearchData();

        }
    }
}
