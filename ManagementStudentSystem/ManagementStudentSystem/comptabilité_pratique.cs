using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementStudentSystem
{
    public partial class comptabilité_pratique : Form
    {
        public comptabilité_pratique()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            comptabilité_pratique3mois b3 = new comptabilité_pratique3mois();
            b3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            comptabilité_pratique6mois b = new comptabilité_pratique6mois();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            comptabilité_pratique9mois b = new comptabilité_pratique9mois();
            b.Show();
        }
    }
}
