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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-P30AQDG;Initial Catalog=amndb;Integrated Security=True;Encrypt=False";
           SqlConnection con = new SqlConnection(connString);
 
            con.Open();
            string Name = textBox1.Text;
            string message = textBox2.Text;
            string Query = "Insert into files (name, message) values('" + Name + "','" + message + "')";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data saved");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-P30AQDG;Initial Catalog=amndb;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string Query = "SELECT * From files";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    dataGridView1.Rows.Add(reader["id"], reader["name"], reader["message"]);
            //}



            //method1
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                string connString = "Data Source=DESKTOP-P30AQDG;Initial Catalog=amndb;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(connString);

                con.Open();
                string Id = textBox3.Text;
                string Name = textBox1.Text;
                string message = textBox2.Text;
                string Query = "UPDATE files SET name= '"+Name+"',message='"+ message+"' WHERE id ='"+Id+"'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Update");
                textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";



        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-P30AQDG;Initial Catalog=amndb;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(connString);

            con.Open();
            string Id = textBox3.Text;
            
            string Query = "SELECT * FROM files WHERE Id ='"+Id+"'";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text= reader["name"].ToString();
                textBox2.Text = reader["message"].ToString();

            }
            else
            {
                MessageBox.Show("No record found");
            }
            con.Close();
            MessageBox.Show("Data Fetch");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-P30AQDG;Initial Catalog=amndb;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(connString);

            //con.Open();
            //string Id = textBox3.Text;

            //string Query = "DELETE  FROM files WHERE Id = '"+Id+"'";
            //SqlCommand cmd = new SqlCommand(Query, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //MessageBox.Show("Data Deleted");
            //textBox3.Text = "";
            //textBox2.Text = "";
            //textBox1.Text =
            //
            try
            {
                con.Open();
                string Id = textBox3.Text;

                if (!string.IsNullOrEmpty(Id))
                {
                    string Query = "DELETE FROM files WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(Query, con);

                
                    cmd.Parameters.AddWithValue("@Id", Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Deleted");
                    }
                    else
                    {
                        MessageBox.Show("No record found with the given ID");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                textBox3.Text = "";
                textBox2.Text = "";
                textBox1.Text = "";
            }
        }

    }
    }

