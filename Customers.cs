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

namespace DB_Theory_Project__Game_Store_
{
    public partial class Customers : Form
    {
        void showcustomerdata()
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = pcstore; Integrated Security = True");
            var datasource = @"(local)\SQLEXPRESS";
            var database = "pcstore";
            var thisUsername = "faraz";
            var thisPassword = "1234";
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + "; Persist Security Info=True;User ID=" + thisUsername + ";Password=" + thisPassword;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            textBox11.Text = "Retrieving Records..."; command.Connection = conn;
            command.CommandText = "select * from Customer";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); da.Fill(dt);

            dataGridView1.DataSource = dt;
            textBox11.Text = "Retrieval Successful!"; conn.Close();
        }
        public Customers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customer (CustomerID, FirstName, LastName, Email, Phone, Address, City, State, ZipCode) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Inserted...";
            connection.Close();
            showcustomerdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                showcustomerdata();   
            }
            catch (Exception ex)
            {
                textBox11.Text = "Error, " + ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Deleting Record...";
            command.Connection = connection;
            command.CommandText = "delete from Customer where CustomerID='" + textBox10.Text + "'";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Deleted...";
            connection.Close();
            showcustomerdata();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashboard dsb = new dashboard();
            dsb.Show();
            this.Close();

        }
    }
}
