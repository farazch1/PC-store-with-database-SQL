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
    public partial class product_window : Form
    {
        public product_window()
        {
            InitializeComponent();
        }
        void showproductdata()
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
            command.CommandText = "select * from Product";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); da.Fill(dt);

            dataGridView1.DataSource = dt;
            textBox11.Text = "Retrieval Successful!"; conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Updating Record...";
            command.Connection = connection;
            command.CommandText = "update Product set Price='" + textBox9.Text + "' where ProductID='" + textBox8.Text + "'";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Updated...";
            connection.Close();
            showproductdata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dashboard dsh = new dashboard();
            dsh.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Product (ProductID, ProductName, Price, StockQuantity) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Inserted...";
            connection.Close();
            showproductdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showproductdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Deleting Record...";
            command.Connection = connection;
            command.CommandText = "delete from Product where ProductID='" + textBox10.Text + "'";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Deleted...";
            connection.Close();
            showproductdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox11.Text = "Updating Record...";
            command.Connection = connection;
            command.CommandText = "update Product set StockQuantity='" + textBox7.Text + "' where ProductID='" + textBox6.Text + "'";
            command.ExecuteNonQuery();
            textBox11.Text = "Record Updated...";
            connection.Close();
            showproductdata();
        }
    }
}
