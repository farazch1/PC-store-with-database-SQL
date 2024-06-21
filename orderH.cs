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
    public partial class orderH : Form
    {
        public orderH()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard dassh = new dashboard();
            dassh.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
            command.CommandText = "select * from OrderHeader";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); da.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
