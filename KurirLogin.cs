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

    public partial class KurirLogin : Form
    {
        static FileStream F, F1;
        StreamReader R;
        StreamWriter W, W1;
        string ValueUserDaftar, ValueUserLogin;
        private bool Find;

        public static string getUsername, getPass;
        public KurirLogin()
        {
            InitializeComponent();
        }
        public void Login2()
        {
            string data;
            bool find = false;
            string[] dataarr;

            F = new FileStream("Kurir.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader("Kurir.txt");

            while ((data = R.ReadLine()) != null)
            {
                dataarr = data.Split('#');
                if (TxUsername.Text == dataarr[4] && TxPassword.Text == dataarr[5])
                {
                    find = true;


                    MessageBox.Show("Selamat Datang");
                    FormKurir FK = new FormKurir();
                    Hide();
                    FK.ShowDialog();
                    break;

                }

            }
            if (!find)
            {
                MessageBox.Show("Password Kamu Salah");
            }
        }

    

        private void TxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getPass = TxPassword.Text;
                getUsername = TxUsername.Text;
                Login2();


            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            MenuUser MU = new MenuUser();
            Hide();
            MU.ShowDialog();
        }

        private void KurirLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
