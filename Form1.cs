using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_Theory_Project__Game_Store_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string username = "";
        public static string password = "";

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SqlConnection connection = new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = pcstore; Integrated Security = True");
                username = textBox1.Text;
                password = textBox2.Text;
                if (username == "" || password == "")
                {
                    MessageBox.Show("Please enter your username and password.");
                }
                else
                {
                    var datasource = @"(local)\SQLEXPRESS";
                    var database = "pcstore";
                    var thisUsername = username;
                    var thisPassword = password;
                    string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
                    SqlConnection conn = new SqlConnection(connString);

                    try
                    {
                        conn.Open();
                        dashboard dashboard = new dashboard();
                        dashboard.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
