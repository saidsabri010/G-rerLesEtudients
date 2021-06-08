using ManagementStudentSystem;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Manage_Student_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(3000, 2500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            if (username == "aze" && password == "aze")
            {
                this.Hide();
                Home h = new Home();
                h.Show();
            }
            else
            {
                MessageBox.Show("error !");

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;

            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

            // The password character is an asterisk.
            txtpassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            txtpassword.MaxLength = 14;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
