using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ManagementStudentSystem
{
    public partial class Systeme_Qualite : Form
    {
        public Systeme_Qualite()
        {
            InitializeComponent();
            this.Size = new Size(3000, 2500);
        }

        SqlConnection con =
        new SqlConnection(@"Data Source=DESKTOP-L01N2NA;Initial Catalog=WS;Integrated Security=True;Pooling=False");




        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || comboBox3.Text == "" || textBox10.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Veuillez ajouter toutes les informations");
            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select CIN from Systeme_Qualite where CIN= @CIN", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CIN", textBox10.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Ce CIN existe déjà");
                    con.Close();
                }
                else
                {

                    SqlCommand cmde = new SqlCommand("INSERT INTO Systeme_Qualite VALUES (@CIN,@Prénom,@Nom,@Date_De_Naissance,@Tél,@Adresse,@date_de_linscription,@Durée_De_Formation,@Groupe,@Niveau_Scolaire)", con);
                    cmde.Parameters.AddWithValue("@Prénom", textBox1.Text);
                    cmde.Parameters.AddWithValue("@Nom", textBox2.Text);
                    cmde.Parameters.AddWithValue("@Date_De_Naissance", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmde.Parameters.AddWithValue("@date_de_linscription", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                    cmde.Parameters.AddWithValue("@Durée_De_Formation", comboBox3.Text);
                    cmde.Parameters.AddWithValue("@Groupe", comboBox1.Text);
                    cmde.Parameters.AddWithValue("@Niveau_Scolaire", comboBox2.Text);
                    cmde.Parameters.AddWithValue("@Tél", textBox3.Text);
                    cmde.Parameters.AddWithValue("@CIN", textBox10.Text);
                    cmde.Parameters.AddWithValue("@Adresse", textBox5.Text);
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }

            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || comboBox3.Text == "" || textBox10.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Veuillez ajouter toutes les informations");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select CIN from Systeme_Qualite where CIN= @CIN", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@CIN", textBox10.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Désolé, ce CIN n'existe pas");
                    con.Close();
                }
                else
                {
                    SqlCommand cmde = new SqlCommand("UPDATE Systeme_Qualite SET CIN=@CIN,Prénom=@Prénom,Nom=@Nom,Date_De_Naissance=@Date_De_Naissance,Tél=@Tél,Adresse=@Adresse,date_de_linscription=@date_de_linscription,Durée_De_Formation=@Durée_De_Formation,Groupe=@Groupe,Niveau_Scolaire=@Niveau_Scolaire WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@Prénom", textBox1.Text);
                    cmde.Parameters.AddWithValue("@Nom", textBox2.Text);
                    cmde.Parameters.AddWithValue("@Date_De_Naissance", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    cmde.Parameters.AddWithValue("@date_de_linscription", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                    cmde.Parameters.AddWithValue("@Durée_De_Formation", comboBox3.Text);
                    cmde.Parameters.AddWithValue("@Groupe", comboBox1.Text);
                    cmde.Parameters.AddWithValue("@Niveau_Scolaire", comboBox2.Text);
                    cmde.Parameters.AddWithValue("@Tél", textBox3.Text);
                    cmde.Parameters.AddWithValue("@CIN", textBox10.Text);
                    cmde.Parameters.AddWithValue("@Adresse", textBox5.Text);
                    cmde.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Mise à jour réussie");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Systeme_Qualite", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {



            con.Open();
            SqlCommand cmd = new SqlCommand("select CIN from Systeme_Qualite where CIN= @CIN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CIN", textBox4.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Désolé, ce CIN n'existe pas");
                con.Close();
            }
            else
            {
                var result = MessageBox.Show("Voulez-vous vraiment supprimer cette personne ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    SqlCommand cmde = new SqlCommand("DELETE Systeme_Qualite WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox4.Text);
                    cmde.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("La suppression a réussi");

                }
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous vraiment Exit ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                this.Close();

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home b = new Home();
            b.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CIN from Systeme_Qualite where CIN= @CIN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CIN", textBox9.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("CIN Not exist");
                con.Close();
            }
            else
            {
                SqlCommand cmde = new SqlCommand("SELECT * FROM Systeme_Qualite WHERE CIN=@CIN", con);
                cmde.Parameters.AddWithValue("@CIN", textBox9.Text);
                SqlDataAdapter dae = new SqlDataAdapter(cmde);
                DataTable dte = new DataTable();
                dae.Fill(dte);
                dataGridView1.DataSource = dte;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }

        private void Bureatique_9Moi_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex; // get the selected Row Index
            if (indexRow > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox10.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[9].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
                comboBox3.Text = row.Cells[8].Value.ToString();
                comboBox2.Text = row.Cells[10].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
                dateTimePicker2.Text = row.Cells[7].Value.ToString();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "" && comboBox5.Text == "")
            {
                MessageBox.Show("Veuillez ajouter au moins une informations");
            }
            else
            {

                if (comboBox5.Text == "")
                {
                    SqlCommand cmde = new SqlCommand("SELECT * FROM Systeme_Qualite WHERE Durée_De_Formation=@Durée_De_Formation", con);
                    cmde.Parameters.AddWithValue("@Durée_De_Formation", comboBox4.Text);
                    SqlDataAdapter dae = new SqlDataAdapter(cmde);
                    DataTable dte = new DataTable();
                    dae.Fill(dte);
                    dataGridView1.DataSource = dte;
                    dataGridView1.Columns[0].Visible = false;
                    con.Close();

                }
                if (comboBox4.Text == "")
                {
                    SqlCommand cmde = new SqlCommand("SELECT * FROM Systeme_Qualite WHERE Groupe=@Groupe", con);
                    cmde.Parameters.AddWithValue("@Groupe", comboBox5.Text);
                    SqlDataAdapter dae = new SqlDataAdapter(cmde);
                    DataTable dte = new DataTable();
                    dae.Fill(dte);
                    dataGridView1.DataSource = dte;
                    dataGridView1.Columns[0].Visible = false;
                    con.Close();
                }
                if ((comboBox4.Text != "" && comboBox5.Text != ""))
                {
                    string a = comboBox4.SelectedItem.ToString();
                    string b = comboBox5.SelectedItem.ToString();
                    {
                        SqlCommand cmde = new SqlCommand("SELECT * FROM Systeme_Qualite WHERE Groupe=@Groupe and Durée_De_Formation=@Durée_De_Formation", con);
                        cmde.Parameters.AddWithValue("@Groupe", b);
                        cmde.Parameters.AddWithValue("@Durée_De_Formation", a);
                        SqlDataAdapter dae = new SqlDataAdapter(cmde);
                        DataTable dte = new DataTable();
                        dae.Fill(dte);
                        dataGridView1.DataSource = dte;
                        dataGridView1.Columns[0].Visible = false;
                        con.Close();
                    }
                }
            }
            /*if (comboBox4.SelectedIndex==-1 && comboBox5.SelectedIndex==-1)
          {
               MessageBox.Show("field can't be empty !");
          }

          else if (comboBox5.SelectedIndex>-1 && comboBox4.SelectedIndex == -1)
          {
               con.Open();
               SqlCommand cmde = new SqlCommand("SELECT * FROM Bureatique WHERE Groupe=@Groupe", con);
               cmde.Parameters.AddWithValue("@Groupe", comboBox5.SelectedItem.ToString());
               SqlDataAdapter dae = new SqlDataAdapter(cmde);
               DataTable dte = new DataTable();
               dae.Fill(dte);
               dataGridView1.DataSource = dte;
               con.Close();
          }
          else if(comboBox5.SelectedIndex == -1 && comboBox4.SelectedIndex > -1)
          {
               con.Open();
               SqlCommand cmde = new SqlCommand("SELECT * FROM Bureatique WHERE Durée_De_Formation=@Durée_De_Formation ", con);
               cmde.Parameters.AddWithValue("@Durée_De_Formation", comboBox4.SelectedItem.ToString());

               SqlDataAdapter dae = new SqlDataAdapter(cmde);
               DataTable dte = new DataTable();
               dae.Fill(dte);
               dataGridView1.DataSource = dte;
               con.Close();
          }
          else if (comboBox5.SelectedIndex > -1 && comboBox4.SelectedIndex > -1)
          {
               con.Open();
               SqlCommand cmde = new SqlCommand("SELECT * FROM Bureatique WHERE Groupe=@Groupe and Durée_De_Formation=@Durée_De_Formation", con);
               cmde.Parameters.AddWithValue("@Groupe", comboBox5.SelectedItem.ToString());
               cmde.Parameters.AddWithValue("@Durée_De_Formation", comboBox4.SelectedItem.ToString());
               SqlDataAdapter dae = new SqlDataAdapter(cmde);
               DataTable dte = new DataTable();
               dae.Fill(dte);
               dataGridView1.DataSource = dte;
               con.Close();
          } */
        }
    }
}
