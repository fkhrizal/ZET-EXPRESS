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
    public partial class Formkurir1 : Form
    {
        static FileStream F;
        StreamWriter W, W1;
        string ValueUser;
        StreamReader R;
        private bool find;
        int kode;
        string Str, kodebaru;
        string[] isi;
        public static string getResi;
        public Formkurir1()
        {
            InitializeComponent();
        }

            public string Label2
        {
            get { return this.label2.Text; }
            set { this.label2.Text = value; }
        }

        public void cari_resi()
        {
            string data;
            bool find = false;
            string[] dataarr;

            F = new FileStream("DataTransaksi.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader("DataTransaksi.txt");

            while ((data = R.ReadLine()) != null)
            {
                dataarr = data.Split('#');
                if (TxCariResi.Text == dataarr[0])
                {
                    find = true;
                    label2.Text = dataarr[0];
                    getResi = TxCariResi.Text;
                    MessageBox.Show("Resi Ditemukan!");
                    FormKurir fk = new FormKurir();
                    fk.ShowDialog();
                    break;

                }

            }
            if (!find)
            {
                MessageBox.Show("Resi tidak ada!");
            }
        }

            

        private void TxCariResi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari_resi();
        }
        private void Formkurir1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
