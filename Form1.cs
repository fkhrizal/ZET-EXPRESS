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
    public partial class Form1 : Form
    {
        static FileStream F ;
        StreamWriter W, W1;
        string ValueUser;
        StreamReader R;
        private bool find;

        public static string getUsername, getPass;
        public Form1()
        {
            InitializeComponent();
        }
        internal pembukaan_Operator po = new pembukaan_Operator();
        public void RefreshControl()
        {
            TxUsername.Text = "";
            TxPassword.Text = "";
        }    

        public void DaftarKaryawanBaru()
        {
            Form3daftar daftar = new Form3daftar();
            Hide();
            daftar.ShowDialog();
            

        }
    
        public string Label2
        {
            get { return this.label2.Text; }
            set { this.label2.Text = value; }
        }
        public void Login()
        {
            string data;
            bool find = false;
            string[] dataarr;

            F = new FileStream("Login.txt", FileMode.Open, FileAccess.Read);
            R = new StreamReader("Login.txt");

            while((data=R.ReadLine()) !=null)
            {
                dataarr = data.Split('#');
                if(TxUsername.Text == dataarr[0] && TxPassword.Text == dataarr[1] )
                {
                    find = true;

                    label2.Text = dataarr[0];
                   
                    MessageBox.Show("Selamat Datang"); 
                    pembukaan_Operator po = new pembukaan_Operator();
                    Hide();
                    po.ShowDialog();
                    break;
                    
                }
                
            }
            if (!find)
            {
                MessageBox.Show("Password Kamu Salah");
            } 
        }

        private void TxPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getPass = TxPassword.Text;
                getUsername = TxUsername.Text;
                
                Login();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DaftarKaryawanBaru();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuUser MU = new MenuUser();
            Hide();
            MU.ShowDialog();
        }

      

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            Login();
            this.Close();
            
        }


        //================================================== no use
        private void TxPassword_TextChanged(object sender, EventArgs e)
        {
            
            //        Login();
        }

        private void TxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                TxUsername.Focus();

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TxPassword_TextChanged_1(object sender, EventArgs e)
        {

        }

        

        private void TxPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
