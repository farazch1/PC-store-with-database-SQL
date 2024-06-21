using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Theory_Project__Game_Store_
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                Customers c = new Customers();
                c.Show();
            }
            else if (radioButton2.Checked)
            {
                this.Hide();
                product_window pw = new product_window();
                pw.Show();
            }
            else if (radioButton3.Checked)
            {
                this.Hide();
                orderH ohe = new orderH();
                ohe.Show();
            }
            else if (radioButton4.Checked)
            {
                this.Hide();
                orderdetail odret = new orderdetail();
                odret.Show();
            }
            else if (radioButton5.Checked)
            {
                this.Hide();
                employees emp = new employees();
                emp.Show();
            }
            else if (radioButton6.Checked)
            {
                this.Hide();
                supplier sup = new supplier();
                sup.Show();
            }
        }
    }
}
