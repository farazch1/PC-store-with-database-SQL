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
    public partial class employees : Form
    {
        void view_employees()
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
            command.CommandText = "select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); da.Fill(dt);

            dataGridView1.DataSource = dt;
             conn.Close();
        }
        public employees()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox6.Text = "Adding Employee...";
            command.Connection = connection;
            command.CommandText = "insert into Employee (EmployeeID, FirstName, LastName, Position) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text  + "')";
            command.ExecuteNonQuery();
            textBox6.Text = "Employee Added...";
            connection.Close();
            view_employees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=pcstore;Integrated Security=True");
            connection.Open();
            textBox6.Text = "Firing Employee...";
            command.Connection = connection;
            command.CommandText = "delete from Employee where EmployeeID='" + textBox5.Text + "'";
            command.ExecuteNonQuery();
            textBox6.Text = "Employee Fired...";
            connection.Close();
            view_employees();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_employees();
            textBox6.Text = "Retrieval Successful!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            d.Show();
            this.Close();
        }
    }
}
