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

namespace DB_Theory_Project__Game_Store_
{
    public partial class orderdetail : Form
    {
        void prods()
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
            command.Connection = conn;
            command.CommandText = "select * from Product";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); 
            da.Fill(dt);

            dataGridView2.DataSource = dt;
            conn.Close();
        }
        void getorders()
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
            textBox6.Text = "Retrieving Records..."; command.Connection = conn;
            command.CommandText = "select * from OrderDetail";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); 
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            textBox6.Text = "Retrieval Successful!"; conn.Close();
        }
        public orderdetail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox6.Text = "PLacing Order...";
            command.Connection = connection;
            command.CommandText = "insert into OrderDetail (OrderDetailID, OrderID, ProductID, Quantity, UnitPrice) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            // now we will deduct the quantity from the product table
            command.ExecuteNonQuery();
            textBox6.Text = "Order Placed...";
            command.CommandText = "update Product set StockQuantity=StockQuantity-'" + textBox4.Text + "' where ProductID='" + textBox3.Text + "'";
            command.ExecuteNonQuery();
            connection.Close();
            getorders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prods();
            getorders();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashboard dsh = new dashboard();
            dsh.Show();
            this.Close();
        }
    }
}
