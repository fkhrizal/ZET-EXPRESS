using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Form2 : Form
    {
        static FileStream F, F1;
        StreamReader R;
        StreamWriter W, W1;
        string ValueUserDaftar, ValueUserLogin;
        private bool Find;

        private void button2_Click(object sender, EventArgs e)
        {
            DataManifest DM = new DataManifest();
            Hide();
            DM.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }
        public void RefreshControl()
        {
            TxNama.Text = "";
            TxAlamat.Text = "";
            TxTelepon.Text = "";
            TxUserDaftar.Text = "";
            TxPasswordDaftar.Text = "";
        }
        public void daftar()
        {
            string Nama, tglLahir, Alamat, Telephone, Jabatan, DaftarUsername, DaftarPassword;
            try
            {
                F = new FileStream("Kurir.txt", FileMode.Append, FileAccess.Write);
                W = new StreamWriter(F);
                Nama = TxNama.Text;
                tglLahir = dtp1.Text;
                Alamat = TxAlamat.Text;
                Telephone = TxTelepon.Text;
                DaftarUsername = TxUserDaftar.Text;
                DaftarPassword = TxPasswordDaftar.Text;

                if (TxNama.Text == "")
                {

                    MessageBox.Show("DATA TIDAK BOLEH KOSONG!!");
                    TxNama.Focus();
                    W.Close();
                    F.Close();
                }
                else if (TxAlamat.Text == "")
                {

                    MessageBox.Show("DATA TIDAK BOLEH KOSONG!!");
                    TxAlamat.Focus();
                    W.Close();
                    F.Close();
                }
                else if (TxTelepon.Text == "")
                {

                    MessageBox.Show("DATA TIDAK BOLEH KOSONG!!");
                    TxTelepon.Focus();
                    W.Close();
                    F.Close();
                }
               
                else if (TxUserDaftar.Text == "")
                {

                    MessageBox.Show("DATA TIDAK BOLEH KOSONG!!");
                    TxUserDaftar.Focus();
                    W.Close();
                    F.Close();
                }

                else if (TxPasswordDaftar.Text == "")
                {

                    MessageBox.Show("DATA TIDAK BOLEH KOSONG!!");
                    TxPasswordDaftar.Focus();
                    W.Close();
                    F.Close();
                }

                else if (TxNama.Text != null && TxAlamat.Text != null && TxTelepon.Text != null && TxUserDaftar != null && TxPasswordDaftar != null)

                {
                    ValueUserDaftar = Nama + '#' + tglLahir + '#' + Alamat + '#' + Telephone + '#' + DaftarUsername + '#' + DaftarPassword;
                    


                    W.WriteLine(ValueUserDaftar);
                    
                    W.Close();
                    
                    MessageBox.Show("Pendaftaran Berhasil");
                    RefreshControl();
                }
                else
                {
                    MessageBox.Show("Data Tidak Tersimpan");
                }


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daftar();
        }
    }
}
