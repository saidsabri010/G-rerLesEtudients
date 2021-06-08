using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace ManagementStudentSystem
{
    public partial class Bureatique : Form
    {
        public Bureatique()
        {
            InitializeComponent();
            this.Size = new Size(3000, 2500);
        }


        SqlConnection con =
        new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bureatique3Mois;Integrated Security=True;Pooling=False");


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || comboBox3.Text == "" || textBox10.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Veuillez ajouter toutes les informations");
            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select CIN from Bureatique where CIN= @CIN", con);
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
                    SqlCommand cmde = new SqlCommand("INSERT INTO Bureatique VALUES (@CIN,@Prénom,@Nom,@Date_De_Naissance,@Tél,@Adresse,@date_de_linscription,@Durée_De_Formation,@Groupe,@Niveau_Scolaire)", con);
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
                SqlCommand cmd = new SqlCommand("select CIN from Bureatique where CIN= @CIN", con);
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
                    SqlCommand cmde = new SqlCommand("UPDATE Bureatique SET CIN=@CIN,Prénom=@Prénom,Nom=@Nom,Date_De_Naissance=@Date_De_Naissance,Tél=@Tél,Adresse=@Adresse,date_de_linscription=@date_de_linscription,Durée_De_Formation=@Durée_De_Formation,Groupe=@Groupe,Niveau_Scolaire=@Niveau_Scolaire WHERE CIN=@CIN", con);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bureatique", con);
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
            SqlCommand cmd = new SqlCommand("select CIN from Bureatique where CIN= @CIN", con);
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

                    SqlCommand cmde = new SqlCommand("DELETE Bureatique WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox4.Text);
                    cmde.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("La suppression a réussi");

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            button10.Visible = false;

            button11.Visible = false;
            button12.Visible = false;
            label15.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            Print.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBox6.Visible = false;
            txtNom.Visible = false;
            txtFraisDinscreption.Visible = false;
            comboBox10.Visible = false;
            txtGroupe.Visible = false;
            button13.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            //button14.Visible = false;
            button15.Visible = false;
            button17.Visible = false;
            button16.Visible = true;
            txtResult.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            txtPrenom.Visible = false;
            txtGenerate.Visible = false;
            txtFraisDeScolarité.Visible = false;
            txtModeDePaiement.Visible = false;
            txtLeMoisPayés.Visible = false;
            label38.Visible = false;
            button14.Visible = false;

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
            SqlCommand cmd = new SqlCommand("select CIN from Bureatique where CIN= @CIN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CIN", textBox9.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Désolé, ce CIN n'existe pas");
                con.Close();
            }
            else
            {
                SqlCommand cmde = new SqlCommand("SELECT * FROM Bureatique WHERE CIN=@CIN", con);
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
            int indexRow = e.RowIndex;
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
                //dateTimePicker1.Text = row.Cells[4].Value.ToString();
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
                    SqlCommand cmde = new SqlCommand("SELECT * FROM Bureatique WHERE Durée_De_Formation=@Durée_De_Formation", con);
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
                    SqlCommand cmdee = new SqlCommand("SELECT * FROM Bureatique WHERE Groupe=@Groupe", con);
                    cmdee.Parameters.AddWithValue("@Groupe", comboBox5.Text);
                    SqlDataAdapter daee = new SqlDataAdapter(cmdee);
                    DataTable dtee = new DataTable();
                    daee.Fill(dtee);
                    dataGridView1.DataSource = dtee;
                    dataGridView1.Columns[0].Visible = false;
                    con.Close();
                }
                if ((comboBox4.Text != "" && comboBox5.Text != ""))
                {
                    string a = comboBox4.SelectedItem.ToString();
                    string b = comboBox5.SelectedItem.ToString();
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Bureatique WHERE Groupe=@Groupe and Durée_De_Formation=@Durée_De_Formation", con);
                        cmd.Parameters.AddWithValue("@Groupe", b);
                        cmd.Parameters.AddWithValue("@Durée_De_Formation", a);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
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

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            Button.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            txtFraisDeScolarité.Visible = false;
            txtModeDePaiement.Visible = false;
            button10.Visible = true;
            button11.Visible = false;
            button14.Visible = true;
            button12.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            textBox6.Visible = true;
            button13.Visible = true;
            comboBox6.Visible = true;
            comboBox7.Visible = true;
            //button14.Visible = true;
            button15.Visible = true;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            Button.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button16.Visible = true;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            //button14.Visible = false;
            button15.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBox6.Visible = false;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Payment_Bureatique ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Payment_Bureatique(CIN,Prénom,Nom,Durée_De_Formation) SELECT CIN,Prénom,Nom,Durée_De_Formation FROM Bureatique WHERE NOT EXISTS (SELECT CIN,Prénom,Nom,Durée_De_Formation FROM Payment_Bureatique) ", con);
            //SqlCommand cmd1 = new SqlCommand("delete from Payment_Bureatique", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            con.Close();

            {
                textBox6.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
            }
        }



        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "" || comboBox7.Text == "")
            {
                MessageBox.Show("Veuillez ajouter toutes les informations");
            }
            else
            {
                if (comboBox6.SelectedItem.ToString() == "Month 1")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month1=@Month1 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month1", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 2")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month2=@Month2 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month2", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 3")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month3=@Month3 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month3", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 4")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month4=@Month4 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month4", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 5")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month5=@Month5 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month5", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 6")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month6=@Month6 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month6", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 7")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month7=@Month7 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month7", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 8")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month8=@Month8 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month8", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }
                if (comboBox6.SelectedItem.ToString() == "Month 9")
                {
                    con.Open();
                    SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Month9=@Month9 WHERE CIN=@CIN", con);
                    cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                    cmde.Parameters.AddWithValue("@Month9", comboBox7.SelectedItem.ToString());
                    cmde.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Refresh();

                    MessageBox.Show("l'enregistrement a réussi");
                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //SqlCommand cmde = new SqlCommand("UPDATE Payment_Bureatique SET Months=@Months,Payment=@Payment WHERE CIN=@CIN", con);

            //cmde.Parameters.AddWithValue("@Months", comboBox6.Text);
            //cmde.Parameters.AddWithValue("@Payment", comboBox7.Text);

            //cmde.ExecuteNonQuery();
            //con.Close();

            //MessageBox.Show("Mise à jour réussie");
        }

        private void button15_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select CIN from Payment_Bureatique where CIN= @CIN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CIN", textBox6.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Désolé, ce CIN n'existe pas");
                con.Close();
            }
            else
            {
                SqlCommand cmde = new SqlCommand("SELECT * FROM Payment_Bureatique WHERE CIN=@CIN", con);
                cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                SqlDataAdapter dae = new SqlDataAdapter(cmde);
                DataTable dte = new DataTable();
                dae.Fill(dte);
                dataGridView1.DataSource = dte;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            Button.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBox6.Visible = false;
            button13.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            //button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            dataGridView1.Visible = false;
            button17.Visible = true;
            txtResult.Visible = true;
            panel1.Visible = true;
            panel2.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            txtPrenom.Visible = true;
            txtGenerate.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            label30.Visible = true;
            label31.Visible = true;
            label32.Visible = true;
            label33.Visible = true;
            label34.Visible = true;
            label35.Visible = true;
            label36.Visible = true;
            label37.Visible = true;
            txtNom.Visible = true;
            txtFraisDinscreption.Visible = true;
            comboBox10.Visible = true;
            txtGroupe.Visible = true;
            txtFraisDeScolarité.Visible = true;
            txtModeDePaiement.Visible = true;
            Print.Visible = true;
            txtLeMoisPayés.Visible = true;
            label38.Visible = true;


        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            Button.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button14.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button16.Visible = true;
            dataGridView1.Visible = true;
            label22.Visible = false;
            txtPrenom.Visible = false;
            txtResult.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            button17.Visible = false;
            txtGenerate.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            txtNom.Visible = false;
            txtFraisDinscreption.Visible = false;
            txtGroupe.Visible = false;
            comboBox10.Visible = false;
            txtFraisDeScolarité.Visible = false;
            txtModeDePaiement.Visible = false;
            Print.Visible = false;
            txtLeMoisPayés.Visible = false;
            label38.Visible = false;

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + " Prénom  : " + "     " + txtPrenom.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + " Nom  : " + "     " + txtNom.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + " Nom De Formation  : " + "     " + comboBox10.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + " Groupe  : " + "     " + txtGroupe.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + "Frais D'inscreption  : " + "     " + txtFraisDinscreption.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + "Frais De Scolarité  : " + "     " + txtFraisDeScolarité.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + "Mode De Paiement  : " + "     " + txtModeDePaiement.Text + "\n\n";
            txtResult.Text += "                              \n";
            txtResult.Text += "                  " + "Le Mois Payés  : " + "     " + txtLeMoisPayés.Text + "\n\n";
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            
            Size s = this.Size;
            bmp = new Bitmap(s.Width, s.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            printPreviewDialog1.ShowDialog();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CIN from Payment_Bureatique where CIN= @CIN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CIN", textBox6.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Désolé, ce CIN n'existe pas");
                con.Close();
            }
            else
            {
                SqlCommand cmde = new SqlCommand("SELECT * FROM Payment_Bureatique WHERE CIN=@CIN", con);
                cmde.Parameters.AddWithValue("@CIN", textBox6.Text);
                SqlDataAdapter dae = new SqlDataAdapter(cmde);
                DataTable dte = new DataTable();
                dae.Fill(dte);
                dataGridView1.DataSource = dte;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }



}





