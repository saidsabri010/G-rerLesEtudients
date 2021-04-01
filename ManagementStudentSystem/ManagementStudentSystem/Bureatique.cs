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
    public partial class Bureatique : Form
    {
        public Bureatique()
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
            Bureatique_3Moi b3 = new Bureatique_3Moi();
            b3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bureatique_3MoisCopy b = new Bureatique_3MoisCopy();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bureatique_39Mois b = new Bureatique_39Mois();
            b.Show();
        }
    }
}
