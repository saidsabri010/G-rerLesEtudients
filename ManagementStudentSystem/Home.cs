using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManagementStudentSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.Hide();
            this.Size = new Size(3000, 2500);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bureatique b = new Bureatique();
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comptabilite_pratique b = new Comptabilite_pratique();
            b.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Gestion_comercial b = new Gestion_comercial();
            b.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Programmation b = new Programmation();
            b.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Design_graphique b = new Design_graphique();
            b.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Informatique b = new Informatique();
            b.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Systeme_Qualite b = new Systeme_Qualite();
            b.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Agronomie b = new Agronomie();
            b.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Soutien_Universitaire b = new Soutien_Universitaire();
            b.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            langues_et_Communication b = new langues_et_Communication();
            b.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Science_de_Education b = new Science_de_Education();
            b.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
