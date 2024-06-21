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
    public partial class supplier : Form
    {
        void supplier_data()
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
            command.CommandText = "select * from Supplier";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); da.Fill(dt);

            dataGridView1.DataSource = dt;
             conn.Close();
        }
        public supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox7.Text = "Inserting Supplier...";
            command.Connection = connection;
            command.CommandText = "insert into Supplier (SupplierID, SupplierName, ContactPerson, Phone, Email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            command.ExecuteNonQuery();
            textBox7.Text = "Supplier Added...";
            connection.Close();
            supplier_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox7.Text = "Deleting Record...";
            command.Connection = connection;
            command.CommandText = "delete from Supplier where SupplierID='" + textBox6.Text + "'";
            command.ExecuteNonQuery();
            textBox7.Text = "Record Deleted...";
            connection.Close();
            supplier_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supplier_data();
            textBox7.Text = "Retrieval Successful!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Close();
        }
    }
}
