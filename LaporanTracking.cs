using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class LaporanTracking : Form
    {
        public LaporanTracking()
        {
            InitializeComponent();
        }

        private void LaporanTracking_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembukaan operator hanya dapat dilakukan 1x24 jam");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataManifest F4 = new DataManifest();
            Hide();
            F4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PenutupanOperator PO = new PenutupanOperator();
            PO.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CekResi CR = new CekResi();
            Hide();
            CR.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Hide();
            f2.ShowDialog();
        }
    }
}
