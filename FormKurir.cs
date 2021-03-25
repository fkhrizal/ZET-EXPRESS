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
    public partial class FormKurir : Form
    {
        public static string getnotif, getresi;
        static FileStream F, F1;
        StreamWriter W, W1;
        string ValueUser;
        StreamReader R, R1;
        private bool find;
        public static string getInfoBarang;
        string ValueKurir, str, userdir;
        public FormKurir()
        {
            InitializeComponent();
        }
        public void UPDATE_RESI()
        {
            //try
            //{
            //    string data;
            //    bool find = false;
            //    string[] dataarr;

            //    F = new FileStream("DataTransaksi.txt", FileMode.Open, FileAccess.Read);
            //    R = new StreamReader("DataTransaksi.txt");

            //    while ((data = R.ReadLine()) != null)
            //    {
            //        dataarr = data.Split('#');
            //        if (CekResi.getCekResi == dataarr[19])
            //        {
            //            find = true;

            //            F = new FileStream("DataTransaksi.txt", FileMode.Append, FileAccess.Write);
            //            W = new StreamWriter(F);
            //            getInfoBarang = TxInfoBrg.Text;
            //            CekResi.getCekResi = getInfoBarang;
            //            ValueKurir = getInfoBarang + "#";
            //            MessageBox.Show("TerimaKasih Atas Kerja Kerasnya");
            //            W.WriteLine(ValueKurir);
            //            W.Close();
            //            F.Close();
            //        }

            //    }
            //    if (!find)
            //    {

            //    }

            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
        }
        public void PickUp()
        {

            TxInfoBrg.Text = "Barang Anda Sudah di Pick Up";

            {
                string StatusBarang;
                try
                {
                    F = new FileStream("InfoBarang.txt", FileMode.Append, FileAccess.Write);
                    W = new StreamWriter(F);
                    StatusBarang = TxInfoBrg.Text;
                    if (TxInfoBrg.Text != null)
                    {
                        ValueKurir = StatusBarang + '#';
                        W.WriteLine(ValueKurir);
                        W.Close();
                        F.Close();
                    }


                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }

        }

        public void otw()
        {

            TxInfoBrg.Text = "Barang Anda Sedang di Perjalanan";


            string StatusBarang;
            try
            {
                F = new FileStream("InfoBarang.txt", FileMode.Append, FileAccess.Write);
                W = new StreamWriter(F);
                StatusBarang = TxInfoBrg.Text;
                if (TxInfoBrg.Text != null)
                {
                    ValueKurir = StatusBarang + '#';
                    W.WriteLine(ValueKurir);
                    W.Close();
                    F.Close();
                }


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public void BarangSampai()
        {
            TxInfoBrg.Text = "Barang Sudah Sampai";

            string StatusBarang;
            try
            {
                F = new FileStream("InfoBarang.txt", FileMode.Append, FileAccess.Write);
                W = new StreamWriter(F);
                StatusBarang = TxInfoBrg.Text;
                if (TxInfoBrg.Text != null)
                {
                    ValueKurir = StatusBarang + '#';
                    W.WriteLine(ValueKurir);
                    W.Close();
                    F.Close();
                }


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            label7.Text = TxInfoBrg.Text;
            label8.Text = TxCariResi.Text;
            getresi = label8.Text;
            getnotif = label7.Text;
            MessageBox.Show("Barang Sudah Di Pick Up");
            TxInfoBrg.Text = "Barang Di Pick UP";
            apdet();
        }



        private void otwbtn_Click(object sender, EventArgs e)

        {
            label7.Text = TxInfoBrg.Text;
            label8.Text = TxCariResi.Text;
            getresi = label8.Text;
            getnotif = label7.Text;
            MessageBox.Show("Barang Sedang di Perjalanan");
            TxInfoBrg.Text = "Dalam Perjalanan";
            apdet();
            // update();
        }

        private void arrivedbtn_Click(object sender, EventArgs e)
        {
            label7.Text = TxInfoBrg.Text;
            label8.Text = TxCariResi.Text;
            getresi = label8.Text;
            getnotif = label7.Text;
            MessageBox.Show("Barang Sudah Sampai");
            TxInfoBrg.Text = "Barang Telah Sampai";
            apdet();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void status()
        {
            if (TxInfoBrg.Text == "Belum Di Pick Up")
            {
                PickUpbtn.Enabled = true;
                arrivedbtn.Enabled = false;
                otwbtn.Enabled = false;
            }
            else if (TxInfoBrg.Text == "Barang Di Pick UP")
            {
                otwbtn.Enabled = true;
                arrivedbtn.Enabled = false;
                PickUpbtn.Enabled = false;
            }
            else if (TxInfoBrg.Text == "Dalam Perjalanan")
            {
                arrivedbtn.Enabled = true;
                PickUpbtn.Enabled = false;
                otwbtn.Enabled = false;
            }

        }

        public void notif()
        {
            label7.Text = getnotif;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUser mu = new MenuUser();
            Hide();
            mu.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cari_resi();
            status();
            label7.Text = TxInfoBrg.Text;
        }

        private void TxInfoBrg_TextChanged(object sender, EventArgs e)
        {


        }

        //public void update()
        //{
        //    try
        //    {
        //        string find;
        //        string[] strArray = new string[1];
        //        Boolean finds = false;
        //        String alltext = "";
        //        String SaveTxt = "";
        //        string total;

        //        string BalancePath = Path.Combine(Userdir, @"DataTransaksi.txt");
        //        F = new FileStream(BalancePath, FileMode.Open, FileAccess.Read);
        //        R = new StreamReader(F);
        //        find = BalancePath;
        //        while ((str = r1.ReadLine()) != null)
        //        {
        //            String Chkstr = BalancePath;
        //            if ((find.CompareTo(Chkstr) == 0))
        //            {
        //                String[] element = str.Split('#');
        //                finds = true;
        //                total = Convert.ToString(results);
        //                element[1] = total;
        //                SaveTxt = element[0] + "#" + element[1];
        //                alltext += SaveTxt;
        //            }
        //            else
        //            {
        //                alltext = alltext + str + "\n";
        //            }
        //        }
        //        if (!finds)
        //        {
        //            Console.Beep();
        //            Console.Beep();
        //            MessageBox.Show("Sorry... Data not Found");
        //        }
        //        r1.Close();
        //        File.WriteAllText(BalancePath, alltext);
        //    }
        //    catch
        //    {
        //        Console.Beep();
        //        Console.Beep();
        //        MessageBox.Show("The Data You Input is Incorrect");
        //        //    refreshControl();
        //    }
        //}
        public void apdet()
        {
            try
            {
                string search, Str;
                string[] strArray = new string[3];
                Boolean find = false;
                int Pos;
                String alltext = "";
                String txtsave = "";

                F = new FileStream("DataTransaksi.txt", FileMode.Open, FileAccess.Read);
                R = new StreamReader(F);

                search = TxCariResi.Text;

                while ((Str = R.ReadLine()) != null)
                {
                    Pos = Str.IndexOf("#");
                    String Chkstr2 = Str.Substring(0, Pos);
                    if ((search.CompareTo(Chkstr2) == 0))
                    {
                        String[] elemen = Str.Split('#');
                        find = true;
                        elemen[21] = TxInfoBrg.Text;


                        txtsave = elemen[0] + "#" + elemen[1] + "#" + elemen[2] + "#" + elemen[3] + "#" + elemen[4] + "#" + elemen[5] + "#" + elemen[6] + "#" + elemen[7] + "#" + elemen[8] + "#" + elemen[9] + "#" + elemen[10] + "#" + elemen[11] + "#" + elemen[12] + "#" + elemen[13] + "#" + elemen[14] + "#" + elemen[15] + "#" + elemen[16] + "#" + elemen[17] + "#" + elemen[18] + "#" + elemen[19] + "#" + elemen[20] + "#" + elemen[21] + "\n";
                        alltext += txtsave;
                    }
                    else
                    {
                        alltext = alltext + Str + "\n";
                    }
                }
                if (!find)
                {
                    MessageBox.Show("Sorry Data Not Found");
                }
                R.Close();
                File.WriteAllText("DataTransaksi.txt", alltext);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No One Registered Yet");
            }

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
                    TxInfoBrg.Text = dataarr[21];
                    TxPenerima.Text = dataarr[8];
                    richTextBox1.Text = dataarr[10];
                    MessageBox.Show("Resi Ditemukan!");

                    break;

                }

            }
            if (!find)
            {
                MessageBox.Show("Resi tidak ada!");
            }
            F.Close();
            R.Close();
        }
        private void FormKurir_Load(object sender, EventArgs e)
        {
            label7.Text = TxInfoBrg.Text;
        }
    }
}
