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

namespace Loginform2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string cs = "Server=ASHOK\\SQLEXPRESS; Database=adonet; Integrated Security=true";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into logininfo values('" + txtusername.Text + "','" + txtpassword.Text + "')", con);
            cmd.ExecuteNonQuery();
            txtusername.Clear();
            txtpassword.Text = "";
            lbldisplay.Text = "Inserted Successfully";
            lbldisplay.ForeColor = System.Drawing.Color.Red;
            con.Close();


        }
    }
}
