using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementStudentSystem
{
    public partial class Bureatique_3MoisCopy : Form
    {
        public Bureatique_3MoisCopy()
        {
            InitializeComponent();
        }
      
        SqlConnection con =
new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bureatique3Mois;Integrated Security=True;Pooling=False");

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bureatique_6Mois", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE Bureatique_6Mois WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bureatique_6Mois WHERE Nom=@Nom", con);
            cmd.Parameters.AddWithValue("@Nom", textBox5.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Bureatique_6Mois VALUES (@Prénom,@Nom,@Date_De_Naissance,@date_de_linscription,@Telephone,@Le_Group,@Niveau_Scolaire)", con);
            cmd.Parameters.AddWithValue("@Prénom", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nom", textBox2.Text);
            cmd.Parameters.AddWithValue("@Date_De_Naissance",SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            cmd.Parameters.AddWithValue("@date_de_linscription", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
            cmd.Parameters.AddWithValue("@Telephone", textBox8.Text);
            cmd.Parameters.AddWithValue("@Le_Group", textBox3.Text);
            cmd.Parameters.AddWithValue("@Niveau_Scolaire", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.Refresh();

            MessageBox.Show("Successfully Inserted!!");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Bureatique_6Mois SET Prénom=@Prénom,Nom=@Nom,Date_De_Naissance=@Date_De_Naissance,date_de_linscription=@date_de_linscription,Telephone=@Telephone,Le_Group=@Le_Group,Niveau_Scolaire=@Niveau_Scolaire WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Prénom", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nom", textBox2.Text);
            cmd.Parameters.AddWithValue("@Date_De_Naissance", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            cmd.Parameters.AddWithValue("@date_de_linscription", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
            cmd.Parameters.AddWithValue("@Telephone", textBox8.Text);
            cmd.Parameters.AddWithValue("@Le_Group", textBox3.Text);
            cmd.Parameters.AddWithValue("@Niveau_Scolaire", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Updated!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";


        }
     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bureatique b = new Bureatique();
            b.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
         
        }

        private void Bureatique_3Moi_Load(object sender, EventArgs e)
        {

        }
    }
}
