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
    public partial class PenutupanOperator : Form
    {
        public PenutupanOperator()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataManifest dm = new DataManifest();
            dm.ShowDialog();
        }

        private void PenutupanOperator_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CekResi CR = new CekResi();
            CR.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pembukaan operator hanya dapat dilakukan 1x24 jam");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LaporanTracking LT = new LaporanTracking();
            LT.ShowDialog();
        }
    }
}
